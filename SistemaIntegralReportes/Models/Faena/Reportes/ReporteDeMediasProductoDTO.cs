namespace SistemaIntegralReportes.Models.Faena.Reportes
{
    public class ReporteDeMediasProductoDTO
    {
        private string _producto = string.Empty;
        private string _grade = string.Empty;
        private int _cuartos;
        private double _pesoCuartos;

        public string Producto
        {
            get { return _producto; }
            set { _producto = value; }
        }

        public string Grade
        {
            get { return _grade; }
            set { _grade = value; }
        }

        public int Cuartos
        {
            get { return _cuartos; }
            set { _cuartos = value; }
        }

        public double PesoCuartos
        {
            get { return _pesoCuartos; }
            set { _pesoCuartos = value; }
        }
    }
}
