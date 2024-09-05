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
  
    public class PerfilesController : ControllerBase
    {
        private readonly SistemaIntegralReportesContext _context;

        public PerfilesController(SistemaIntegralReportesContext context)
        {
            _context = context;
        }

        // GET: api/Perfiles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConfPerfile>>> GetConfPerfiles()
        {
          if (_context.ConfPerfiles == null)
          {
              return NotFound();
          }
            return await _context.ConfPerfiles.ToListAsync();
        }

        // GET: api/Perfiles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ConfPerfile>> GetConfPerfile(int id)
        {
          if (_context.ConfPerfiles == null)
          {
              return NotFound();
          }
            var confPerfile = await _context.ConfPerfiles.FindAsync(id);

            if (confPerfile == null)
            {
                return NotFound();
            }

            return confPerfile;
        }

        public class ModuloReporteDTO
        {
            public string label { get; set; }
            public string icon { get; set; }
            public List<ModuloReporteDTO> items { get; set; }
            public string routerLink { get; set; }
            public string target { get; set; }
        }



        // GET: api/Perfiles/1/Reportes
        [HttpGet("{idPerfil}/Reportes")]
        public ActionResult<IEnumerable<object>> GetReportesPorPerfil(int idPerfil)
        {
            var data = (from acceso in _context.ConfAccesos
                        join modulo in _context.ConfModulos on acceso.IdModulo equals modulo.IdModulo
                        join reporte in _context.Reportes on acceso.IdModulo equals reporte.IdModulo
                        where acceso.IdPerfil == idPerfil
                        select new
                        {
                            ModuloNombre = modulo.Nombre,
                            ModuloIcono = modulo.Icono,
                            ReporteNombre = reporte.NombreReporte,
                            ReporteIcono = reporte.Icono,
                            ReporteRouterLink = reporte.RouterLink,
                            ReporteTarget = reporte.Target
                        }).ToList();

            var groupedData = data.GroupBy(d => new { d.ModuloNombre, d.ModuloIcono })
                      .Select(moduloGroup => new ModuloReporteDTO
                      {
                          label = moduloGroup.Key.ModuloNombre.Trim(),
                          icon = moduloGroup.Key.ModuloIcono.Trim(),
                          items = moduloGroup
                              .GroupBy(r => r.ReporteTarget.Trim())
                              .Select(targetGroup => new ModuloReporteDTO
                              {
                                  label = targetGroup.Key, // El target como label
                                  items = targetGroup.Select(r => new ModuloReporteDTO
                                  {
                                      label = r.ReporteNombre.Trim(),
                                      icon = r.ReporteIcono.Trim(),
                                      routerLink = r.ReporteRouterLink.Trim()
                                  })
                                  .OrderBy(r => r.label)
                                  .ToList()
                              })
                              .OrderBy(tg => tg.label)
                              .ToList()
                      })
                      .ToList();


            //var consulta = from acceso in _context.ConfAccesos
            //               join modulo in _context.ConfModulos on acceso.IdModulo equals modulo.IdModulo
            //               join reporte in _context.Reportes on acceso.IdModulo equals reporte.IdModulo
            //               where acceso.IdPerfil == idPerfil
            //               group reporte by new { modulo.Nombre, modulo.Icono } into moduloGroup
            //               select new ModuloReporteDTO
            //               {
            //                   label = moduloGroup.Key.Nombre,
            //                   icon = moduloGroup.Key.Icono,
            //                   items = moduloGroup.Select(reporte => new ModuloReporteDTO
            //                   {
            //                       label = reporte.NombreReporte,
            //                       icon = reporte.Icono,
            //                       routerLink = reporte.RouterLink.Trim(),
            //                       target = reporte.Target.Trim()
            //                   })
            //                    .OrderBy(reporte => reporte.label)
            //                    .ToList()
            //               };

            var resultado = groupedData.ToList();

            if (resultado.Count == 0)
            {
                return NotFound();
            }

            return resultado;
        }


        // PUT: api/Perfiles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConfPerfile(int id, ConfPerfile confPerfile)
        {
            if (id != confPerfile.IdPerfil)
            {
                return BadRequest();
            }

            _context.Entry(confPerfile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConfPerfileExists(id))
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

        // POST: api/Perfiles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ConfPerfile>> PostConfPerfile(ConfPerfile confPerfile)
        {
          if (_context.ConfPerfiles == null)
          {
              return Problem("Entity set 'SistemaIntegralReportesContext.ConfPerfiles'  is null.");
          }
            _context.ConfPerfiles.Add(confPerfile);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConfPerfile", new { id = confPerfile.IdPerfil }, confPerfile);
        }

        // DELETE: api/Perfiles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConfPerfile(int id)
        {
            if (_context.ConfPerfiles == null)
            {
                return NotFound();
            }
            var confPerfile = await _context.ConfPerfiles.FindAsync(id);
            if (confPerfile == null)
            {
                return NotFound();
            }

            _context.ConfPerfiles.Remove(confPerfile);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConfPerfileExists(int id)
        {
            return (_context.ConfPerfiles?.Any(e => e.IdPerfil == id)).GetValueOrDefault();
        }
    }
}
