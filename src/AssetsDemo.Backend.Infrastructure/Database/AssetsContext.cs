// -------------------------------------------------------------------------------------
//  <copyright file="AssetsContext.cs" company="{Company Name}">
//    Copyright (c) {Company Name}. All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace AssetsDemo.Backend.Infrastructure.Database;

using Domain.Assets;
using Domain.AssetTypes;
using Microsoft.EntityFrameworkCore;

public class AssetsContext : DbContext
{
    public AssetsContext(DbContextOptions<AssetsContext> options) : base(options)
    {
    }

    public DbSet<Asset> Assets { get; set; } = default!;
    public DbSet<AssetType> AssetTypes { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AssetType>(
            entity =>
            {
                entity.ToTable("AssetType");

                entity.Property(e => e.Id)
                    .HasColumnOrder(0)
                    .ValueGeneratedNever();

                entity.Property(x => x.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(x => x.Description)
                    .IsRequired()
                    .HasMaxLength(1000);
            });

        modelBuilder.Entity<Asset>(
            entity =>
            {
                entity.ToTable("Asset");

                entity.Property(e => e.Id)
                    .HasColumnOrder(0)
                    .ValueGeneratedNever();

                entity.Property(e => e.AssetTypeId)
                    .IsRequired()
                    .HasColumnOrder(1);

                entity.Property(x => x.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(x => x.Description)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.HasOne(d => d.AssetType)
                    .WithMany(p => p.Assets)
                    .HasForeignKey(d => d.AssetTypeId)
                    .HasConstraintName("FK_Assets_AssetTypes");
            });
    }
}