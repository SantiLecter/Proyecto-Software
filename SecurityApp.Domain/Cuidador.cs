namespace SecurityApp.Domain.Common;

public class Cuidador  : BaseDomain
{
        public string Nombre { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Turno { get; set; } = string.Empty;
        public virtual ICollection<Cuidado> Cuidados { get; set; }
}