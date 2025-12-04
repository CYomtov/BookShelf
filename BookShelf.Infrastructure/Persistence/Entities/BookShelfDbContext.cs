using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BookShelf.Infrastructure.Persistence.Entities;

public partial class BookShelfDbContext : DbContext
{
    public BookShelfDbContext()
    {
    }

    public BookShelfDbContext(DbContextOptions<BookShelfDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<BookStatus> BookStatuses { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=BookShelf;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Books__3214EC07B2E3B96B");

            entity.HasIndex(e => e.Author, "IX_Books_Author");

            entity.HasIndex(e => e.GenreId, "IX_Books_GenreId");

            entity.HasIndex(e => e.Isbn, "IX_Books_Isbn");

            entity.HasIndex(e => e.StatusId, "IX_Books_StatusId");

            entity.HasIndex(e => e.Title, "IX_Books_Title");

            entity.Property(e => e.Author).HasMaxLength(150);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Isbn).HasMaxLength(30);
            entity.Property(e => e.Title).HasMaxLength(200);
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Genre).WithMany(p => p.Books)
                .HasForeignKey(d => d.GenreId)
                .HasConstraintName("FK_Books_Genre");

            entity.HasOne(d => d.Status).WithMany(p => p.Books)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Books_Status");
        });

        modelBuilder.Entity<BookStatus>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK__BookStat__C8EE2063F0E4F8D2");

            entity.ToTable("BookStatus");

            entity.Property(e => e.StatusId).ValueGeneratedNever();
            entity.Property(e => e.StatusName).HasMaxLength(50);
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.GenreId).HasName("PK__Genres__0385057E69C60D41");

            entity.HasIndex(e => e.GenreName, "UQ__Genres__BBE1C3392C503156").IsUnique();

            entity.Property(e => e.GenreName).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
