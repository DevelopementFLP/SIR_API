using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using _52_ControlUsuariosDataAccess;

    public class UsuariosDataModelContext : DbContext
    {
        public UsuariosDataModelContext (DbContextOptions<UsuariosDataModelContext> options)
            : base(options)
        {
        }

        public DbSet<_52_ControlUsuariosDataAccess.conf_usuarios> conf_usuarios { get; set; } = default!;

        public DbSet<_52_ControlUsuariosDataAccess.conf_accesos>? conf_accesos { get; set; }
    }
