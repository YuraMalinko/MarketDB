using OfferAggregator;
using OfferAggregator.Dal;
using OfferAggregator.Dal.Models;
using System.Security;

OrderRepository OR = new OrderRepository();
//OrderDto O = new OrderDto()
//{
//    DateCreate = new DateTime(2026, 2, 13, 13, 30, 0),
//    ComplitionDate = new DateTime(2027, 2, 13, 13, 30, 0),
//    ManagerId = 5,
//    ClientId = 2,
//};

//O.Id=OR.AddOrder(O);
//O.ManagerId = 6;
//OR.UpdateOrder(O);

//var orders = OR.GetAllOrders();

//var blabla = OR.GetAllOrdersByClientId(2);


OR.DeleteOrder(21);

Console.ReadLine();