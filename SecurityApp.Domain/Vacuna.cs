namespace SecurityApp.Domain.Common;

public class Vacuna  : BaseDomain
{
        public string Nombre { get; set; } = string.Empty;
        public DateTime FechaAplicacion { get; set; }
        public DateTime FechaProximaDosis { get; set; }
        public int AnimalId { get; set; }
        public virtual Animal Animal { get; set; }

}