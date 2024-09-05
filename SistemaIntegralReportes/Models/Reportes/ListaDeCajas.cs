namespace SistemaIntegralReportes.Models.Reportes
{
    public class ListaDeCajas
    {
        private string _fecha = string.Empty;
        private string _dispositivo = string.Empty;
        private string _ubicacion = string.Empty;
        private string _lectura = string.Empty;
        private Int64 _idCaja;

        public string Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }
        public string Dispositivo
        {
            get { return _dispositivo; }
            set { _dispositivo = value; }
        }
        public string Ubicacion
        {
            get { return _ubicacion; }
            set { _ubicacion = value; }
        }
        public string Lectura
        {
            get { return _lectura; }
            set { _lectura = value; }
        }
        public Int64 IdCaja
        {
            get { return _idCaja; }
            set { _idCaja = value; }
        }
        public ListaDeCajas() { }
    }
}
