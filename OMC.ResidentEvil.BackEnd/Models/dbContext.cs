using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace OMC.ResidentEvil.BackEnd.Models;

public partial class dbContext : DbContext
{
    public dbContext()
    {
    }

    public dbContext(DbContextOptions<dbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Character> Characters { get; set; }

    public virtual DbSet<Gun> Guns { get; set; }

    public virtual DbSet<Videogame> Videogames { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost; Initial Catalog=OMC_Videogames; User Id=user; Password=user123; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Character>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Characte__3214EC073187DF8A");

            entity.ToTable("Character");

            entity.Property(e => e.FirstName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.MiddleName)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.IdGameNavigation).WithMany(p => p.Characters)
                .HasForeignKey(d => d.IdGame)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Character__IdGam__398D8EEE");
        });

        modelBuilder.Entity<Gun>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Gun__3214EC07362ABE88");

            entity.ToTable("Gun");

            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.IdGameNavigation).WithMany(p => p.Guns)
                .HasForeignKey(d => d.IdGame)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Gun__IdGame__45F365D3");
        });

        modelBuilder.Entity<Videogame>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Videogam__3214EC07D86E4853");

            entity.ToTable("Videogame");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
