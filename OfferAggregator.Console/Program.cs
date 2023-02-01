using OfferAggregator.Dal.Models;
using OfferAggregator.Dal.Repositories;

OrdersProductsRepository orPr = new OrdersProductsRepository();

OrdersProductsDto or = new OrdersProductsDto
{
    OrderId = 15,
    ProductId = 47,
    CountProduct = 5
};

//orPr.AddOrdersProductsToOrdersProducts(or);

//var o = orPr.AddOrdersProductsToOrdersProducts(or);

FullOrderDto order = new FullOrderDto();
order.OrderId = 17;

var orderResult = orPr.GetAllProductsInOrderByOrderId(17);

Console.WriteLine();