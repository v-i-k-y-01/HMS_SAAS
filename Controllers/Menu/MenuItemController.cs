using HMS_SAAS.ServiceLayer.Menu;
using Microsoft.AspNetCore.Mvc;

namespace HMS_SAAS.Controllers.Menu;
[ApiController]
[Route("api/[controller]")]
public class MenuItemController(IMenuItemsService menuItemsService) : ControllerBase
{
    [HttpGet("GetMenuItems")]
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
}
