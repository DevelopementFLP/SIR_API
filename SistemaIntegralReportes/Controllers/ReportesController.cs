using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaIntegralReportes.EntityModels;

namespace SistemaIntegralReportes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class ReportesController : ControllerBase
    {
        private readonly SistemaIntegralReportesContext _context;

        public ReportesController(SistemaIntegralReportesContext context)
        {
            _context = context;
        }

        // GET: api/Reportes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reporte>>> GetReportes()
        {
          if (_context.Reportes == null)
          {
              return NotFound();
          }
            return await _context.Reportes.ToListAsync();
        }

        // GET: api/Reportes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reporte>> GetReporte(int id)
        {
          if (_context.Reportes == null)
          {
              return NotFound();
          }
            var reporte = await _context.Reportes.FindAsync(id);

            if (reporte == null)
            {
                return NotFound();
            }

            return reporte;
        }

        // PUT: api/Reportes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReporte(int id, Reporte reporte)
        {
            if (id != reporte.IdReporte)
            {
                return BadRequest();
            }

            _context.Entry(reporte).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReporteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Reportes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Reporte>> PostReporte(Reporte reporte)
        {
          if (_context.Reportes == null)
          {
              return Problem("Entity set 'SistemaIntegralReportesContext.Reportes'  is null.");
          }
            _context.Reportes.Add(reporte);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReporte", new { id = reporte.IdReporte }, reporte);
        }

        // DELETE: api/Reportes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReporte(int id)
        {
            if (_context.Reportes == null)
            {
                return NotFound();
            }
            var reporte = await _context.Reportes.FindAsync(id);
            if (reporte == null)
            {
                return NotFound();
            }

            _context.Reportes.Remove(reporte);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReporteExists(int id)
        {
            return (_context.Reportes?.Any(e => e.IdReporte == id)).GetValueOrDefault();
        }
    }
}
