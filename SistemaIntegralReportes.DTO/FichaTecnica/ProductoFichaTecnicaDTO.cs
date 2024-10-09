using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SistemaIntegralReportes.DTO.FichaTecnica
{
    public class ProductoFichaTecnicaDTO
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Codigo { get; set; }
        public string Observacion { get; set; }
        public decimal PesoPromedio { get; set; }

        public MarcaDTO Marca { get; set; }
        public CondicionDeAlmacenamientoDTO CondicionAlmacenamiento { get; set; }
        public ColorDTO Color { get; set; }
        public TipoDeUsoDTO TipoDeUso { get; set; }
        public OlorDTO Olor { get; set; }
        public PhDTO Ph { get; set; }
        public AlergenosDTO Alergeno { get; set; }
        public VidaUtilDTO VidaUtil { get; set; }
        public TipoDeAlimentacionDTO Alimentacion { get; set; }
        public TipoDeEnvaseDTO TipoDeEnvase { get; set; }
        public PresentacionDeEnvaseDTO PresentacionDeEnvase { get; set; }
    }
}
