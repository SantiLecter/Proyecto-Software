namespace SecurityApp.Domain.Common;

public class Cuidador  : BaseDomain
{
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Turno { get; set; }
        public virtual ICollection<Cuidado> Cuidados { get; set; }
}