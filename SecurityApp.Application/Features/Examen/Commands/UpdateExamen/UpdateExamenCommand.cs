using MediatR;

namespace SecurityApp.Application.Features.Examen.Commands.UpdateExamen;

public class UpdateExamenCommand : IRequest
{
    public string Id { get; set; } = string.Empty;
    public string TipoExamen { get; set; } = string.Empty;
    public string Resultado { get; set; } = string.Empty;
    public DateTime FechaExamen { get; set; }
    public string AnimalId { get; set; } = string.Empty;
}