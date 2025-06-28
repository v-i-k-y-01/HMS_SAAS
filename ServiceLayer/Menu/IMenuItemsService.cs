using HMS_SAAS.DataLayer.Models;

namespace HMS_SAAS.ServiceLayer.Menu;

public interface IMenuItemsService
{
    Task<List<MenuItems>> GetMenuItemsAsync();
}
