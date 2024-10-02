namespace SecurityApp.Domain.Common;

public class Examen  : BaseDomain
{
        public string TipoExamen { get; set; } = string.Empty;
        public string Resultado { get; set; } = string.Empty;
        public DateTime FechaExamen { get; set; }
        public int AnimalId { get; set; }
        public virtual Animal Animal { get; set; }
        
}