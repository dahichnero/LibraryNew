using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Library.Models;

public partial class WellLibraryContext : DbContext
{
    public WellLibraryContext()
    {
    }

    public WellLibraryContext(DbContextOptions<WellLibraryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<Extradition> Extraditions { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Provisioner> Provisioners { get; set; }

    public virtual DbSet<Reader> Readers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=WellLibrary;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Isbn).HasName("PK__Book__447D36EB133360EC");

            entity.ToTable("Book");

            entity.Property(e => e.Isbn)
                .HasMaxLength(13)
                .HasColumnName("ISBN");
            entity.Property(e => e.Author).HasMaxLength(50);
            entity.Property(e => e.BookName).HasMaxLength(50);

            entity.HasOne(d => d.GenreiNavigation).WithMany(p => p.Books)
                .HasForeignKey(d => d.Genrei)
                .HasConstraintName("FK__Book__Genre__2A4B4B5E");

            entity.HasOne(d => d.ProvisionerNavigation).WithMany(p => p.Books)
                .HasForeignKey(d => d.Provisioner)
                .HasConstraintName("FK__Book__Provisione__29572725");
        });

        modelBuilder.Entity<Extradition>(entity =>
        {
            entity.HasKey(e => e.ExtraditionId).HasName("PK__Extradit__977BBB5EC07CA170");

            entity.ToTable("Extradition");

            entity.Property(e => e.Book).HasMaxLength(13);
            entity.Property(e => e.DateBack).HasColumnType("date");
            entity.Property(e => e.DateExtra).HasColumnType("date");

            entity.HasOne(d => d.BookNavigation).WithMany(p => p.Extraditions)
                .HasForeignKey(d => d.Book)
                .HasConstraintName("FK__Extraditio__Book__2D27B809");

            entity.HasOne(d => d.ReaderNavigation).WithMany(p => p.Extraditions)
                .HasForeignKey(d => d.Reader)
                .HasConstraintName("FK__Extraditi__Reade__2E1BDC42");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.GenreId).HasName("PK__Genre__0385057EB70DD167");

            entity.ToTable("Genre");

            entity.Property(e => e.GenreName).HasMaxLength(20);
        });

        modelBuilder.Entity<Provisioner>(entity =>
        {
            entity.HasKey(e => e.ProvisionerId).HasName("PK__Provisio__517D8231001CA70F");

            entity.ToTable("Provisioner");

            entity.Property(e => e.ProvisionerId).ValueGeneratedNever();
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.ProvisionerName).HasMaxLength(50);
        });

        modelBuilder.Entity<Reader>(entity =>
        {
            entity.HasKey(e => e.ReaderId).HasName("PK__Reader__8E67A5E1AF48F097");

            entity.ToTable("Reader");

            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(12);
            entity.Property(e => e.ReaderEmail).HasMaxLength(50);
            entity.Property(e => e.ReaderName).HasMaxLength(50);
            entity.Property(e => e.SurName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
