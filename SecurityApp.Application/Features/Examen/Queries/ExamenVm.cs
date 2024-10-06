namespace SecurityApp.Application.Features.Examen.Queries;

public class ExamenVm
{
    public string Id { get; set; } = string.Empty;
    public string TipoExamen { get; set; } = string.Empty;
    public string Resultado { get; set; } = string.Empty;
    public DateTime FechaExamen { get; set; } = DateTime.Now;
    public string AnimalId { get; set; } = string.Empty;
}