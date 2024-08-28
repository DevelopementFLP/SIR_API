using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaIntegralReportes.DTO.Abasto
{
    public class LecturaDeAbastoDTO
    {
        private DateTime _fechaDeRegistro;
        private string _lecturaDeMedia = string.Empty;
        private string _idAnimal = string.Empty;
        private string _secuencial = string.Empty;
        private string _operacion = string.Empty;
        private decimal? _peso = 0;
        private DateTime? _fechaDeFaena;
        private string _usuarioLogueado;



        public DateTime FechaDeRegistro
        {
            get { return _fechaDeRegistro; }
            set { _fechaDeRegistro = value; }
        }

        public string LecturaDeMedia
        {
            get { return _lecturaDeMedia; }
            set { _lecturaDeMedia = value; }
        }

        public string IdAnimal
        {
            get { return _idAnimal; }
            set { _idAnimal = value; }
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

        public decimal? Peso
        {
            get { return _peso; }
            set { _peso = value; }
        }

        public DateTime? FechaDeFaena
        {
            get { return _fechaDeFaena; }
            set { _fechaDeFaena = value; }
        }

        public string UsuarioLogueado
        {
            get { return _usuarioLogueado; }
            set { _usuarioLogueado = value; }
        }
    }
}
