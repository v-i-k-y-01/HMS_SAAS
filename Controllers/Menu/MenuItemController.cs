using HMS_SAAS.DataLayer.Models;
using HMS_SAAS.ServiceLayer.Menu;
using Microsoft.AspNetCore.Mvc;

namespace HMS_SAAS.Controllers.Menu;
[ApiController]
[Route("api/[controller]")]
public class MenuItemController(IMenuItemsService menuItemsService, ILogger<MenuItemController> logger) : ControllerBase
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
            logger.LogInformation("Unexceptional error handled in exception");
            return StatusCode(500, "Internal server error: " + ex.Message);
        }
    }

    [HttpPost("CreateNewItem")]
    public async Task<IActionResult> CreateNewItem ([FromBody]MenuItems Menu)
    {
        try
        {
            if(Menu == null)
            {
                return BadRequest("No Input Value");
            }
            var item = await menuItemsService.CreateNewItem(Menu);
            logger.LogInformation("New Item Added in MenuList ");
            return Ok(item);
        }
        catch(Exception ex)
        {
            logger.LogInformation("Unexceptional error handled in exception");
            return StatusCode(500, "Internal server error: " + ex.Message);
        }
    }
}