using MediatR;

namespace SecurityApp.Application.Features.Examen.Commands.CreateExamen;

public class CreateExamenCommand : IRequest<string>
{
    public string TipoExamen { get; set; } = string.Empty;
    public string Resultado { get; set; } = string.Empty;
    public DateTime FechaExamen { get; set; }
    public string AnimalId { get; set; } = string.Empty;
}