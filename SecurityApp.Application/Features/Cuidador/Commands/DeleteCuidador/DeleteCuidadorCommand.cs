using MediatR;

namespace SecurityApp.Application.Features.Cuidador.Commands.DeleteCuidador;

public class DeleteCuidadorCommand : IRequest<bool>
{
    public string Id { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public string Correo { get; set; } = string.Empty;
    public string Telefono { get; set; } = string.Empty;
    public string Turno { get; set; } = string.Empty;
}