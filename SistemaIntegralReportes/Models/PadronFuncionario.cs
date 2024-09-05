namespace SistemaIntegralReportes.Models
{
    public class PadronFuncionario
    {
        public int Id { get; set; }
        public string NroFuncionario { get; set; }
        public string Apellidos { get; set; }
        public string Nombres { get; set; }
        public string Sector {  get; set; }
        public string TipoRemuneracion { get; set; }
        public double HorasTrabajadas { get; set; }
        public string DiasTrabajados { get; set; }
        public DateTime UltimaModificacion { get; set; }
    }
}
