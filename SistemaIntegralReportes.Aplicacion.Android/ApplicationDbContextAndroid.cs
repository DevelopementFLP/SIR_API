using Microsoft.EntityFrameworkCore;
using SistemaIntegralReportes.Aplicacion.Android.Entidades.Incidente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaIntegralReportes.Aplicacion.Android
{
    public class ApplicationDbContextAndroid: DbContext
    {
        public ApplicationDbContextAndroid(DbContextOptions<ApplicationDbContextAndroid> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Incidente>().Property(prop => prop.FechaDeRegistro)
                .HasDefaultValueSql("GETDATE()");

        }

        public DbSet<Incidente> Incidente { get; set; }
        public DbSet<TipoDeIncidente> TipoDeIncidente { get; set; }
        public DbSet<SectorDeIncidente> SectorDeIncidente { get; set; }
    }
}
