using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CIE.WebApp.Data;

public partial class CiedbContext : DbContext
{
    public CiedbContext()
    {
    }

    public CiedbContext(DbContextOptions<CiedbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CategoriaEnfermedad> CategoriaEnfermedads { get; set; }

    public virtual DbSet<Cie09> Cie09s { get; set; }

    public virtual DbSet<Cie10> Cie10s { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:CIEDB");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CategoriaEnfermedad>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_CategoriaEnfermedadId");
        });

        modelBuilder.Entity<Cie09>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_CIE09Id");
        });

        modelBuilder.Entity<Cie10>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Id");

            entity.HasOne(d => d.CategoriaEnfermedad).WithMany(p => p.Cie10s).HasConstraintName("FK_CategoriaEnfermedadId");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
