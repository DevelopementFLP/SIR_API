using SistemaIntegralReportes.Models.Dispositivos;

namespace SistemaIntegralReportes.Models.Reportes
{
    public class MermaPorPeso
    {
        private string _fechaDeBalanza = string.Empty;
        private string _fechaDeInnova = string.Empty;
        private string _carcassId = string.Empty;
        private string _ladoAnimal = string.Empty;
        private string _diferenciaDePeso = string.Empty;
        private float _pesoInnova = 0;
        private double _pesoLocal = 0;
        private double _porsentajeDeMerma = 0;
        private Int32 _seccionDelDia = 0;
        private string _etiqueta = string.Empty;
        private string _tropa = string.Empty;
        private string _proveedor = string.Empty;


        public string FechaDeBalanza
        {
            get { return _fechaDeBalanza; }
            set { _fechaDeBalanza = value; }
        }

        public string FechaDeInnova
        {
            get { return _fechaDeInnova; }
            set { _fechaDeInnova = value; }
        }

        public string CarcassID
        {
            get { return _carcassId; }
            set { _carcassId = value; }
        }

        public string LadoAnimal
        {
            get { return _ladoAnimal; }
            set { _ladoAnimal = value; }
        }

        public string DiferenciadePeso
        {
            get { return _diferenciaDePeso; }
            set { _diferenciaDePeso = value; }
        }

        public float PesoInnova
        {
            get { return _pesoInnova; }
            set { _pesoInnova = value; }
        }

        public double PesoLocal
        {
            get { return _pesoLocal; }
            set { _pesoLocal = value; }
        }

        public Int32 SeccionDelDia
        {
            get { return _seccionDelDia; }
            set { _seccionDelDia = value; }
        }

        public double PorsentajeDeMerma
        {
            get { return _porsentajeDeMerma; }
            set { _porsentajeDeMerma = value; }
        }

        public string Etiqueta
        {
            get { return _etiqueta; }
            set { _etiqueta = value; }
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

        public MermaPorPeso() { }
    }
}
