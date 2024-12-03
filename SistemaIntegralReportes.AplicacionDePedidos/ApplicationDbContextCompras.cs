using Microsoft.EntityFrameworkCore;
using SistemaIntegralReportes.AplicacionDePedidos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace SistemaIntegralReportes.AplicacionDePedidos
{
    public class ApplicationDbContextCompras: DbContext
    {

        public ApplicationDbContextCompras(DbContextOptions<ApplicationDbContextCompras> options)
          : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<OrdenDeSolicitud>().Property(prop => prop.FechaDecreacion)
                .HasDefaultValueSql("GETDATE()");


        }

        public DbSet<Almacen> Almacen { get; set; }
        public DbSet<AreaDestino> AreaDestino { get; set; }
        public DbSet<CentroDeCosto> CentroDeCosto { get; set; }
        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<EstadoDeSolicitud> EstadoDeSolicitud { get; set; }
        public DbSet<LineaDeSolicitud> LineaDeSolicitud { get; set; }
        public DbSet<OrdenDeSolicitud> OrdenDeSolicitud { get; set; }
        public DbSet<PrioridadDeOrden> PrioridadDeOrden { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<RolDeUsuario> RolDeUsuario { get; set; }
        public DbSet<StockProducto> StockProducto { get; set; }
        public DbSet<TipoDeUnidad> TipoDeUnidad { get; set; }
        public DbSet<UbicacionDestino> UbicacionDestino { get; set; }
        public DbSet<UsuarioSolicitante> UsuarioSolicitante { get; set; }

    }
}
