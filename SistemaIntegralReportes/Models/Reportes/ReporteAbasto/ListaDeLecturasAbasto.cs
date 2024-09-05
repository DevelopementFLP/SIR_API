namespace SistemaIntegralReportes.Models.Reportes.ReporteAbasto
{
    public class ListaDeLecturasAbasto
    {
        private string _fechaDeRegistro = string.Empty;
        private string _lecturaDeMedia = string.Empty;
        private string _idAnimal = string.Empty;
        private string _tropa = string.Empty;
        private string _proveedor = string.Empty;
        private float _peso = 0;
        private string _fechaDeFaena = string.Empty;
        private string _clasificacion = string.Empty;
        private string _secuencial = string.Empty;
        private string _operacion = string.Empty;

        public string FechaDeRegistro
        {
            get { return _fechaDeRegistro; }
            set { _fechaDeRegistro = value; }
        }

        public string LecturaDeMedias
        {
            get { return _lecturaDeMedia; }
            set { _lecturaDeMedia = value; }
        }

        public string IdAnimal
        {
            get { return _idAnimal; }
            set { _idAnimal = value; }
        }

        public string Tropa
        {
            get { return _tropa; }
            set { _tropa = value; }
        }

        public string Proveedor
        {
            get { return _proveedor; }
            set { _proveedor = value; }
        }

        public float Peso
        {
            get { return _peso; }
            set { _peso = value; }
        }

        public string FechaDeFaena
        {
            get { return _fechaDeFaena; }
            set { _fechaDeFaena = value; }
        }

        public string Clasificacion
        {
            get { return _clasificacion; }
            set { _clasificacion = value; }
        }

        public string Secuencial
        {
            get { return _secuencial; }
            set { _secuencial = value; }
        }

        public string Operacion
        {
            get { return _operacion; }
            set { _operacion = value; }
        }
    }
}
