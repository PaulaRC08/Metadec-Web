using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MetadecBackEnd.Domain.Models;

public partial class MetadecudecContext : DbContext
{

    public MetadecudecContext(DbContextOptions<MetadecudecContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MdDocente> MdDocentes { get; set; }

    public virtual DbSet<MdEncuestum> MdEncuesta { get; set; }

    public virtual DbSet<MdEstudiante> MdEstudiantes { get; set; }

    public virtual DbSet<MdHipervinculo> MdHipervinculos { get; set; }

    public virtual DbSet<MdInstitucion> MdInstitucions { get; set; }

    public virtual DbSet<MdInstitucionPrograma> MdInstitucionProgramas { get; set; }

    public virtual DbSet<MdPai> MdPais { get; set; }

    public virtual DbSet<MdPrograma> MdProgramas { get; set; }

    public virtual DbSet<MdReporte> MdReportes { get; set; }

    public virtual DbSet<MdSesion> MdSesions { get; set; }

    public virtual DbSet<MdSesionUsuario> MdSesionUsuarios { get; set; }

    public virtual DbSet<MdUsuario> MdUsuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MdDocente>(entity =>
        {
            entity.HasKey(e => e.IdDocente).HasName("PK_MD_DOCENTES");

            entity.ToTable("MD_DOCENTE");

            entity.Property(e => e.IdDocente).HasColumnName("ID_DOCENTE");
            entity.Property(e => e.IdInstitucion).HasColumnName("ID_INSTITUCION");
            entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");

            entity.HasOne(d => d.IdInstitucionNavigation).WithMany(p => p.MdDocentes)
                .HasForeignKey(d => d.IdInstitucion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MD_DOCENTES_MD_INSTITUCIONES");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.MdDocentes)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MD_DOCENTES_MD_USUARIOS");
        });

        modelBuilder.Entity<MdEncuestum>(entity =>
        {
            entity.HasKey(e => e.IdEncuesta).HasName("PK_MD_ENCUESTAS");

            entity.ToTable("MD_ENCUESTA");

            entity.Property(e => e.IdEncuesta).HasColumnName("ID_ENCUESTA");
            entity.Property(e => e.IdSesionUsuario).HasColumnName("ID_SESION_USUARIO");
            entity.Property(e => e.Pregunta1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("PREGUNTA_1");
            entity.Property(e => e.Pregunta2)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("PREGUNTA_2");
            entity.Property(e => e.Pregunta3)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("PREGUNTA_3");
            entity.Property(e => e.Pregunta4)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("PREGUNTA_4");
            entity.Property(e => e.Pregunta5)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("PREGUNTA_5");

            entity.HasOne(d => d.IdSesionUsuarioNavigation).WithMany(p => p.MdEncuesta)
                .HasForeignKey(d => d.IdSesionUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MD_ENCUESTAS_MD_SESIONES_USUARIOS");
        });

        modelBuilder.Entity<MdEstudiante>(entity =>
        {
            entity.HasKey(e => e.IdEstudiante);

            entity.ToTable("MD_ESTUDIANTE");

            entity.Property(e => e.IdEstudiante).HasColumnName("ID_ESTUDIANTE");
            entity.Property(e => e.IdInstitucionPrograma).HasColumnName("ID_INSTITUCION_PROGRAMA");
            entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");

            entity.HasOne(d => d.IdInstitucionProgramaNavigation).WithMany(p => p.MdEstudiantes)
                .HasForeignKey(d => d.IdInstitucionPrograma)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MD_ESTUDIANTES_MD_INSTITUCION_PROGRAMAS");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.MdEstudiantes)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MD_ESTUDIANTES_MD_USUARIOS1");
        });

        modelBuilder.Entity<MdHipervinculo>(entity =>
        {
            entity.HasKey(e => e.IdHipervinculo).HasName("PK_MD_HIPERVINCULOS");

            entity.ToTable("MD_HIPERVINCULO");

            entity.Property(e => e.IdHipervinculo).HasColumnName("ID_HIPERVINCULO");
            entity.Property(e => e.IdSesion).HasColumnName("ID_SESION");
            entity.Property(e => e.NombreHipervinculo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_HIPERVINCULO");
            entity.Property(e => e.TipoHipervinculo)
                .HasMaxLength(20)
                .HasColumnName("TIPO_HIPERVINCULO");
            entity.Property(e => e.UrlHpervinculo)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("URL_HPERVINCULO");

            entity.HasOne(d => d.IdSesionNavigation).WithMany(p => p.MdHipervinculos)
                .HasForeignKey(d => d.IdSesion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MD_HIPERVINCULOS_MD_SESIONES");
        });

        modelBuilder.Entity<MdInstitucion>(entity =>
        {
            entity.HasKey(e => e.IdInstitucion).HasName("PK_MD_INSTITUCIONES");

            entity.ToTable("MD_INSTITUCION");

            entity.Property(e => e.IdInstitucion).HasColumnName("ID_INSTITUCION");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("FECHA_CREACION");
            entity.Property(e => e.IdPais).HasColumnName("ID_PAIS");
            entity.Property(e => e.NombreInstitucion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_INSTITUCION");

            entity.HasOne(d => d.IdPaisNavigation).WithMany(p => p.MdInstitucions)
                .HasForeignKey(d => d.IdPais)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MD_INSTITUCIONES_MD_PAISES");
        });

        modelBuilder.Entity<MdInstitucionPrograma>(entity =>
        {
            entity.HasKey(e => e.IdInstitucionPrograma);

            entity.ToTable("MD_INSTITUCION_PROGRAMA");

            entity.Property(e => e.IdInstitucionPrograma).HasColumnName("ID_INSTITUCION_PROGRAMA");
            entity.Property(e => e.IdInstitucion).HasColumnName("ID_INSTITUCION");
            entity.Property(e => e.IdPrograma).HasColumnName("ID_PROGRAMA");

            entity.HasOne(d => d.IdInstitucionNavigation).WithMany(p => p.MdInstitucionProgramas)
                .HasForeignKey(d => d.IdInstitucion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MD_INSTITUCION_PROGRAMAS_MD_INSTITUCIONES");

            entity.HasOne(d => d.IdProgramaNavigation).WithMany(p => p.MdInstitucionProgramas)
                .HasForeignKey(d => d.IdPrograma)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MD_INSTITUCION_PROGRAMAS_MD_PROGRAMAS");
        });

        modelBuilder.Entity<MdPai>(entity =>
        {
            entity.HasKey(e => e.IdPais).HasName("PK_MD_PAISES");

            entity.ToTable("MD_PAIS");

            entity.Property(e => e.IdPais).HasColumnName("ID_PAIS");
            entity.Property(e => e.CodigoPais)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("CODIGO_PAIS");
            entity.Property(e => e.Latitud)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("LATITUD");
            entity.Property(e => e.Longitud)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("LONGITUD");
            entity.Property(e => e.Pais)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("PAIS");
        });

        modelBuilder.Entity<MdPrograma>(entity =>
        {
            entity.HasKey(e => e.IdPrograma).HasName("PK_MD_PROGRAMAS");

            entity.ToTable("MD_PROGRAMA");

            entity.Property(e => e.IdPrograma).HasColumnName("ID_PROGRAMA");
            entity.Property(e => e.Programa)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("PROGRAMA");
        });

        modelBuilder.Entity<MdReporte>(entity =>
        {
            entity.HasKey(e => e.IdReporte).HasName("PK_MD_REPORTES");

            entity.ToTable("MD_REPORTE");

            entity.Property(e => e.IdReporte).HasColumnName("ID_REPORTE");
            entity.Property(e => e.Amenaza).HasColumnName("AMENAZA");
            entity.Property(e => e.ComportIrrespetuoso).HasColumnName("COMPORT_IRRESPETUOSO");
            entity.Property(e => e.ComunicacionOfensiva).HasColumnName("COMUNICACION_OFENSIVA");
            entity.Property(e => e.Penalizacion)
                .HasColumnType("text")
                .HasColumnName("PENALIZACION");
            entity.Property(e => e.DescripcionReporte)
                .HasColumnType("text")
                .HasColumnName("DESCRIPCION_REPORTE");
            entity.Property(e => e.FechaReporte)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_REPORTE");
            entity.Property(e => e.IdDocenteAtendio).HasColumnName("ID_DOCENTE_ATENDIO");
            entity.Property(e => e.IdUsuarioReportado).HasColumnName("ID_USUARIO_REPORTADO");
            entity.Property(e => e.IdUsuarioReporto).HasColumnName("ID_USUARIO_REPORTO");
            entity.Property(e => e.NombreOfensivo).HasColumnName("NOMBRE_OFENSIVO");
            entity.Property(e => e.ReporteActivo).HasColumnName("REPORTE_ACTIVO");

            entity.HasOne(d => d.IdDocenteAtendioNavigation).WithMany(p => p.MdReporteIdDocenteAtendioNavigations)
                .HasForeignKey(d => d.IdDocenteAtendio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MD_REPORTES_MD_USUARIOS2");

            entity.HasOne(d => d.IdUsuarioReportadoNavigation).WithMany(p => p.MdReporteIdUsuarioReportadoNavigations)
                .HasForeignKey(d => d.IdUsuarioReportado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MD_REPORTES_MD_USUARIOS");

            entity.HasOne(d => d.IdUsuarioReportoNavigation).WithMany(p => p.MdReporteIdUsuarioReportoNavigations)
                .HasForeignKey(d => d.IdUsuarioReporto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MD_REPORTES_MD_USUARIOS1");
        });

        modelBuilder.Entity<MdSesion>(entity =>
        {
            entity.HasKey(e => e.IdSesion).HasName("PK_MD_SESIONES");

            entity.ToTable("MD_SESION");

            entity.Property(e => e.IdSesion).HasColumnName("ID_SESION");
            entity.Property(e => e.Clase)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CLASE");
            entity.Property(e => e.CodigoSesion)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("CODIGO_SESION");
            entity.Property(e => e.FechaSesion)
                .HasColumnType("date")
                .HasColumnName("FECHA_SESION");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("PASSWORD");
            entity.Property(e => e.SesionRealizada).HasColumnName("SESION_REALIZADA");
        });

        modelBuilder.Entity<MdSesionUsuario>(entity =>
        {
            entity.HasKey(e => e.IdSesionUsuarios).HasName("PK_MD_SESIONES_USUARIOS");

            entity.ToTable("MD_SESION_USUARIO");

            entity.Property(e => e.IdSesionUsuarios).HasColumnName("ID_SESION_USUARIOS");
            entity.Property(e => e.ClientMaster).HasColumnName("CLIENT_MASTER");
            entity.Property(e => e.IdSesion).HasColumnName("ID_SESION");
            entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");

            entity.HasOne(d => d.IdSesionNavigation).WithMany(p => p.MdSesionUsuarios)
                .HasForeignKey(d => d.IdSesion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MD_SESIONES_USUARIOS_MD_SESIONES");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.MdSesionUsuarios)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MD_SESIONES_USUARIOS_MD_USUARIOS");
        });

        modelBuilder.Entity<MdUsuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK_MD_USUARIOS");

            entity.ToTable("MD_USUARIO");

            entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");
            entity.Property(e => e.ActivoJuego).HasColumnName("ACTIVO_JUEGO");
            entity.Property(e => e.TratamientoDatos).HasColumnName("TRATAMIENTODATOS");
            entity.Property(e => e.Administrador).HasColumnName("ADMINISTRADOR");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("APELLIDOS");
            entity.Property(e => e.AvatarUrl)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("AVATAR_URL");
            entity.Property(e => e.Correo)
                .HasMaxLength(70)
                .IsUnicode(false)
                .HasColumnName("CORREO");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("FECHA_CREACION");
            entity.Property(e => e.IdPais).HasColumnName("ID_PAIS");
            entity.Property(e => e.Nombres)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBRES");
            entity.Property(e => e.Pasword)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("PASWORD");
            entity.Property(e => e.Sexo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("SEXO");
            entity.Property(e => e.TipoUsuario)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("TIPO_USUARIO");
            entity.Property(e => e.Usuario)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("USUARIO");

            entity.HasOne(d => d.IdPaisNavigation).WithMany(p => p.MdUsuarios)
                .HasForeignKey(d => d.IdPais)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MD_USUARIOS_MD_PAISES");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
