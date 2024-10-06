namespace SecurityApp.Domain.Common;

public class Examen  : BaseDomain
{
        public string TipoExamen { get; set; } = string.Empty;
        public string Resultado { get; set; } = string.Empty;
        public DateTime FechaExamen { get; set; } = DateTime.Now;
        public string AnimalId { get; set; } = string.Empty;
        public virtual Animal Animal { get; set; }
        
}