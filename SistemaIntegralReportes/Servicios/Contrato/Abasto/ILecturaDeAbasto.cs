﻿using SistemaIntegralReportes.DTO.Abasto;
using SistemaIntegralReportes.Models.Reportes.ReporteAbasto;

namespace SistemaIntegralReportes.Servicios.Contrato.Abasto
{
    public interface ILecturaDeAbasto
    {
        Task<List<LecturaDeAbastoDTO>> GetLecturaDeAbasto();

        Task<LecturaDeAbastoDTO> InsertarLectura(string lectura, string operacion, string usuarioLogueado, DateTime? fechaDeFaena);

        Task<List<ListaDeLecturasAbasto>> ListarStockAbasto();

        Task<LecturaDeAbastoDTO> GetCodigoQrFiltrado(string codigoQr);

        Task<bool> DeleteLecturaDeAbasto(string idAnimal);
    }
}
