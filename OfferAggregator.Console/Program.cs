using OfferAggregator;
using OfferAggregator.Dal;
using OfferAggregator.Dal.Models;
using OfferAggregator.Dal.Repositories;
using System.Security;

ClientsWishesRepository clientsWishesRepository= new ClientsWishesRepository();

ClientWishesDto clW = new ClientWishesDto
{ 
ClientId=1,
GroupId = 3,
TagId = 8,
IsLiked = true
};

//var addClW = clientsWishesRepository.AddClientWishes(clW);

ClientWishesDto clWishe = new ClientWishesDto
{
    ClientId = 100
};

var getClW = clientsWishesRepository.GetClientWishesByClientId(clWishe);

Console.WriteLine();

