using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CRUD_TecnicaTest;

public partial class PruebaTecnicaContext : DbContext
{
    public PruebaTecnicaContext()
    {
    }

    public PruebaTecnicaContext(DbContextOptions<PruebaTecnicaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Lavadora> Lavadoras { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Category__3214EC0741215E3B");

            entity.ToTable("Category");

            entity.Property(e => e.NameCategory)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Lavadora>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Lavadora__3214EC073B09B2DF");

            entity.ToTable("Lavadora");

            entity.Property(e => e.Brand)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CategoryId).HasColumnName("Category_Id");

            entity.HasOne(d => d.Category).WithMany(p => p.Lavadoras)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_LavadoraToCategory");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
