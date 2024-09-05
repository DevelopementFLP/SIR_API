namespace SistemaIntegralReportes.Models.Configuraciones
{
    public class ParametrosDw_Abasto
    {
        private Int32 _idConfiguracion { get; set; }
        private string _parametroDeConfiguracion { get; set; }
        private string _descripcion { get; set; }

        public Int32 IdConfiguracion
        {
            get { return _idConfiguracion; }
            set { _idConfiguracion = value; }
        }

        public string ParametroDeConfiguracion
        {
            get { return _parametroDeConfiguracion; }
            set { _parametroDeConfiguracion = value; }
        }

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

    }

}
