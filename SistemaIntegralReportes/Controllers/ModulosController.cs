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
   
    public class ModulosController : ControllerBase
    {
        private readonly SistemaIntegralReportesContext _context;

        public ModulosController(SistemaIntegralReportesContext context)
        {
            _context = context;
        }

        // GET: api/Modulos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConfModulo>>> GetConfModulos()
        {
          if (_context.ConfModulos == null)
          {
              return NotFound();
          }
            return await _context.ConfModulos.ToListAsync();
        }

        // GET: api/Modulos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ConfModulo>> GetConfModulo(int id)
        {
          if (_context.ConfModulos == null)
          {
              return NotFound();
          }
            var confModulo = await _context.ConfModulos.FindAsync(id);

            if (confModulo == null)
            {
                return NotFound();
            }

            return confModulo;
        }

        // PUT: api/Modulos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConfModulo(int id, ConfModulo confModulo)
        {
            if (id != confModulo.IdModulo)
            {
                return BadRequest();
            }

            _context.Entry(confModulo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConfModuloExists(id))
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

        // POST: api/Modulos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ConfModulo>> PostConfModulo(ConfModulo confModulo)
        {
          if (_context.ConfModulos == null)
          {
              return Problem("Entity set 'SistemaIntegralReportesContext.ConfModulos'  is null.");
          }
            _context.ConfModulos.Add(confModulo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConfModulo", new { id = confModulo.IdModulo }, confModulo);
        }

        // DELETE: api/Modulos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConfModulo(int id)
        {
            if (_context.ConfModulos == null)
            {
                return NotFound();
            }
            var confModulo = await _context.ConfModulos.FindAsync(id);
            if (confModulo == null)
            {
                return NotFound();
            }

            _context.ConfModulos.Remove(confModulo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConfModuloExists(int id)
        {
            return (_context.ConfModulos?.Any(e => e.IdModulo == id)).GetValueOrDefault();
        }
    }
}
