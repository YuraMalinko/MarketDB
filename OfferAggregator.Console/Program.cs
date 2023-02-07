using OfferAggregator.Dal.Models;
using OfferAggregator.Dal.Repositories;
using System.Security;

ClientsWishesRepository clientsWishesRepository= new ClientsWishesRepository();

ClientWishesDto clW = new ClientWishesDto
{ 
ClientId=9,
GroupId = 3,
TagId = 8,
IsLiked = true
};

//var addClW = clientsWishesRepository.AddClientWishes(clW);

ClientWishesDto clWishe = new ClientWishesDto
{
    Id = 11,
    ClientId = 1,
    GroupId = 3,
    TagId = 7,
    IsLiked = true
};

//var getClW = clientsWishesRepository.GetClientWishesByClientId(1);

//var updClW = clientsWishesRepository.UpdateClientWishesById(clWishe);

ClientWishesDto clWishes = new ClientWishesDto
{
    ClientId = 1,
    GroupId = 3,
    TagId = 7
};

var delClW = clientsWishesRepository.DeleteClientWishesById(40);

Console.WriteLine();

