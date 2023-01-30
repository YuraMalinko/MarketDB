using OfferAggregator.Dal;
using OfferAggregator.Dal.Models;

var p = new ManagerRepository();
var man = new ManagerDto() { Login = "Yurik", Password = "qqq" };
man.Id = p.AddManager(man);

Console.WriteLine(man.Id);

Console.WriteLine();
