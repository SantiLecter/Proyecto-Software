namespace SecurityApp.Domain.Common;

public class Cuidado : BaseDomain
{
        public DateTime FechaCuidado { get; set; }
        public string TipoCuidado { get; set; } = string.Empty;
        public string Descripcion { get; set; } = String.Empty;
        public int AnimalId { get; set; }
        public virtual Animal Animal { get; set; }
        public int CuidadorId { get; set; }
        public virtual Cuidador Cuidador { get; set; }
}