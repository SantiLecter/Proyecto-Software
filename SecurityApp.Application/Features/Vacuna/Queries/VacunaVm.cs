namespace SecurityApp.Application.Features.Vacuna.Queries;

public class VacunaVm
{
    public string Id { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public DateTime FechaAplicacion { get; set; } =DateTime.Now;
    public DateTime FechaProximaDosis { get; set; }
    public string AnimalId { get; set; } = string.Empty;
}