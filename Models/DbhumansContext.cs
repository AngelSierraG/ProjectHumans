using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProjectHumans.Models;

public partial class DbhumansContext : DbContext
{

    public DbhumansContext(DbContextOptions<DbhumansContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Human> Humans { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Human>(entity =>
        {
            entity.Property(e => e.Age)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Height)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Sex)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Weight)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
