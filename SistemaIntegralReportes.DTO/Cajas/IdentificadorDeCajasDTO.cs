using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaIntegralReportes.DTO.Cajas
{
    public class IdentificadorDeCajasDTO
    {
        private Int32 _id = 0;
        private Int32 _numero = 0;
        private string _codigoCaja = string.Empty;
        private Int32 _piezas = 0;
        private string _prday = string.Empty;
        private string _regtime = string.Empty;
        private string _codigoProducto = string.Empty;
        private string _estacion = string.Empty;
        private Int32 _idEtiqueta = 0;
        private string _etiqueta = string.Empty;
        private string _estado = string.Empty;
        private string _situacion = string.Empty;
        private float _peso = 0;
        private float _tara = 0;
        private string _fechaFaenaCorte = string.Empty;
        private string _fechaFaenaCaja = string.Empty;
        private string _nombreDeProducto = string.Empty;


        public Int32 Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public Int32 Numero
        {
            get { return _numero; }
            set { _numero = value; }
        }
        public string CodigoCaja
        {
            get { return _codigoCaja; }
            set { _codigoCaja = value; }
        }

        public Int32 Piezas
        {
            get { return _piezas; }
            set { _piezas = value; }
        }

        public string Prday
        {
            get { return _prday; }
            set { _prday = value; }
        }

        public string Regtime
        {
            get { return _regtime; }
            set { _regtime = value; }
        }

        public string CodigoProducto
        {
            get { return _codigoProducto; }
            set { _codigoProducto = value; }
        }

        public string Estacion
        {
            get { return _estacion; }
            set { _estacion = value; }
        }

        public Int32 IdEtiqueta
        {
            get { return _idEtiqueta; }
            set { _idEtiqueta = value; }
        }

        public string Etiqueta
        {
            get { return _etiqueta; }
            set { _etiqueta = value; }
        }

        public string Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

        public string Situacion
        {
            get { return _situacion; }
            set { _situacion = value; }
        }

        public float Peso
        {
            get { return _peso; }
            set { _peso = value; }
        }

        public float Tara
        {
            get { return _tara; }
            set { _tara = value; }
        }

        public string FechaFaenaCorte
        {
            get { return _fechaFaenaCorte; }
            set { _fechaFaenaCorte = value; }
        }

        public string FechaFaenaCaja
        {
            get { return _fechaFaenaCaja; }
            set { _fechaFaenaCaja = value; }
        }

        public string NombreDeProducto
        {
            get { return _nombreDeProducto; }
            set { _nombreDeProducto = value; }
        }

    }
}
