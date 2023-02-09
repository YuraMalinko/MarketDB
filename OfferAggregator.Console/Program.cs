using OfferAggregator.Dal.Models;
using OfferAggregator.Dal.Repositories;
using OfferAggregator.Bll;
using OfferAggregator.Bll.Models;

ClientsDto clin = new ClientsDto()
{
    
};


ClientService clt = new ClientService();

var ccc = clt.GetAllClientsWithoutComment();

Console.WriteLine();

