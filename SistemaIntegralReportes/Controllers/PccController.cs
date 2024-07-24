using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaIntegralReportes.EntityModels;

namespace SistemaIntegralReportes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  
    public class PccController : ControllerBase
    {
        private readonly SistemaIntegralReportesContext _context;

        public PccController(SistemaIntegralReportesContext context)
        {
            _context = context;
        }

        [HttpGet("getPCC")]
        public async Task<ActionResult<IEnumerable<PCC>>> GetPCCData([FromQuery] int hora, string especie)
        {
            if (_context.PCCs == null)
            {
                return NotFound();
            }
            var pccs = await _context.PCCs
                        .Where(p => p.HoraInicioFaena == hora && p.Especie == especie)
                        .ToListAsync();

            if (pccs == null || pccs.Count == 0)
            {
                return NotFound();
            }

            return pccs;
        }
    }
}
