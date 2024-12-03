using System;

namespace SistemaIntegralReportes.DTO.FichaTecnica
{
    public class FichaTecnicaDTO
    {
        public int? IdFichaTecnica { get; set; }
        public string? CodigoDeProducto { get; set; }
        public string? NombreDeProducto { get; set; }  
        public string? DescripcionDeProducto { get; set; }  
        public string? DescripcionLargaDeProducto { get; set; }  
        public string? Marca { get; set; }
        public string? Destino { get; set; }  
        public string? TipoDeUso { get; set; }
        public string? Alergeno { get; set; }
        public string? CondicionAlmacenamiento { get; set; }
        public string? VidaUtil { get; set; }
        public string? TipoDeEnvase { get; set; }
        public string? PresentacionDeEnvase { get; set; }

        public string? PesoPromedio { get; set; }
        public string? UnidadesPorCaja { get; set; }
        public string? Dimensiones { get; set; }

        public string? Idioma { get; set; }
        public string? GrasaVisible { get; set; }
        public string? EspesorCobertura { get; set; }
        public string? Ganglios { get; set; }
        public string? Hematomas { get; set; }
        public string? HuesosCartilagos { get; set; }
        public string? ElementosExtranos { get; set; }

        public string? Color { get; set; }
        public string? Olor { get; set; }
        public string? Ph { get; set; }
        public string? AerobiosMesofilosTotales { get; set; }
        public string? Enterobacterias { get; set; }
        public string? Stec0157 { get; set; }
        public string? StecNo0157 { get; set; }
        public string? Salmonella { get; set; }
        public string? Estafilococos { get; set; }
        public string? Pseudomonas { get; set; }
        public string? EscherichiaColi { get; set; }
        public string? ColiformesTotales { get; set; }
        public string? ColiformesFecales { get; set; }
        public string? Observacion { get; set; }
        public string? ElaboradoPor { get; set; }
        public string? AprobadoPor { get; set; }
        public string? FechaCreacion { get; set; }
    }
}
