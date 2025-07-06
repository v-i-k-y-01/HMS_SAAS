using HMS_SAAS.ServiceLayer.Menu;
using Microsoft.AspNetCore.Mvc;

namespace HMS_SAAS.Controllers.Menu;
[ApiController]
[Route("api/[controller]")]
public class MenuItemController(IMenuItemsService menuItemsService) : ControllerBase
{
    [HttpGet("GetMenuItems")] //vignesh
    public async Task<IActionResult> GetMenuItems()
    {
        try
        {   if(menuItemsService == null)
            {
                return BadRequest("MenuItemsService is not Found.");
            }
            var menuItems = await menuItemsService.GetMenuItemsAsync();
            return Ok(menuItems);
        }
        catch (Exception ex)
        {
            // Log the exception (optional)
            return StatusCode(500, "Internal server error: " + ex.Message);
        }
    }
    [HttpGet("GetMenuItemById/{itemId}")]  //vignesh
    public async Task<IActionResult> GetMenuItemById(string itemId)
    {
        try
        {
            var item = await menuItemsService.GetMenuItemByIdAsync(itemId);
            return Ok(item);
        }
        catch(Exception ex)
        {
            // Log the exception (optional)
            return StatusCode(500, "Internal server error: " + ex.Message);
        }

    }
    [HttpPost("UpdateMenuItem")] //vignesh
    public async Task<IActionResult> UpdateMenuItem([FromBody] DataLayer.Models.MenuItems menuItems)
    {
        try
        {
            if (menuItems == null)
            {
                return BadRequest("Menu item cannot be null.");
            }
            var updatedItem = await menuItemsService.UpdateMenuItemsAsync(menuItems);
            return Ok(updatedItem);
        }
        catch (Exception ex)
        {
            // Log the exception (optional)
            return StatusCode(500, "Internal server error: " + ex.Message);
        }
    }
}
