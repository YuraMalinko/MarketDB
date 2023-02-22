using OfferAggregator.Bll;
using OfferAggregator.Bll.Models;
using OfferAggregator.Dal.Models;
using OfferAggregator.Dal.Repositories;
using OfferAggregator.Bll;
using OfferAggregator.Bll.Models;
using System.Net.Http.Headers;



ProductsReviewsAndStocksRepository _productsReviewsAndStocksRepository = new ProductsReviewsAndStocksRepository();


//var createOrder = orderService.CreateNewOrder(creatingOrderModel);

//OrderDto o1 = new OrderDto { Client = new ClientsDto() };
//OrderDto o2 = new OrderDto { Client = new ClientsDto() };
//o1.Equals(o2);

var getSc = _productsReviewsAndStocksRepository.GetAllScoresAndCommentsForProductByProductId(30);


Console.WriteLine();

