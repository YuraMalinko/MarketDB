using OfferAggregator.Dal.Models;

namespace OfferAggregator.Dal.Repositories
{
    public interface IOrderRepository
    {
        int AddOrder(OrderDto order);
        int DeleteOrder(int id);
        List<OrderDto> GetAllOrders();
        List<OrderDto> GetAllOrdersByClientId(int ClientId);
        List<OrderDto> GetAllOrdersByIdManager(int managerId);
        int UpdateOrder(OrderDto order);
    }
}