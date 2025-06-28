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
}

