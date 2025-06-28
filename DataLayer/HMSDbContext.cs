using HMS_SAAS.DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace HMS_SAAS.DataLayer;

public class HMSDbContext:DbContext
{
    public HMSDbContext(DbContextOptions<HMSDbContext> options): base(options)
    {
    }

    // Define DbSets for your entities here
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

       modelBuilder.Entity<MenuItems>(entity =>
{
    entity.ToTable("HMS_MENU_TABLE");

    entity.HasKey(e => e.ItemId);
    entity.Property(e => e.ItemId).HasColumnName("item_id");
    entity.Property(e => e.ItemName).HasColumnName("item_name");
    entity.Property(e => e.Category).HasColumnName("category");
    entity.Property(e => e.PricePerUnit).HasColumnName("price_per_unit");
    entity.Property(e => e.IsAvailable).HasColumnName("is_available");
    entity.Property(e => e.CreatedAt).HasColumnName("created_at");
    entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
});

    }
    // public DbSet<YourEntity> YourEntities { get; set; }
    public DbSet<MenuItems> MenuItems { get; set; }
}
