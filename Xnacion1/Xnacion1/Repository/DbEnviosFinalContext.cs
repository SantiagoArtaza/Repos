using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Xnacion1.Repository;

public partial class DbEnviosFinalContext : DbContext
{
    public DbEnviosFinalContext()
    {
    }

    public DbEnviosFinalContext(DbContextOptions<DbEnviosFinalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TDetallesEnvio> TDetallesEnvios { get; set; }

    public virtual DbSet<TEnvio> TEnvios { get; set; }

    public virtual DbSet<TProducto> TProductos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=ABBYS\\SQLEXPRESS;Initial Catalog=db_envios_final;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TDetallesEnvio>(entity =>
        {
            entity.HasKey(e => new { e.IdEnvio, e.Detalle });

            entity.ToTable("T_Detalles_Envio");

            entity.Property(e => e.IdEnvio).HasColumnName("id_envio");
            entity.Property(e => e.Detalle).HasColumnName("detalle");
            entity.Property(e => e.Cantidad)
                .HasDefaultValue(1)
                .HasColumnName("cantidad");
            entity.Property(e => e.Comentario)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("comentario");
            entity.Property(e => e.IdProducto).HasColumnName("id_producto");

            entity.HasOne(d => d.IdEnvioNavigation).WithMany(p => p.TDetallesEnvios)
                .HasForeignKey(d => d.IdEnvio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_T_Detalles_Envio_T_Envios");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.TDetallesEnvios)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_T_Detalles_Envio_T_Productos");
        });

        modelBuilder.Entity<TEnvio>(entity =>
        {
            entity.ToTable("T_Envios");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.DniCliente)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("dniCliente");
            entity.Property(e => e.Estado)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValue("En preparación")
                .HasColumnName("estado");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.PalabraSecreta)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("palabraSecreta");
        });

        modelBuilder.Entity<TProducto>(entity =>
        {
            entity.HasKey(e => e.IdProducto);

            entity.ToTable("T_Productos");

            entity.Property(e => e.IdProducto).HasColumnName("id_producto");
            entity.Property(e => e.NProducto)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("n_producto");
            entity.Property(e => e.Precio).HasColumnName("precio");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
