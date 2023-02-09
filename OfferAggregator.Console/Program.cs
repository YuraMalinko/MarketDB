using OfferAggregator.Dal.Models;
using OfferAggregator.Dal.Repositories;
using OfferAggregator.Bll;
using OfferAggregator.Bll.Models;


ClientService clt = new ClientService();

var ccc = clt.GetAllClientsWithoutComment();

Console.WriteLine();

