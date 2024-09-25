namespace SistemaIntegralReportes.Models.Faena.Reportes
{
    public class ReporteDeMediasGradeDTO
    {
        private string _grade = string.Empty;
        private Int32 _medias = 0;
        private double _pesoMedias = 0;

        public string Grade 
        { 
            get { return _grade; } 
            set { _grade = value; } 
        }

        public Int32 Medias
        {
            get { return _medias; }
            set { _medias = value; }
        }

        public double PesoMedias
        {
            get { return _pesoMedias; }
            set { _pesoMedias = value; }
        }
    }
}
