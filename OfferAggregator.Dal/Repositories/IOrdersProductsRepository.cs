using OfferAggregator.Dal.Models;

namespace OfferAggregator.Dal.Repositories
{
    public interface IOrdersProductsRepository
    {
        public bool AddProductToOrders(OrdersProductsDto orderProduct);

        public FullOrderDto GetAllInfoInOrderById(int orderId);

        public bool UpdateCountInOrdersProducts(OrdersProductsDto ordersProducts);
    }
}