using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MTControl.Models;

public partial class MtcontrolContext : DbContext
{
    public MtcontrolContext()
    {
    }

    public MtcontrolContext(DbContextOptions<MtcontrolContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Activity> Activities { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Image> Images { get; set; }

    public virtual DbSet<Profile> Profiles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConexionSQL");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Activity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ACTIVITY__3214EC0777503EB6");

            entity.ToTable("Activity");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Porcentaje).HasColumnType("decimal(5, 2)");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Category__3214EC0782976A7D");

            entity.ToTable("Category");

            entity.Property(e => e.IngresosBrutosCategoria).HasColumnType("decimal(16, 2)");
            entity.Property(e => e.Letra)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PrecioMaximoUnitario).HasColumnType("decimal(16, 2)");
        });

        modelBuilder.Entity<Image>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Image__3214EC07E89BD8BA");

            entity.ToTable("Image");

            entity.Property(e => e.Alt)
                .HasMaxLength(50)
                .HasColumnName("alt");
            entity.Property(e => e.Src).HasColumnName("src");
            entity.Property(e => e.Url).HasColumnName("url");
        });

        modelBuilder.Entity<Profile>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__Profile__06370DAD7A7B6ABD");

            entity.ToTable("Profile");

            entity.Property(e => e.ActividadId).HasColumnName("Actividad_id");
            entity.Property(e => e.CategoriaId).HasColumnName("Categoria_Id");
            entity.Property(e => e.Compras).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Cuit)
                .HasMaxLength(11)
                .IsUnicode(false);
            entity.Property(e => e.Iibb).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.RazonSocial)
                .HasMaxLength(50)
                .IsFixedLength();

            entity.HasOne(d => d.Actividad).WithMany(p => p.Profiles)
                .HasForeignKey(d => d.ActividadId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Profile_ACTIVITY");

            entity.HasOne(d => d.Categoria).WithMany(p => p.Profiles)
                .HasForeignKey(d => d.CategoriaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Profile_Category");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
