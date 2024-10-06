namespace SecurityApp.Domain.Common;

public class Cuidado : BaseDomain
{
        public DateTime FechaCuidado { get; set; } = DateTime.Now;
        public string TipoCuidado { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string AnimalId { get; set; }
        public virtual Animal Animal { get; set; }
        public string CuidadorId { get; set; }
        public virtual Cuidador Cuidador { get; set; }
}