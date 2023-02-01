using OfferAggregator.Dal.Models;

namespace OfferAggregator.Dal.Repositories
{
    public interface IOrdersProductsRepository
    {
        bool AddOrdersProductsToOrdersProducts(OrdersProductsDto orderProduct);
        FullOrderDto GetAllProductsInOrderByOrderId(int orderId);
        bool UpdateCountProductInOrdersProducts(OrdersProductsDto ordersProducts);
    }
}