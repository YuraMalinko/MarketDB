using OfferAggregator.Bll;
using OfferAggregator.Bll.Models;
using OfferAggregator.Dal.Models;
using OfferAggregator.Dal.Repositories;
using System.Security;

IManagerRepository manRepo = new ManagerRepository();

ManagerAuth managerAuth = new ManagerAuth(manRepo);

ManagerAuthInput manager = new ManagerAuthInput("2223345", "");

CurrentManager current = managerAuth.ManagerAuthentication(manager);

int i = managerAuth.AddManager(manager);

Console.WriteLine();

//ManagerRepository www = new ManagerRepository();


//ManagerDto pp = new ManagerDto()
//{
//    Login = "",
//    Password = "eee"
//};

//int b = www.AddManager(pp);

//ManagerDto p = new ManagerDto()
//{
//    Password = "www"
//};

//int c = www.AddManager(p);

//ManagerDto d = new ManagerDto();

//int e = www.AddManager(d);

Console.WriteLine();


//ClientsWishesRepository clientsWishesRepository= new ClientsWishesRepository();

//ClientWishesDto clW = new ClientWishesDto
//{ 
//ClientId=9,
//GroupId = 3,
//TagId = 8,
//IsLiked = true
//};

////var addClW = clientsWishesRepository.AddClientWishes(clW);

//ClientWishesDto clWishe = new ClientWishesDto
//{
//    Id = 11,
//    ClientId = 1,
//    GroupId = 3,
//    TagId = 7,
//    IsLiked = true
//};

////var getClW = clientsWishesRepository.GetClientWishesByClientId(1);

////var updClW = clientsWishesRepository.UpdateClientWishesById(clWishe);

//ClientWishesDto clWishes = new ClientWishesDto
//{
//    ClientId = 1,
//    GroupId = 3,
//    TagId = 7
//};

//var delClW = clientsWishesRepository.DeleteClientWishesById(40);

//Console.WriteLine();
//////var client = new ClientsDto() { Name = "Melman", PhoneNumber = "555" };
//////client.Id = cr.AddClient(client);
//////client.Name = "Putin";
//////cr.UpdateClient(client);
////var or = new OrderRepository();
////Console.WriteLine();


//////O.Id=OR.AddOrder(O);
//////O.ManagerId = 6;
//////OR.UpdateOrder(O);

//////var orders = OR.GetAllOrders();

//////var blabla = OR.GetAllOrdersByClientId(2);



////OR.DeleteOrder(21);

////Console.ReadLine();
////var prReviewAndStocks = new ProductsReviewsAndStocksRepository();

////StocksDtoWithProductName stock = new StocksDtoWithProductName();
////stock.Amount = 100;
////stock.ProductId = 30;

////StocksDtoWithProductName stock2 = new StocksDtoWithProductName();
////stock2.Amount = 13;
////stock2.ProductId = 34;

////prReviewAndStocks.AddAmountToStocks(stock2);

////var updAmount = prReviewAndStocks.UpdateAmountOfStocks(34, 88);

////var addAmount = prReviewAndStocks.AddAmountToStocks(stock);

////ProductReviewsDto productReview= new ProductReviewsDto();
////productReview.Score = 5;
////productReview.Comment = "my score is 5";
////productReview.ClientId = 1;
////productReview.ProductId= 30;

////ProductReviewsDto productReview2 = new ProductReviewsDto();
////productReview2.Score = 3;
////productReview2.Comment = "dont like it";
////productReview2.ClientId = 2;
////productReview2.ProductId = 30;

////ProductReviewsDto productReview3 = new ProductReviewsDto();
////productReview3.Score = 5;
////productReview3.Comment = "super tea";
////productReview3.ClientId = 2;
////productReview3.ProductId = 12;

////ProductReviewsDto productReview4 = new ProductReviewsDto();
////productReview4.Score = 5;
////productReview4.Comment = "i like aHmad tea";
////productReview4.ClientId = 1;
////productReview4.ProductId = 47;

//////var updScoresAndComment = prReviewAndStocks.AddScoreAndCommentToProductReview(productReview4);

////var updScoresAndCom = prReviewAndStocks.UpdateScoreAndCommentOfProductsReviews(productReview3);

////var addStock = prReviewAndStocks.AddScoreAndCommentToProductReview(productReview);

////prReviewAndStocks.GetAllScoresAndCommentsForProducts();

////var allAmounts = prReviewAndStocks.GetAmountsOfAllProducts();

////var scoresAndCommentsByClientId = prReviewAndStocks.GetAllScoresAndCommentsForProductsByClientId(2);

////var scoresAndCommentsByProductId = prReviewAndStocks.GetAllScoresAndCommentsForProductByProductId(30);

////var scoresAndCommentsByPrIdAndClId = prReviewAndStocks.GetAllScoresAndCommentsForProductByProductIDAndClientId(12,2);

////Console.WriteLine();

////var pr = new ProductsRepository();

////ProductsDto product = new ProductsDto();
////product.Name = "tea milk ulun";
////product.Id = 29;
////product.GroupId = 1;

////ProductsDto earlGrey = new ProductsDto();
////earlGrey.Name = "earlGrey";
////earlGrey.GroupId = 1;

////ProductsDto lipton = new ProductsDto();
////lipton.Name = "tea lipton";
////lipton.GroupId = 1;
////lipton.Id = 34;

////var addProduct = pr.AddProduct(product);
////var getProduct = pr.GetAllProducts();
////var getPrById = pr.GetAllProductsByGroupId(1);
////var updPrName = pr.UpdateProductsName(product);
////var delProduct = pr.DeleteProduct(29);
////var earlGreyId = pr.AddProduct(earlGrey);
////var prMilkYlyn = pr.UpdateProduct(lipton);

//Console.WriteLine();

