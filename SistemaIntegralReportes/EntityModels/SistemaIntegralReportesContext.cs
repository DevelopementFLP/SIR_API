using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SistemaIntegralReportes.EntityModels
{
    public partial class SistemaIntegralReportesContext : DbContext
    {
        public SistemaIntegralReportesContext()
        {
        }

        public SistemaIntegralReportesContext(DbContextOptions<SistemaIntegralReportesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ConfAcceso> ConfAccesos { get; set; } = null!;
        public virtual DbSet<ConfModulo> ConfModulos { get; set; } = null!;
        public virtual DbSet<ConfPerfile> ConfPerfiles { get; set; } = null!;
        public virtual DbSet<ConfUsuario> ConfUsuarios { get; set; } = null!;
        public virtual DbSet<Reporte> Reportes { get; set; } = null!;
        public virtual DbSet<PCC> PCCs { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConfAcceso>(entity =>
            {
                entity.HasKey(e => new { e.IdAcceso, e.IdModulo, e.IdPerfil });

                entity.ToTable("conf_accesos");

                entity.Property(e => e.IdAcceso)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id_acceso");

                entity.Property(e => e.IdModulo).HasColumnName("id_modulo");

                entity.Property(e => e.IdPerfil).HasColumnName("id_perfil");

                entity.Property(e => e.Permitido).HasColumnName("permitido");

                entity.HasOne(d => d.IdModuloNavigation)
                    .WithMany(p => p.ConfAccesos)
                    .HasForeignKey(d => d.IdModulo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_conf_accesos_conf_modulo");

                entity.HasOne(d => d.IdPerfilNavigation)
                    .WithMany(p => p.ConfAccesos)
                    .HasForeignKey(d => d.IdPerfil)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_conf_accesos_conf_perfiles");
            });

            modelBuilder.Entity<ConfModulo>(entity =>
            {
                entity.HasKey(e => e.IdModulo);

                entity.ToTable("conf_modulo");

                entity.Property(e => e.IdModulo).HasColumnName("id_modulo");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Icono)
                    .HasMaxLength(50)
                    .HasColumnName("icono")
                    .IsFixedLength();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .HasColumnName("nombre")
                    .IsFixedLength();

                entity.Property(e => e.RouteLink)
                    .HasMaxLength(50)
                    .HasColumnName("routerLink")
                    .IsFixedLength();
            });

            modelBuilder.Entity<ConfPerfile>(entity =>
            {
                entity.HasKey(e => e.IdPerfil);

                entity.ToTable("conf_perfiles");

                entity.Property(e => e.IdPerfil).HasColumnName("id_perfil");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.NombrePerfil)
                    .HasMaxLength(50)
                    .HasColumnName("nombre_perfil");
            });

            modelBuilder.Entity<ConfUsuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.ToTable("conf_usuarios");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Contrasenia)
                    .HasMaxLength(50)
                    .HasColumnName("contrasenia");

                entity.Property(e => e.IdPerfil).HasColumnName("id_perfil");

                entity.Property(e => e.NombreCompleto)
                    .HasMaxLength(100)
                    .HasColumnName("nombre_completo");

                entity.Property(e => e.NombreUsuario)
                    .HasMaxLength(50)
                    .HasColumnName("nombre_usuario");

                entity.HasOne(d => d.IdPerfilNavigation)
                    .WithMany(p => p.ConfUsuarios)
                    .HasForeignKey(d => d.IdPerfil)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_conf_usuarios_conf_perfiles");
            });

            modelBuilder.Entity<Reporte>(entity =>
            {
                entity.HasKey(e => e.IdReporte)
                    .HasName("PK_dbo.reportes");

                entity.ToTable("conf_reportes");

                entity.Property(e => e.IdReporte).HasColumnName("id_reporte");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Icono)
                    .HasMaxLength(50)
                    .HasColumnName("icono")
                    .IsFixedLength();

                entity.Property(e => e.IdModulo).HasColumnName("id_modulo");

                entity.Property(e => e.NombreReporte)
                    .HasMaxLength(50)
                    .HasColumnName("nombre_reporte")
                    .IsFixedLength();

                entity.Property(e => e.RouterLink)
                    .HasMaxLength(50)
                    .HasColumnName("routerLink")
                    .IsFixedLength();

                entity.Property(e => e.Target)
                    .HasMaxLength(50)
                    .HasColumnName("target")
                    .IsFixedLength();
            });

            modelBuilder.Entity<PCC>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK_dbo.pcc");

                entity.ToTable("qa_pcc");

                entity.Property(e => e.Especie)
                   .HasMaxLength(10)
                   .HasColumnName("especie")
                   .IsFixedLength();

                entity.Property(e => e.HoraInicioFaena).HasColumnName("horario_inicio_faena");

                entity.Property(e => e.HorarioPcc)
                   .HasMaxLength(10)
                   .HasColumnName("horario_pcc")
                   .IsFixedLength();

                entity.Property(e => e.NumeroPcc).HasColumnName("numero_pcc");


            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
