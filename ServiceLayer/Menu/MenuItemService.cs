using HMS_SAAS.DataLayer;
using HMS_SAAS.DataLayer.Models;
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

    public async Task<MenuItems> CreateNewItem(MenuItems menu)
    {
        if (string.IsNullOrWhiteSpace(menu.ItemId))
            menu.ItemId = Guid.NewGuid().ToString();
        menu.CreatedAt = DateTime.Now;
        menu.UpdatedAt = DateTime.Now;
        context.MenuItems.Add(menu);
        await context.SaveChangesAsync();
        return menu;
    }
}

