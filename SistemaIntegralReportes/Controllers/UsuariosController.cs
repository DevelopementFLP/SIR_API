using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _52_ControlUsuariosDataAccess;
using SistemaIntegralReportes.Servicios;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Adapters;

namespace SistemaIntegralReportes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class UsuariosController : ControllerBase
    {
        private readonly UsuariosDataModelContext _context;
        private readonly IServicioEmail servicio;

        public UsuariosController(UsuariosDataModelContext context)
        {
            _context = context;

        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<conf_usuarios>>> Getconf_usuarios()
        {
          if (_context.conf_usuarios == null)
          {
              return NotFound();
          }
            return await _context.conf_usuarios.ToListAsync();
        }

        // GET: api/Usuarios/5
        [HttpGet("{nombreUsuario}")]
        public async Task<ActionResult<conf_usuarios>> Getconf_usuarios(string nombreUsuario)
        {
          if (_context.conf_usuarios == null)
          {
              return NotFound();
          }
            var conf_usuarios =  _context.conf_usuarios.Where(usuario => usuario.nombre_usuario == nombreUsuario);

            if (conf_usuarios == null)
            {
                return NotFound();
            }

            return Ok(conf_usuarios);
        }

        //[HttpGet("perfiles")]
        //public async Task<List<string>> GetPerfiles()
        //{
        //    if (_context.conf_usuarios == null) return new List<string>();

        //    return await _context.conf_usuarios.Select(x => x.conf_perfiles.nombre_perfil).ToListAsync();
        //}

        // PUT: api/Usuarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putconf_usuarios(int id, conf_usuarios conf_usuarios)
        {
            if (id != conf_usuarios.id_usuario)
            {
                return BadRequest();
            }

            _context.Entry(conf_usuarios).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!conf_usuariosExists(id))
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

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchUsuario(int id, [FromBody] JsonPatchDocument<conf_usuarios> patchDocument)
        {
            if (patchDocument == null)
            {
                return BadRequest();
            }

            var usuarioFromDb = await _context.conf_usuarios.FindAsync(id);
            if (usuarioFromDb == null)
            {
                return NotFound();
            }

            patchDocument.ApplyTo(usuarioFromDb, (IObjectAdapter)ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
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

        private bool UsuarioExists(int id)
        {
            return _context.conf_usuarios.Any(e => e.id_usuario == id);
        }


        // POST: api/Usuarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<conf_usuarios>> Postconf_usuarios(conf_usuarios conf_usuarios)
        {
          if (_context.conf_usuarios == null)
          {
              return Problem("Entity set 'UsuariosDataModelContext.conf_usuarios'  is null.");
          }
            _context.conf_usuarios.Add(conf_usuarios);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getconf_usuarios", new { id = conf_usuarios.id_usuario }, conf_usuarios);
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteconf_usuarios(int id)
        {
            if (_context.conf_usuarios == null)
            {
                return NotFound();
            }
            var conf_usuarios = await _context.conf_usuarios.FindAsync(id);
            if (conf_usuarios == null)
            {
                return NotFound();
            }

            _context.conf_usuarios.Remove(conf_usuarios);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool conf_usuariosExists(int id)
        {
            return (_context.conf_usuarios?.Any(e => e.id_usuario == id)).GetValueOrDefault();
        }
    }
}
