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
CommentForClientRepository _ccc = new CommentForClientRepository();

var bbb = _ccc.GetClientCommentsByClientId(2);


Console.WriteLine( );

