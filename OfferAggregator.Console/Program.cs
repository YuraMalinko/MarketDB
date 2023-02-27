using OfferAggregator.Bll;
using OfferAggregator.Bll.Models;
using OfferAggregator.Dal.Models;
using OfferAggregator.Dal.Repositories;
using OfferAggregator.Bll;
using OfferAggregator.Bll.Models;
using System.Net.Http.Headers;

ClientRepository _clientRepository = new ClientRepository();
ClientsWishesRepository _clientsWishesRepository = new ClientsWishesRepository();
CommentForClientRepository _commentForClientRepository = new CommentForClientRepository();
OrderRepository _orderRepository = new OrderRepository();
ClientService _cl = new ClientService();

var ccc = _cl.GetAllClients();

Console.WriteLine( );

