using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaIntegralReportes.DTO.FichaTecnica
{
    public class FotoFichaUbicacionDTO
    {
        public int IdFichaTecnica { get; set; }
        public FichaTecnicaDTO FichaTecnica { get; set; }

        public int IdUbicacionFoto { get; set; }
        public UbicacionDeFotoDTO UbicacionFoto { get; set; }

        public byte[] Foto { get; set; }
    }
}
