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

OrderService orderService = new OrderService(_managerRepository, clRepo, orRepo, _ordersProductsRepository, _productsRepository, _commentForOrderRepository, _commentForClientRepository);

ProductsReviewsAndStocksRepository _productsReviewsAndStocksRepository = new ProductsReviewsAndStocksRepository();

var bbb = _ccc.GetClientCommentsByClientId(2);
TagsRepository _tagsRepository = new TagsRepository();

GroupRepository _groupRepository = new GroupRepository();

ClientRepository clientRepository = new ClientRepository();

ProductService productService = new ProductService(_productsRepository, _productsReviewsAndStocksRepository, _tagsRepository, _groupRepository, clientRepository);

ProductReviewInputModel productReviewModel = new ProductReviewInputModel
{
    ClientId = 1,
    ProductId = 2
};

//var addCom = productService.AddScoreOrCommentToProductReview(productReviewModel);

//var getAllGroups = productService.GetAllGroups();

//var createOrder = orderService.CreateNewOrder(creatingOrderModel);

//OrderDto o1 = new OrderDto { Client = new ClientsDto() };
//OrderDto o2 = new OrderDto { Client = new ClientsDto() };
//o1.Equals(o2);

ProductsDto pr = new ProductsDto
{ Name = "Sheep" };

//var addPr = _productsRepository.AddProduct(pr);



//var get = clientRepository.GetClientsWhoOrderedProductByProductId(50);

ClientService clientService = new ClientService(clientRepository, _productsRepository);

//var get = clientService.GetClientsWhoOrderedProductByProductId(500);

//var getSt = _productsRepository.GetProductStatisticById(47);

//var get = productService.GetProductStatisticById(470);

//var get = _productsReviewsAndStocksRepository.GetAllScoresAndCommentsForProductByProductId(30);

//var getScC = productService.GetAllScoresAndCommentsForProductByProductId(13);


ProductReviewInputModel productReviewInputModel = new ProductReviewInputModel
{
    ProductId = 90,
    ClientId = 6,
   Score = 5,
    //Comment = "my score 5!"

};

//var upd = productService.UpdateScoreAndCommentOfProductReview(productReviewInputModel);

//var get = _productsReviewsAndStocksRepository.GetAllScoresAndCommentsForProductByProductIdAndClientId(59, 1); 

//var get = productService.GetAllScoresAndCommentsForProductByProductIdAndClientId(30, 1);

//var addUPD = productService.AddScoreOrCommentToProductReview(productReviewInputModel);

//var getTags = productService.GetAllTagsByProductId(300);

//var addtag = productService.AddNewTagToProduct("дешевое", 98);

var add = productService.AddExistTagToProduct(new TagProductInputModel{TagId = 20, ProductId = 12});

Console.WriteLine();

