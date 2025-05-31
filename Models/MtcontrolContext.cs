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

    public virtual DbSet<Image> Images { get; set; }

    public virtual DbSet<Profile> Profiles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseSqlServer();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
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

            entity.Property(e => e.Compras).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Iibb).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.RazonSocial)
                .HasMaxLength(50)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
