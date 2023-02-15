using OfferAggregator.Dal.Models;
using OfferAggregator.Dal.Repositories;
using OfferAggregator.Bll;
using OfferAggregator.Bll.Models;

ClientRepository _clientRepository = new ClientRepository();
ClientsWishesRepository _clientsWishesRepository = new ClientsWishesRepository();
CommentForClientRepository _commentForClientRepository = new CommentForClientRepository();
OrderRepository _orderRepository = new OrderRepository();

ClientService clt = new ClientService(_clientRepository, _clientsWishesRepository, _commentForClientRepository, _orderRepository);

ClientsOutputModel newclt = new ClientsOutputModel() { Id = 352, Name = "Kevin", PhoneNumber = "38286387" };

var ccc = clt.AddClient(newclt);

Console.WriteLine();

