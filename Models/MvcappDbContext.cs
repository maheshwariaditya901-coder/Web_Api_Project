using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Web_Api_Project.Models;

public partial class MvcappDbContext : DbContext
{
    public MvcappDbContext()
    {
    }

    public MvcappDbContext(DbContextOptions<MvcappDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Gadget> Gadgets { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Gadget>(entity =>
        {
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Students__3214EC07B391D1D5");

            entity.HasIndex(e => e.Email, "UQ__Students__A9D105344E5FC83A").IsUnique();

            entity.Property(e => e.Course)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
