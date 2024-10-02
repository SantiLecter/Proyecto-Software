namespace SecurityApp.Domain.Common;

public class Animal : BaseDomain
{
        public string Especie { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string TipoComida { get; set; } = string.Empty;
        public string EstadoSalud { get; set; } = string.Empty;
        public float Peso { get; set; }
        public DateTime FechaRegistro { get; set; }
        public virtual ICollection<Vacuna> Vacunas { get; set; }
        public virtual ICollection<Examen> Examenes { get; set; }
        public virtual ICollection<Cuidado> Cuidados { get; set; }
}