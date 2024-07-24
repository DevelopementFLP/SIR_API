using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using _52_ControlUsuariosDataAccess;
using SistemaIntegralReportes.EntityModels;
using System.ComponentModel.DataAnnotations;

namespace SistemaIntegralReportes.Data
{
    public class PerfilesDbContext : DbContext
    {
        public PerfilesDbContext (DbContextOptions<PerfilesDbContext> options)
            : base(options)
        {
        
        }

        
        public DbSet<ConfAcceso> conf_accesos { get; set; }

        
        public DbSet<ConfModulo> conf_modulo { get; set; }

        
        public DbSet<Reporte> reportes { get; set; }

        public DbSet<_52_ControlUsuariosDataAccess.conf_perfiles> conf_perfiles { get; set; } = default!;
    }
}
