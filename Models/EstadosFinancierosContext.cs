using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RazonesFinancieras.Models;

public partial class EstadosFinancierosContext : DbContext
{
    public EstadosFinancierosContext()
    {
    }

    public EstadosFinancierosContext(DbContextOptions<EstadosFinancierosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Activo> Activos { get; set; }

    public virtual DbSet<Capital> Capitals { get; set; }

    public virtual DbSet<Costo> Costos { get; set; }

    public virtual DbSet<Gasto> Gastos { get; set; }

    public virtual DbSet<OtrosIngreso> OtrosIngresos { get; set; }

    public virtual DbSet<Pasivo> Pasivos { get; set; }

    public virtual DbSet<Venta> Ventas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=EstadosFinancieroDB;Trusted_Connection=True;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Activo>(entity =>
        {
            entity.HasKey(e => e.IdActivo).HasName("PK__Activos__146481C0A022CD88");

            entity.Property(e => e.Clasificacion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NombreCuenta)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Valor).HasColumnType("decimal(15, 2)");
        });

        modelBuilder.Entity<Capital>(entity =>
        {
            entity.HasKey(e => e.IdCapital).HasName("PK__Capital__679E7E7847AE73FB");

            entity.ToTable("Capital");

            entity.Property(e => e.Clasificacion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NombreCuenta)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Valor).HasColumnType("decimal(15, 2)");
        });

        modelBuilder.Entity<Costo>(entity =>
        {
            entity.HasKey(e => e.IdCosto).HasName("PK__Costos__D5D3CEA35C3B453B");

            entity.Property(e => e.Clasificacion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NombreCuenta)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Valor).HasColumnType("decimal(15, 2)");
        });

        modelBuilder.Entity<Gasto>(entity =>
        {
            entity.HasKey(e => e.IdGasto).HasName("PK__Gastos__C630244D0FED2A84");

            entity.Property(e => e.Clasificacion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NombreCuenta)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Valor).HasColumnType("decimal(15, 2)");
        });

        modelBuilder.Entity<OtrosIngreso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OtrosIng__3214EC074E61CE23");

            entity.Property(e => e.Clasificacion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.NombreCuenta)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Valor).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Pasivo>(entity =>
        {
            entity.HasKey(e => e.IdPasivo).HasName("PK__Pasivos__EFB62CF3B3CC3587");

            entity.Property(e => e.Clasificacion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NombreCuenta)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Valor).HasColumnType("decimal(15, 2)");
        });

        modelBuilder.Entity<Venta>(entity =>
        {
            entity.HasKey(e => e.IdVenta).HasName("PK__Ventas__BC1240BD3B4C9662");

            entity.Property(e => e.Clasificacion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NombreCuenta)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Valor).HasColumnType("decimal(15, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
