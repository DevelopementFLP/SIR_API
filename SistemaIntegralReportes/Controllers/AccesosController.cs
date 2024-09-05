using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaIntegralReportes.EntityModels;

namespace SistemaIntegralReportes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AccesosController : ControllerBase
    {
        private readonly SistemaIntegralReportesContext _context;

        public AccesosController(SistemaIntegralReportesContext context)
        {
            _context = context;
        }

        // GET: api/Accesos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConfAcceso>>> GetConfAccesos()
        {
            if (_context.ConfAccesos == null)
            {
                return NotFound();
            }
            return await _context.ConfAccesos.ToListAsync();
        }

        // GET: api/Accesos/5
        [HttpGet("{id_perfil}")]
        public async Task<ActionResult<List<ConfAcceso>>> GetConfAcceso(int id_perfil)
        {
            if (_context.ConfAccesos == null)
            {
                return NotFound();
            }
            var confAcceso = await _context.ConfAccesos.Where(x => x.IdPerfil == id_perfil && x.Permitido == true).ToListAsync();

            if (confAcceso == null)
            {
                return NotFound();
            }

            return Ok(confAcceso);
        }

        // PUT: api/Accesos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConfAcceso(int id, ConfAcceso confAcceso)
        {
            if (id != confAcceso.IdAcceso)
            {
                return BadRequest();
            }

            _context.Entry(confAcceso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConfAccesoExists(id))
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

        // POST: api/Accesos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ConfAcceso>> PostConfAcceso(ConfAcceso confAcceso)
        {
            if (_context.ConfAccesos == null)
            {
                return Problem("Entity set 'SistemaIntegralReportesContext.ConfAccesos'  is null.");
            }
            _context.ConfAccesos.Add(confAcceso);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConfAcceso", new { id = confAcceso.IdAcceso }, confAcceso);
        }

        // DELETE: api/Accesos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConfAcceso(int id)
        {
            if (_context.ConfAccesos == null)
            {
                return NotFound();
            }
            var confAcceso = await _context.ConfAccesos.FindAsync(id);
            if (confAcceso == null)
            {
                return NotFound();
            }

            _context.ConfAccesos.Remove(confAcceso);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConfAccesoExists(int id)
        {
            return (_context.ConfAccesos?.Any(e => e.IdAcceso == id)).GetValueOrDefault();
        }
    }
}
