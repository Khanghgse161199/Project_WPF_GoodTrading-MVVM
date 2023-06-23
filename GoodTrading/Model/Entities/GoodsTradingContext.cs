using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GoodTrading.Model.Entities;

public partial class GoodsTradingContext : DbContext
{
    public GoodsTradingContext()
    {
    }

    public GoodsTradingContext(DbContextOptions<GoodsTradingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Token> Tokens { get; set; }

    public virtual DbSet<TrandingHistory> TrandingHistories { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=GoodsTrading;User Id=test;Password=Test;TrustServerCertificate=True;Trusted_Connection=true;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.Property(e => e.Id).HasMaxLength(400);
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(400);
            entity.Property(e => e.Name).HasMaxLength(400);
            entity.Property(e => e.UserId).HasMaxLength(400);

            entity.HasOne(d => d.User).WithMany(p => p.Products)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_User");
        });

        modelBuilder.Entity<Token>(entity =>
        {
            entity.Property(e => e.Id).HasMaxLength(400);
            entity.Property(e => e.AccessToken).HasMaxLength(400);
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.UserId).HasMaxLength(400);

            entity.HasOne(d => d.User).WithMany(p => p.Tokens)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tokens_User");
        });

        modelBuilder.Entity<TrandingHistory>(entity =>
        {
            entity.ToTable("TrandingHistory");

            entity.Property(e => e.Id).HasMaxLength(400);
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.FromGood).HasMaxLength(400);
            entity.Property(e => e.FromUser).HasMaxLength(400);
            entity.Property(e => e.ToGood).HasMaxLength(400);
            entity.Property(e => e.ToUser).HasMaxLength(400);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.Id).HasMaxLength(400);
            entity.Property(e => e.PassWord).HasMaxLength(200);
            entity.Property(e => e.UserName).HasMaxLength(200);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
