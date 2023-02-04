using OfferAggregator.Dal.Models;

namespace OfferAggregator.Dal.Repositories
{
    public interface IOrdersProductsRepository
    {
        bool AddOrdersProductsToOrdersProducts(OrdersProductsDto orderProduct);
        FullOrderDto GetAllInfoInOrderById(int orderId);
        bool UpdateCountProductInOrdersProducts(OrdersProductsDto ordersProducts);
    }
}