using HMS_SAAS.DataLayer;
using HMS_SAAS.DataLayer.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace HMS_SAAS.ServiceLayer.Menu;

public class MenuItemService(HMSDbContext context , ILogger<MenuItemService> logger):IMenuItemsService
{
    public async Task<List<MenuItems>> GetMenuItemsAsync()
    {
        try
        {
            logger.LogInformation("Fetching Menu Items...");
            return await context.MenuItems.ToListAsync();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error fetching menu items");
            throw;
        }
    }
    public async Task<MenuItems> GetMenuItemByIdAsync(string itemId)
    {
        try
        {
            if (itemId != null)
            {
                logger.LogInformation($"Fetching Menu Item with ID: {itemId}");
                var menuItem = await context.MenuItems.FirstOrDefaultAsync(m => m.ItemId == itemId);
                return menuItem;
            }
            else
            {
                logger.LogWarning("Item ID is null");
                throw new ArgumentNullException(nameof(itemId), "Item ID cannot be null");
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error fetching menu item by ID");
            throw;
        }  
    }
    public async Task<MenuItems>UpdateMenuItemsAsync (MenuItems menuItems)
    {
        var existingItem = await context.MenuItems.FirstOrDefaultAsync(x => x.ItemId == menuItems.ItemId);
        if (existingItem == null)
        {
            throw new KeyNotFoundException($"Menu item with ID {menuItems.ItemId} not found.");
        }
        existingItem.ItemName = menuItems.ItemName;
        existingItem.Category = menuItems.Category;
        existingItem.PricePerUnit = menuItems.PricePerUnit;
        existingItem.IsAvailable = menuItems.IsAvailable;
        existingItem.UpdatedAt = DateTime.Now;
        context.SaveChangesAsync();
        return existingItem;
    }
}

