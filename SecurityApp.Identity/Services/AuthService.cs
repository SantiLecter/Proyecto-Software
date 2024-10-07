

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SecurityApp.Application.Constans;
using SecurityApp.Application.Contracts.Identity;
using SecurityApp.Application.Models.Auth;
using SecurityApp.Application.Models.Jwt;
using SecurityApp.Application.Models.Registration;
using SecurityApp.Identity.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SecurityApp.Identity.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly JwtSettings _jwtSettings;

        public AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IOptions<JwtSettings> jwtSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<AuthResponse> Login(AuthRequest request)
        {
            //Buscamos el usuario en la bd con el email
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
            {
                var authResponseNotFound = new AuthResponse
                {
                    Status = false,
                    Message = $"Email {request.Email} no encontrado."
                };

                return authResponseNotFound;
            }

            //Probamos si las credenciales son correctas
            var resultado = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, lockoutOnFailure: false);

            //Si el resultado no es exitoso
            if (!resultado.Succeeded)
            {
                await _userManager.AccessFailedAsync(user);
                var authResponseNotFound = new AuthResponse
                {
                    Status = false,
                    Message = $"Credenciales incorrectas, vuelva a intentar."

                };

                return authResponseNotFound;
            }

            // Generamos el token
            var token = await GenerateToken(user);

            var authResponse = new AuthResponse
            {
                Id = user.Id,
                Username = user.UserName,
                UrlPhoto = user.UrlPhoto,
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Status = true,
                Message = "Inicio de sesión correcto."
            };

            return authResponse;


        }

        public async Task<RegistrationResponse> Register(RegistrationRequest request)
        {
            // Se revisa correo unico
            var existingUser = await _userManager.FindByEmailAsync(request.Email);
            if (existingUser != null)
            {
                return new RegistrationResponse
                {
                    Status = false,
                    Message = $"El email {request.Email} ya se encuentra registrado"
                };
            }

            // Se valida si el nombre de usuario es unico
            var existing = await _userManager.FindByNameAsync(request.Username);
            if (existing != null)
            {
                return new RegistrationResponse
                {
                    Status = false,
                    Message = $"El usuario con identificación {request.Username} ya se encuentra registrado"
                };
            }

            // Crear el usuario
            var user = new ApplicationUser
            {
                UserName = request.Username,
                PhoneNumber = request.PhoneNumber,
                PhoneNumberConfirmed = true,
                Email = request.Email,
                NormalizedEmail = request.Email.ToLower(),
                EmailConfirmed = true,
                NormalizedUserName = request.Username,
                Name = request.Name,
                UrlPhoto = request.UrlPhoto,
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "user");
                var token = await GenerateToken(user);

                return new RegistrationResponse
                {
                    Id = user.Id,
                    Username = user.UserName,
                    UrlPhoto = user.UrlPhoto,
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    Status = true,
                    Message = "Registro exitoso"
                };
            }

            // Logger de errores
            var errors = string.Join(", ", result.Errors.Select(e => e.Description));
            return new RegistrationResponse
            {
                Status = false,
                Message = $"Error en el registro: {errors}"
            };
        }



        private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
        {

            //Obtenemos la data del usuario
            var userClaims = await _userManager.GetClaimsAsync(user);

            //Obtenemos los roles del usuario
            var roles = await _userManager.GetRolesAsync(user);


            var roleClaims = new List<Claim>();

            foreach (var role in roles)
            {
                roleClaims.Add(new Claim(ClaimTypes.Role, role));
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(CustomClaimTypes.Id, user.Id)
            }.Union(userClaims).Union(roleClaims);

            //Creamos el algoritmo seguro
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                        issuer: _jwtSettings.Issuer,
                        audience: _jwtSettings.Audience,
                        claims: claims,
                        expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                        signingCredentials: signingCredentials
                   );
            return jwtSecurityToken;
        }

    }
}
