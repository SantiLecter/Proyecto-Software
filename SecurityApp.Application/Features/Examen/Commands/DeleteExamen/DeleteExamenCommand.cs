using MediatR;

namespace SecurityApp.Application.Features.Examen.Commands.DeleteExamen;

public class DeleteExamenCommand : IRequest<bool>
{
    public string Id { get; set; } = string.Empty;
    public string TipoExamen { get; set; } = string.Empty;
    public string Resultado { get; set; } = string.Empty;
    public DateTime FechaExamen { get; set; }
    public string AnimalId { get; set; } = string.Empty;
}