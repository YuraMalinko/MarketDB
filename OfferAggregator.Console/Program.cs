using OfferAggregator;
using OfferAggregator.Dal;
using OfferAggregator.Dal.Models;
using System.Security;

//ManagerRepository MR = new ManagerRepository();

//var m = MR.GetSingleManager("ttt", "qqq");

OrderRepository OR = new OrderRepository();
//OrderDto O = new OrderDto()
//{
//    DateCreate = new DateTime(2030, 2, 13, 13,00,00),
//    ComplitionDate = new DateTime(2031, 2, 13, 13, 30,00),
//    ManagerId = 5,
//    ClientId = 2,
//};

//OR.AddOrder(O);
//O.Id = 123;
//O.ManagerId = 6;
//O.ManagerId = 1;
//var result = OR.UpdateOrder(O);
var t = OR.GetAllOrders();

////O.Id=OR.AddOrder(O);
////O.ManagerId = 6;
////OR.UpdateOrder(O);

////var orders = OR.GetAllOrders();

////var blabla = OR.GetAllOrdersByClientId(2);



//OR.DeleteOrder(21);

Console.ReadLine();