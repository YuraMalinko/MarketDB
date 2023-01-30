using OfferAggregator;
using OfferAggregator.Dal;
using OfferAggregator.Dal.Models;
using System.Security;

OrderRepository OR = new OrderRepository();
OrderDto O = new OrderDto()
{
    DateCreate = DateTime.Now,
    ComplitionDate = new DateTime(2023, 2, 12, 13, 30, 0),
    ManagerId = 16,
    ClientId = 2,
};

Console.WriteLine(O.Id=OR.AddOrder(O));