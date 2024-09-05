
using Microsoft.EntityFrameworkCore;
using SistemaIntegralReportes.Models.Dispositivos;
using SistemaIntegralReportes.Servicios.Contrato;
using Microsoft.EntityFrameworkCore.Metadata;


namespace SistemaIntegralReportes.Repositorio.DBContext
{
    public partial class DBcontexBD : DbContext
    {
        public DBcontexBD()
        {
        }

        public DBcontexBD(DbContextOptions<DBcontexBD> options)
        : base(options)
        {

        }

        public virtual DbSet<Dispositivos> Dispositivos { get; set; } = null!;
        public virtual DbSet<Formateos> Formateos { get; set; } = null!;
        public virtual DbSet<Lecturas> Lecturas { get; set; } = null!;
        public virtual DbSet<TipoDispositivos> TipoDispositivos { get; set; } = null!;
        public virtual DbSet<UbicacionesDispositivos> UbicacionesDispositivos { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Dispositivos>(entity =>
            {               
                entity.HasKey(e => e.IdDispositivo);

                entity.ToTable("cc_dispositivos");

                entity.Property(e => e.IdDispositivo).HasColumnName("id_dispositivo");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasColumnName("activo")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Descripcion).HasColumnName("descripcion");

                entity.Property(e => e.IdFormato).HasColumnName("id_formato");

                entity.Property(e => e.IdTipo).HasColumnName("id_tipo");

                entity.Property(e => e.IdUbicacion).HasColumnName("id_ubicacion");

                entity.Property(e => e.Ip)
                    .HasMaxLength(15)
                    .HasColumnName("ip");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .HasColumnName("nombre");

                entity.Property(e => e.Puerto).HasColumnName("puerto");

                entity.HasOne(d => d.IdFormatoNavigation)
                    .WithMany(p => p.Dispositivos)
                    .HasForeignKey(d => d.IdFormato)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Dispositivos_Formateos");

                entity.HasOne(d => d.IdTipoNavigation)
                    .WithMany(p => p.Dispositivos)
                    .HasForeignKey(d => d.IdTipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Dispositivos_Tipo_Dispositivo");

                entity.HasOne(d => d.IdUbicacionNavigation)
                    .WithMany(p => p.Dispositivos)
                    .HasForeignKey(d => d.IdUbicacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Dispositivos_Ubicaciones");
            });

            modelBuilder.Entity<Formateos>(entity =>
            {
                entity.HasKey(e => e.IdFormato)
                    .HasName("PK_Formateos");

                entity.ToTable("cc_formateos");

                entity.Property(e => e.IdFormato).HasColumnName("id_formato");

                entity.Property(e => e.ErrorLectura)
                    .HasMaxLength(50)
                    .HasColumnName("error_lectura");

                entity.Property(e => e.SubstringDesde).HasColumnName("substring_desde");

                entity.Property(e => e.SubstringHasta).HasColumnName("substring_hasta");
            });

            modelBuilder.Entity<Lecturas>(entity =>
            {
                entity.HasKey(e => e.IdLectura)
                    .HasName("PK_Lecturas");

                entity.ToTable("cc_lecturas");

                entity.Property(e => e.IdLectura).HasColumnName("id_lectura");

                entity.Property(e => e.FechaHora)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_hora");

                entity.Property(e => e.IdDispositivo).HasColumnName("id_dispositivo");

                entity.Property(e => e.Mensaje)
                    .HasMaxLength(200)
                    .HasColumnName("mensaje");

                entity.HasOne(d => d.IdDispositivoNavigation)
                    .WithMany(p => p.Lecturas)
                    .HasForeignKey(d => d.IdDispositivo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Lecturas_Dispositivos");
            });

            modelBuilder.Entity<TipoDispositivos>(entity =>
            {
                entity.HasKey(e => e.IdTipo);

                entity.ToTable("cc_tipo_dispositivo");

                entity.Property(e => e.IdTipo).HasColumnName("id_tipo");

                entity.Property(e => e.ComandoFin)
                    .HasMaxLength(50)
                    .HasColumnName("comando_fin");

                entity.Property(e => e.ComandoInicio)
                    .HasMaxLength(50)
                    .HasColumnName("comando_inicio");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<UbicacionesDispositivos>(entity =>
            {
                entity.HasKey(e => e.IdUbicacion);

                entity.ToTable("cc_ubicaciones");

                entity.Property(e => e.IdUbicacion).HasColumnName("id_ubicacion");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .HasColumnName("nombre");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
