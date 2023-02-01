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

var o = orPr.AddOrdersProductsToOrdersProducts(or);

Console.WriteLine();