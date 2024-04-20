using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AlquilerVehiculos.Models;

public partial class AlquilerVehiculosContext : DbContext
{
    public AlquilerVehiculosContext()
    {
    }

    public AlquilerVehiculosContext(DbContextOptions<AlquilerVehiculosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alquiler> Alquilers { get; set; }

    public virtual DbSet<Carro> Carros { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Pago> Pagos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-G91IR6R\\SQLEXPRESS;Initial Catalog=alquiler_vehiculos;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alquiler>(entity =>
        {
            entity.HasKey(e => e.IdAlquiler).HasName("PK__alquiler__329FC755D75B43D2");

            entity.ToTable("alquiler");

            entity.Property(e => e.IdAlquiler).HasColumnName("id_alquiler");
            entity.Property(e => e.AbonoInicial)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("abono_inicial");
            entity.Property(e => e.Devuelto)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasDefaultValueSql("('no')")
                .HasColumnName("devuelto");
            entity.Property(e => e.Fecha)
                .HasColumnType("date")
                .HasColumnName("fecha");
            entity.Property(e => e.IdCarro).HasColumnName("id_carro");
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.Saldo)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("saldo");
            entity.Property(e => e.Tiempo).HasColumnName("tiempo");
            entity.Property(e => e.ValorTotal)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("valor_total");

            entity.HasOne(d => d.IdCarroNavigation).WithMany(p => p.Alquilers)
                .HasForeignKey(d => d.IdCarro)
                .HasConstraintName("fk_alquiler_carro");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Alquilers)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("fk_alquiler_cliente");
        });

        modelBuilder.Entity<Carro>(entity =>
        {
            entity.HasKey(e => e.IdCarro).HasName("PK__carro__D3C318A106BC42B1");

            entity.ToTable("carro");

            entity.HasIndex(e => e.Placa, "UQ__carro__0C05742594E3C449").IsUnique();

            entity.Property(e => e.IdCarro).HasColumnName("id_carro");
            entity.Property(e => e.Costo)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("costo");
            entity.Property(e => e.Disponible)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasDefaultValueSql("('si')")
                .HasColumnName("disponible");
            entity.Property(e => e.Marca)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("marca");
            entity.Property(e => e.Modelo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("modelo");
            entity.Property(e => e.Placa)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("placa");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__cliente__677F38F52F7846E2");

            entity.ToTable("cliente");

            entity.HasIndex(e => e.Cedula, "UQ__cliente__415B7BE565E0C118").IsUnique();

            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.Cedula)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("cedula");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefono1");
            entity.Property(e => e.Telefono2)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefono2");
        });

        modelBuilder.Entity<Pago>(entity =>
        {
            entity.HasKey(e => e.IdPago).HasName("PK__pagos__0941B074FCE1EC5C");

            entity.ToTable("pagos");

            entity.Property(e => e.IdPago).HasColumnName("id_pago");
            entity.Property(e => e.Fecha)
                .HasColumnType("date")
                .HasColumnName("fecha");
            entity.Property(e => e.IdAlquiler).HasColumnName("id_alquiler");
            entity.Property(e => e.Valor)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("valor");

            entity.HasOne(d => d.IdAlquilerNavigation).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.IdAlquiler)
                .HasConstraintName("fk_pagos_alquiler");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
