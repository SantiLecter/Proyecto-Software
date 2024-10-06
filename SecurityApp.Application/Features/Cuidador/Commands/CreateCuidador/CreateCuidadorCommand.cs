using MediatR;

namespace SecurityApp.Application.Features.Cuidador.Commands.CreateCuidador;

public class CreateCuidadorCommand : IRequest<string>
{
    public string Nombre { get; set; } = string.Empty;
    public string Correo { get; set; } = string.Empty;
    public string Telefono { get; set; } = string.Empty;
    public string Turno { get; set; } = string.Empty;
}