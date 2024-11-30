using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PruebaTecnica.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cursos> Cursos { get; set; }

    public virtual DbSet<Evaluaciones> Evaluaciones { get; set; }

    public virtual DbSet<Inscripciones> Inscripciones { get; set; }

    public virtual DbSet<Intentos> Intentos { get; set; }

    public virtual DbSet<Preguntas> Preguntas { get; set; }

    public virtual DbSet<Respuestas> Respuestas { get; set; }

    public virtual DbSet<RespuestasUsuarios> RespuestasUsuarios { get; set; }

    public virtual DbSet<Roles> Roles { get; set; }

    public virtual DbSet<Usuarios> Usuarios { get; set; }

    public virtual DbSet<UsuarioRoles> UsuarioRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=LAPTOP-M4BMB68E\\SQLEXPRESS;Database=PlataformaEvaluacionCursosDev4;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cursos>(entity =>
        {
            entity.HasKey(e => e.CursoId).HasName("PK__Cursos__7E023A373D2A753C");

            entity.Property(e => e.CursoId).HasColumnName("CursoID");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<Evaluaciones>(entity =>
        {
            entity.HasKey(e => e.EvaluacionId).HasName("PK__Evaluaci__99ABA8A579674ED0");

            entity.Property(e => e.EvaluacionId).HasColumnName("EvaluacionID");
            entity.Property(e => e.CursoId).HasColumnName("CursoID");
            entity.Property(e => e.FechaFin).HasColumnType("datetime");
            entity.Property(e => e.FechaInicio).HasColumnType("datetime");
            entity.Property(e => e.Titulo).HasMaxLength(100);

            entity.HasOne(d => d.Curso).WithMany(p => p.Evaluaciones)
                .HasForeignKey(d => d.CursoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Evaluacio__Curso__36B12243");
        });

        modelBuilder.Entity<Inscripciones>(entity =>
        {
            entity.HasKey(e => e.InscripcionId).HasName("PK__Inscripc__16831699A0DD3CE6");

            entity.Property(e => e.InscripcionId).HasColumnName("InscripcionID");
            entity.Property(e => e.CursoId).HasColumnName("CursoID");
            entity.Property(e => e.FechaInscripcion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

            entity.HasOne(d => d.Curso).WithMany(p => p.Inscripciones)
                .HasForeignKey(d => d.CursoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Inscripci__Curso__32E0915F");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Inscripciones)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Inscripci__Usuar__31EC6D26");
        });

        modelBuilder.Entity<Intentos>(entity =>
        {
            entity.HasKey(e => e.IntentoId).HasName("PK__Intentos__F1BF51CE584593D9");

            entity.Property(e => e.IntentoId).HasColumnName("IntentoID");
            entity.Property(e => e.EvaluacionId).HasColumnName("EvaluacionID");
            entity.Property(e => e.FechaFin).HasColumnType("datetime");
            entity.Property(e => e.FechaInicio).HasColumnType("datetime");
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

            entity.HasOne(d => d.Evaluacion).WithMany(p => p.Intentos)
                .HasForeignKey(d => d.EvaluacionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Intentos__Evalua__403A8C7D");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Intentos)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Intentos__Usuari__3F466844");
        });

        modelBuilder.Entity<Preguntas>(entity =>
        {
            entity.HasKey(e => e.PreguntaId).HasName("PK__Pregunta__EBB2A359ABAC75AA");

            entity.Property(e => e.PreguntaId).HasColumnName("PreguntaID");
            entity.Property(e => e.EvaluacionId).HasColumnName("EvaluacionID");
            entity.Property(e => e.Tipo).HasMaxLength(50);

            entity.HasOne(d => d.Evaluacion).WithMany(p => p.Pregunta)
                .HasForeignKey(d => d.EvaluacionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Preguntas__Evalu__398D8EEE");
        });

        modelBuilder.Entity<Respuestas>(entity =>
        {
            entity.HasKey(e => e.RespuestaId).HasName("PK__Respuest__31F7FC319B333B7D");

            entity.Property(e => e.RespuestaId).HasColumnName("RespuestaID");
            entity.Property(e => e.PreguntaId).HasColumnName("PreguntaID");

            entity.HasOne(d => d.Pregunta).WithMany(p => p.Respuesta)
                .HasForeignKey(d => d.PreguntaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Respuesta__Pregu__3C69FB99");
        });

        modelBuilder.Entity<RespuestasUsuarios>(entity =>
        {
            entity.HasKey(e => e.RespuestaUsuarioId).HasName("PK__Respuest__55B8B8D2D3B40977");

            entity.ToTable("RespuestasUsuarios");

            entity.Property(e => e.RespuestaUsuarioId).HasColumnName("RespuestaUsuarioID");
            entity.Property(e => e.IntentoId).HasColumnName("IntentoID");
            entity.Property(e => e.PreguntaId).HasColumnName("PreguntaID");
            entity.Property(e => e.RespuestaId).HasColumnName("RespuestaID");

            entity.HasOne(d => d.Intento).WithMany(p => p.RespuestasUsuarios)
                .HasForeignKey(d => d.IntentoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Respuesta__Inten__4316F928");

            entity.HasOne(d => d.Pregunta).WithMany(p => p.RespuestasUsuarios)
                .HasForeignKey(d => d.PreguntaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Respuesta__Pregu__440B1D61");

            entity.HasOne(d => d.Respuesta).WithMany(p => p.RespuestasUsuarios)
                .HasForeignKey(d => d.RespuestaId)
                .HasConstraintName("FK__Respuesta__Respu__44FF419A");
        });

        modelBuilder.Entity<Roles>(entity =>
        {
            entity.HasKey(e => e.RolId).HasName("PK__Roles__F92302D1E4026377");

            entity.HasIndex(e => e.Nombre, "UQ__Roles__75E3EFCFD962BE7C").IsUnique();

            entity.Property(e => e.RolId).HasColumnName("RolID");
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Usuarios>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK__Usuarios__2B3DE798312B5508");

            entity.HasIndex(e => e.Email, "UQ__Usuarios__A9D1053451243951").IsUnique();

            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");
            entity.Property(e => e.Contraseña).HasMaxLength(256);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<UsuarioRoles>(entity =>
        {
            entity.HasKey(e => e.UsuarioRolId).HasName("PK__UsuarioR__C869CD2A166AE1BA");

            entity.Property(e => e.UsuarioRolId).HasColumnName("UsuarioRolID");
            entity.Property(e => e.RolId).HasColumnName("RolID");
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

            entity.HasOne(d => d.Rol).WithMany(p => p.UsuarioRoles)
                .HasForeignKey(d => d.RolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UsuarioRo__RolID__2C3393D0");

            entity.HasOne(d => d.Usuario).WithMany(p => p.UsuarioRoles)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UsuarioRo__Usuar__2B3F6F97");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
