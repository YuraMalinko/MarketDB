using OfferAggregator.Dal.Models;
using OfferAggregator.Dal.Repositories;
using OfferAggregator.Bll;
using OfferAggregator.Bll.Models;

Console.WriteLine();
Console.WriteLine();
Console.WriteLine();
Console.WriteLine();
Console.WriteLine();


ClientService clt = new ClientService();

var ccc = clt.GetAllClientsWithoutComment();

Console.WriteLine();

