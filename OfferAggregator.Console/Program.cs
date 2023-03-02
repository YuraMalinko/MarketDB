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

ClientService clt = new ClientService(_clientRepository, _clientsWishesRepository, _commentForClientRepository, _orderRepository);

ClientsOutputModel newclt = new ClientsOutputModel() { Id = 352, Name = "Kevin", PhoneNumber = "38286387" };

//var ccc = clt.AddClient(newclt);

var sss = clt.GetAllClientsWithoutComment();

var del = clt.DeleteClient(13);

var s = clt.GetAllClientsWithoutComment();

Console.WriteLine( );

AggregatorRepository AR = new AggregatorRepository();

var t = AR.GetAvgScoreGroupeAndTagOnProductsReviewsByClientId(18);

var ex = Mapper.GetInstance().MapComboTagGroupDtoToComboTagGroupOutputModel(t);

Console.WriteLine();

