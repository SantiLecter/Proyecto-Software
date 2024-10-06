using MediatR;

namespace SecurityApp.Application.Features.Vacuna.Commands.CreateVacuna;

public class CreateVacunaCommand : IRequest<string>
{
    public string Nombre { get; set; } = string.Empty;
    public DateTime FechaAplicacion { get; set; } =DateTime.Now;
    public DateTime FechaProximaDosis { get; set; }
    public string AnimalId { get; set; } = string.Empty;
}