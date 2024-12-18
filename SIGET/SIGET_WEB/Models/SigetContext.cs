using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SIGET_WEB.Models;

public partial class SigetContext : DbContext
{
    public SigetContext()
    {
    }

    public SigetContext(DbContextOptions<SigetContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Colaboradore> Colaboradores { get; set; }

    public virtual DbSet<Computadore> Computadores { get; set; }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-H4ENKIV\\SQLEXPRESS01;Database=SIGET;User Id=ES;Password=123;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Colaboradore>(entity =>
        {
            entity.HasKey(e => e.IdColaborador).HasName("PK__Colabora__AA9CB5D17E12F205");

            entity.Property(e => e.IdColaborador).HasColumnName("id_Colaborador");
            entity.Property(e => e.IdComputador).HasColumnName("id_Computador");
            entity.Property(e => e.IdDepartamento).HasColumnName("id_Departamento");
            entity.Property(e => e.IdPersona).HasColumnName("id_Persona");

            entity.HasOne(d => d.IdComputadorNavigation).WithMany(p => p.Colaboradores)
                .HasForeignKey(d => d.IdComputador)
                .HasConstraintName("FK__Colaborad__id_Co__5165187F");

            entity.HasOne(d => d.IdDepartamentoNavigation).WithMany(p => p.Colaboradores)
                .HasForeignKey(d => d.IdDepartamento)
                .HasConstraintName("FK__Colaborad__id_De__5070F446");

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.Colaboradores)
                .HasForeignKey(d => d.IdPersona)
                .HasConstraintName("FK__Colaborad__id_Pe__4F7CD00D");
        });

        modelBuilder.Entity<Computadore>(entity =>
        {
            entity.HasKey(e => e.IdComputador).HasName("PK__Computad__F31FDFDD0A0665DB");

            entity.Property(e => e.IdComputador).HasColumnName("id_Computador");
            entity.Property(e => e.Estado).HasMaxLength(20);
            entity.Property(e => e.Modelo).HasMaxLength(50);
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.IdDepartamento).HasName("PK__Departam__7177A3DDE9A65E95");

            entity.Property(e => e.IdDepartamento).HasColumnName("id_Departamento");
            entity.Property(e => e.Departamento1)
                .HasMaxLength(50)
                .HasColumnName("Departamento");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.IdPersona).HasName("PK__Personas__214BF527904D7EBD");

            entity.Property(e => e.IdPersona).HasColumnName("id_Persona");
            entity.Property(e => e.Apellido).HasMaxLength(50);
            entity.Property(e => e.CedulaPasaporte)
                .HasMaxLength(50)
                .HasColumnName("Cedula_Pasaporte");
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(100)
                .HasColumnName("Correo_Electronico");
            entity.Property(e => e.Direccion).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.Telefono).HasMaxLength(20);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuarios__8E901EAAB329D817");

            entity.Property(e => e.IdUsuario).HasColumnName("id_Usuario");
            entity.Property(e => e.IdColaborador).HasColumnName("id_Colaborador");
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Rol).HasMaxLength(50);
            entity.Property(e => e.Username).HasMaxLength(50);

            entity.HasOne(d => d.IdColaboradorNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdColaborador)
                .HasConstraintName("FK__Usuarios__id_Col__5441852A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
