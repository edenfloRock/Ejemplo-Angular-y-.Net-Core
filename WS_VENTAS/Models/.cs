using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WS_VENTAS.Models
{
    public partial class MVC_SEGURIDADContext : DbContext
    {
        public MVC_SEGURIDADContext()
        {
        }

        public MVC_SEGURIDADContext(DbContextOptions<MVC_SEGURIDADContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Animal> Animal { get; set; }
        public virtual DbSet<CestatusUsuario> CestatusUsuario { get; set; }
        public virtual DbSet<ClaseAnimal> ClaseAnimal { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<Venta> Venta { get; set; }
        public virtual DbSet<VentaDetalle> VentaDetalle { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=EDENFLO-DELL\\EDENFLO_PRO;Database=MVC_SEGURIDAD;User=SA;Password=Bicodes1$;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>(entity =>
            {
                entity.HasKey(e => e.IdAnimal);

                entity.ToTable("ANIMAL");

                entity.Property(e => e.IdAnimal).HasColumnName("ID_ANIMAL");

                entity.Property(e => e.DescAnimal)
                    .HasColumnName("DESC_ANIMAL")
                    .HasMaxLength(50);

                entity.Property(e => e.IdClase).HasColumnName("ID_CLASE");

                entity.HasOne(d => d.IdClaseNavigation)
                    .WithMany(p => p.Animal)
                    .HasForeignKey(d => d.IdClase)
                    .HasConstraintName("FK_ANIMAL_CLASE");
            });

            modelBuilder.Entity<CestatusUsuario>(entity =>
            {
                entity.HasKey(e => e.IdEstatusUsuario)
                    .HasName("PK_ESTATUS");

                entity.ToTable("CESTATUS_USUARIO");

                entity.Property(e => e.IdEstatusUsuario).HasColumnName("ID_ESTATUS_USUARIO");

                entity.Property(e => e.DescEstatus)
                    .HasColumnName("DESC_ESTATUS")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<ClaseAnimal>(entity =>
            {
                entity.HasKey(e => e.IdClase);

                entity.ToTable("CLASE_ANIMAL");

                entity.Property(e => e.IdClase).HasColumnName("ID_CLASE");

                entity.Property(e => e.DescClase)
                    .HasColumnName("DESC_CLASE")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("CLIENTE_PK");

                entity.ToTable("CLIENTE");

                entity.Property(e => e.IdCliente).HasColumnName("ID_CLIENTE");

                entity.Property(e => e.NombreCliente)
                    .IsRequired()
                    .HasColumnName("NOMBRE_CLIENTE")
                    .HasMaxLength(80);
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto)
                    .HasName("PRODUCTO_PK");

                entity.ToTable("PRODUCTO");

                entity.Property(e => e.IdProducto).HasColumnName("ID_PRODUCTO");

                entity.Property(e => e.Costo)
                    .HasColumnName("COSTO")
                    .HasColumnType("money");

                entity.Property(e => e.DescProducto)
                    .IsRequired()
                    .HasColumnName("DESC_PRODUCTO")
                    .HasMaxLength(50);

                entity.Property(e => e.PrecioUnitario)
                    .HasColumnName("PRECIO_UNITARIO")
                    .HasColumnType("money");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.ToTable("USUARIOS");

                entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");

                entity.Property(e => e.Edad).HasColumnName("EDAD");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasMaxLength(50);

                entity.Property(e => e.IdEstatusUsuario).HasColumnName("ID_ESTATUS_USUARIO");

                entity.Property(e => e.Pwd)
                    .IsRequired()
                    .HasColumnName("PWD")
                    .HasMaxLength(100);

                entity.HasOne(d => d.IdEstatusUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdEstatusUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ESTATUS_USUARIOS");
            });

            modelBuilder.Entity<Venta>(entity =>
            {
                entity.HasKey(e => e.IdVenta)
                    .HasName("VENTA_PK");

                entity.ToTable("VENTA");

                entity.Property(e => e.IdVenta).HasColumnName("ID_VENTA");

                entity.Property(e => e.FechaVenta)
                    .HasColumnName("FECHA_VENTA")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.IdCliente).HasColumnName("ID_CLIENTE");

                entity.Property(e => e.ImporteTotal)
                    .HasColumnName("IMPORTE_TOTAL")
                    .HasColumnType("money");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CLIENTE_VENTA");
            });

            modelBuilder.Entity<VentaDetalle>(entity =>
            {
                entity.HasKey(e => e.IdVentaDetalle)
                    .HasName("VENTA_DETALLE_PK");

                entity.ToTable("VENTA_DETALLE");

                entity.Property(e => e.IdVentaDetalle).HasColumnName("ID_VENTA_DETALLE");

                entity.Property(e => e.Cantidad)
                    .HasColumnName("CANTIDAD")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.IdProducto).HasColumnName("ID_PRODUCTO");

                entity.Property(e => e.IdVenta).HasColumnName("ID_VENTA");

                entity.Property(e => e.ImporteTotal)
                    .HasColumnName("IMPORTE_TOTAL")
                    .HasColumnType("money");

                entity.Property(e => e.PrecioUnitario)
                    .HasColumnName("PRECIO_UNITARIO")
                    .HasColumnType("money");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.VentaDetalle)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRODUCTO_VENTA_DETALLE");

                entity.HasOne(d => d.IdVentaNavigation)
                    .WithMany(p => p.VentaDetalle)
                    .HasForeignKey(d => d.IdVenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("VENTA_VENTA_DETALLE_FK1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
