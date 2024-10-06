namespace SecurityApp.Domain.Common;

public class Vacuna  : BaseDomain
{
        public string Nombre { get; set; } = string.Empty;
        public DateTime FechaAplicacion { get; set; } =DateTime.Now;
        public DateTime FechaProximaDosis { get; set; }
        public string AnimalId { get; set; } = string.Empty;
        public virtual Animal Animal { get; set; }

}