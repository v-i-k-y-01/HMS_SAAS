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
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at").HasDefaultValueSql("GETDATE()");
        });

        modelBuilder.Entity<OrdersResponse>(entity =>
        {
            entity.ToTable("ORDERS");
            entity.HasKey(e => e.OrderId);
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.ItemId).HasColumnName("item_id");
            entity.Property(e => e.ItemName).HasColumnName("item_name");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("GETDATE()");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at").HasDefaultValueSql("GETDATE()");

            //entity.HasOne(o => o.MenuItem)
            //  .WithMany(m => m.Orders)
            //  .HasForeignKey(o => o.ItemId)
            //  .OnDelete(DeleteBehavior.Restrict);
        });
    }
    // public DbSet<YourEntity> YourEntities { get; set; }
    public DbSet<MenuItems> MenuItems { get; set; }
    public DbSet<OrdersResponse> Orders { get; set; }
}
