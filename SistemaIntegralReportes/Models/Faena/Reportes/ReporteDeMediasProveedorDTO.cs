namespace SistemaIntegralReportes.Models.Faena.Reportes
{
    public class ReporteDeMediasProveedorDTO
    {
        private string _proveedor = string.Empty;
        private string _tropa = string.Empty;
        private string _grade = string.Empty;
        private Int32 _medias = 0;
        private double _pesoMedias = 0;

        public string Proveedor
        {
            get { return _proveedor; }
            set { _proveedor = value; }
        }

        public string Tropa
        {
            get { return _tropa; }
            set { _tropa = value; }
        }

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
