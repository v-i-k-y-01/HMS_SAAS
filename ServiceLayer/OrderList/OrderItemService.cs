using HMS_SAAS.DataLayer;
using HMS_SAAS.DataLayer.Models;
using HMS_SAAS.ServiceLayer.Menu;
using Microsoft.EntityFrameworkCore;

namespace HMS_SAAS.ServiceLayer.OrderList
{
    public class OrderItemService(HMSDbContext context, IMenuItemsService itemService, ILogger<OrdersResponse> logger) : IOrderItemService
    {
        public async Task<OrdersResponse> CreateOrderAsync(OrdersRequest order)
        {
            var item = await itemService.GetMenuItemByIdAsync(order.ItemId);
            if (item == null)
                throw new Exception("Invalid Item Id");
            var orders = new OrdersResponse
            {
                ItemId = order.ItemId,
                ItemName = item.ItemName,
                Quantity = order.Quantity,
                CreatedAt = DateTime.Now
            };
            context.Orders.Add(orders);
            await context.SaveChangesAsync();
            return orders;
        }

        public async Task<OrdersResponse> GetOrderDetailsByIdAsync(int OrderId)
        {
            var items = await context.Orders.FirstOrDefaultAsync(x=>x.OrderId == OrderId);
            if (items == null)
            {
                throw new Exception("Order not found");
            }
            return items;


        }

        public async Task<OrdersResponse> UpdateOrderDetails(OrdersResponse ordersRequest)
        {
            var existingItems = await context.Orders.FirstOrDefaultAsync(x => x.OrderId == ordersRequest.OrderId);
            if (existingItems == null)
            {
                return null;
            }

            existingItems.ItemId = ordersRequest.ItemId;
            existingItems.ItemName = ordersRequest.ItemName;
            existingItems.Quantity = ordersRequest.Quantity;
            existingItems.UpdatedAt = DateTime.Now;

            context.SaveChangesAsync();
            return existingItems;

            
        }

    }
}
