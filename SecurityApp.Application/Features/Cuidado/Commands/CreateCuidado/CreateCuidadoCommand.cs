using MediatR;

namespace SecurityApp.Application.Features.Cuidado.Commands.CreateCuidado;

public class CreateCuidadoCommand : IRequest<string>
{
    public string TipoCuidado { get; set; } = string.Empty;
    public string Descripcion { get; set; } = String.Empty;
    public string AnimalId { get; set; } = string.Empty;
    public String CuidadorId { get; set; } = String.Empty;
}