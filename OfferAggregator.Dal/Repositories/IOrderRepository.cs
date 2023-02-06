using OfferAggregator.Dal.Models;

namespace OfferAggregator.Dal.Repositories
{
    public interface IOrderRepository
    {
        public int AddOrder(OrderDto order);

        public int DeleteOrder(int id);

        public List<OrderDto> GetAllOrders();

        public List<OrderDto> GetAllOrdersByClientId(int ClientId);

        public List<OrderDto> GetAllOrdersByIdManager(int managerId);

        public int UpdateOrder(OrderDto order);
    }
}