using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace APIDepilacion.Models;

public partial class BdDepilacionContext : DbContext
{
    public BdDepilacionContext()
    {
    }

    public BdDepilacionContext(DbContextOptions<BdDepilacionContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Clientes> Clientes { get; set; }

    public virtual DbSet<Potencias> Potencias { get; set; }

    public virtual DbSet<Sesione> Sesiones { get; set; }

    public virtual DbSet<Turno> Turnos { get; set; }

    public virtual DbSet<Zonas> Zonas { get; set; }

   // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warn//ing To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
       // => optionsBuilder.UseSqlServer("Server=DESKTOP-FDT6O7F;Database=BD_Depilacion;User Id=sa;Password=esea;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Clientes>(entity =>
        {
            entity.HasKey(e => e.IdCliente);

            entity.Property(e => e.IdCliente).HasColumnName("ID_Cliente");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Potencias>(entity =>
        {
            entity.HasKey(e => e.IdPotencias);

            entity.Property(e => e.IdPotencias).HasColumnName("ID_Potencias");
            entity.Property(e => e.ValorPotencia)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Sesione>(entity =>
        {
            entity.HasKey(e => e.IdSesiones);

            entity.Property(e => e.IdSesiones).HasColumnName("ID_Sesiones");
            entity.Property(e => e.IdCliente).HasColumnName("ID_Cliente");
            entity.Property(e => e.IdZona).HasColumnName("ID_Zona");
            entity.Property(e => e.Potencia)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Sesion)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Turno>(entity =>
        {
            entity.HasKey(e => e.IdTurno);

            entity.ToTable("Turno");

            entity.Property(e => e.IdTurno).HasColumnName("ID_Turno");
            entity.Property(e => e.Dia).HasColumnType("date");
            entity.Property(e => e.Hora).HasColumnType("date");
            entity.Property(e => e.IdCliente).HasColumnName("ID_Cliente");
        });

        modelBuilder.Entity<Zonas>(entity =>
        {
            entity.HasKey(e => e.IdZona);

            entity.Property(e => e.IdZona).HasColumnName("ID_Zona");
            entity.Property(e => e.Zona1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Zona");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
