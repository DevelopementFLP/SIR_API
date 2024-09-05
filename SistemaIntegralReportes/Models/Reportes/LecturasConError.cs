namespace SistemaIntegralReportes.Models.Reportes
{
    public class LecturasConError
    {
        private Int32 _idCaja = 0;
        private string _idQr = string.Empty;
        private string _codigo = string.Empty;
        private string _nombre = string.Empty;
        private float _peso = 0;
        private float _Cl = 0;
        private string _fechaDeProduccion;
        private string _fechaDeCreado;
        private string _fechaDeCerrado;
        private string _registro = string.Empty;
        private string _estado = string.Empty;


        public Int32 IdCaja
        {
            get { return _idCaja; }
            set { _idCaja = value; }
        }
        public string IdQr
        {
            get { return _idQr; }
            set { _idQr = value; }
        }
        public string Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public float Peso
        {
            get { return _peso; }
            set { _peso = value; }
        }

        public float Cl
        {
            get { return _Cl; }
            set { _Cl = value; }
        }
        public string FechaDeProduccion
        {
            get { return _fechaDeProduccion; }
            set { _fechaDeProduccion = value; }
        }
        public string FechaDeCreado
        {
            get { return _fechaDeCreado; }
            set { _fechaDeCreado = value; }
        }

        public string FechaDeCerrado
        {
            get { return _fechaDeCerrado; }
            set { _fechaDeCerrado = value; }
        }

        public string Registro
        {
            get { return _registro; }
            set { _registro = value; }
        }
        public string Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }
    }
}
