using OfferAggregator.Dal.Models;
using OfferAggregator.Dal.Repositories;

OrdersProductsRepository orPr = new OrdersProductsRepository();

OrdersProductsDto orProd = new OrdersProductsDto
{
    OrderId = 10,
    ProductId = 34,
    CountProduct = 10
};

//orPr.AddOrdersProductsToOrdersProducts(or);

//var o = orPr.AddOrdersProductsToOrdersProducts(or);

FullOrderDto order = new FullOrderDto();
order.OrderId = 17;

//var orderResult = orPr.GetAllProductsInOrderByOrderId(17);

var updCount = orPr.UpdateCountProductInOrdersProducts(orProd);

Console.WriteLine();