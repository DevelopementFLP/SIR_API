namespace SistemaIntegralReportes.Models
{
    public class Email
    {
        public string[] Para { get; set; }
        public string Asunto { get; set; } = string.Empty;
        public string Contenido {  get; set; } = string.Empty;
    }
}
