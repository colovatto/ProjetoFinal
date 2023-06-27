using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProjetoFinal;

public partial class ServiceDeskContext : DbContext
{
    public ServiceDeskContext()
    {
    }

    public ServiceDeskContext(DbContextOptions<ServiceDeskContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        // => optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=ServiceDesk;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.TicketId).HasName("PK__Ticket__3333C610A0BB7CC9");

            entity.ToTable("Ticket");

            entity.Property(e => e.TicketId).HasColumnName("ticketId");
            entity.Property(e => e.TicketCategoria)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ticketCategoria");
            entity.Property(e => e.TicketDescricao)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("ticketDescricao");
            entity.Property(e => e.TicketEmail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ticketEmail");
            entity.Property(e => e.TicketEvidencia).HasColumnName("ticketEvidencia");
            entity.Property(e => e.TicketHora)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ticketHora");
            entity.Property(e => e.TicketNome)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ticketNome");
            entity.Property(e => e.TicketTel)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ticketTel");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Usuario__CB9A1CFF71B7EC07");

            entity.ToTable("Usuario");

            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.UserLogin)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("userLogin");
            entity.Property(e => e.UserNome)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("userNome");
            entity.Property(e => e.UserSenha)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("userSenha");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
