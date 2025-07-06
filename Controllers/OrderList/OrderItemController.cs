using HMS_SAAS.DataLayer.Models;
using HMS_SAAS.ServiceLayer.OrderList;
using Microsoft.AspNetCore.Mvc;

namespace HMS_SAAS.Controllers.OrderList
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderItemController(IOrderItemService orderItemService, ILogger<OrderItemController> logger) : ControllerBase
    {
        [HttpPost("CreateOrder")]  //vinush
        public async Task<IActionResult> CreateOrderAsync([FromBody] OrdersRequest orders)
        {
            if (orders == null)
            {
                logger.LogInformation("Order Value needed");
            }
            try
            {
                logger.LogInformation("Creating your order...");
                var orderItem = await orderItemService.CreateOrderAsync(orders);
                return Ok(orderItem);
            }
            catch(Exception ex)
            {
                logger.LogInformation(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetOrderById")] //vinush
        public async Task<IActionResult> GetOrderAsync(int orderId)
        {
            if(orderId == null)
            {
                logger.LogInformation("OrderId not found");
            }
            try
            {
                logger.LogInformation("Fetching Order Details...");
                var orderDetails = await orderItemService.GetOrderDetailsByIdAsync(orderId);
                return Ok(orderDetails);
            }
            catch(Exception ex)
            {
                logger.LogInformation(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateOrders")] //vinush
        public async Task<IActionResult> UpdateOrderList([FromBody] OrdersResponse ordersResponse)
        {
            if(ordersResponse==null)
            {
                logger.LogInformation("OrderId not found");
            }
            try
            {
                logger.LogInformation("Updating the Order Details");
                var updatedOrderList = await orderItemService.UpdateOrderDetails(ordersResponse);
                return Ok(updatedOrderList);
            }
            catch(Exception ex)
            {
                logger.LogInformation(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
