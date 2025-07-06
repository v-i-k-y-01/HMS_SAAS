using HMS_SAAS.DataLayer.Models;

namespace HMS_SAAS.ServiceLayer.OrderList
{
    public interface IOrderItemService
    {
        Task<OrdersResponse> CreateOrderAsync(OrdersRequest order);
        Task<OrdersResponse> GetOrderDetailsByIdAsync(int OrderId);
        Task<OrdersResponse> UpdateOrderDetails(OrdersResponse ordersRequest);
    }
}
