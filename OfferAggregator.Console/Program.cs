using OfferAggregator.Dal.Models;
using OfferAggregator.Dal.Repositories;
using OfferAggregator.Bll;
using OfferAggregator.Bll.Models;

//ManagerRepository MR = new ManagerRepository();

//var m = MR.GetSingleManager("ttt", "qqq");

OrderRepository OR = new OrderRepository();
//OrderDto O = new OrderDto()
//{
//    DateCreate = new DateTime(2030, 2, 13, 13,00,00),
//    ComplitionDate = new DateTime(2031, 2, 13, 13, 30,00),
//    ManagerId = 5,
//    ClientId = 2,
//};

//OR.AddOrder(O);
//O.Id = 123;
//O.ManagerId = 6;
//O.ManagerId = 1;
//var result = OR.UpdateOrder(O);
var t = OR.GetAllOrders();

////O.Id=OR.AddOrder(O);
////O.ManagerId = 6;
////OR.UpdateOrder(O);

//var getAllProdByGroupId = pM.GetAllProductsByGroupId(101010);

ProductModel ovca = new ProductModel();
ovca.Name = "Sheep";
ovca.GroupId = 0;
ovca.Id = 2;

//var updPr = pM.UpdateProduct(ovca);

//var delProd = pM.DeleteProduct(505);

ProductsReviewsAndStocksRepository prRev = new ProductsReviewsAndStocksRepository();

Console.ReadLine();
var prReviewAndStocks = new ProductsReviewsAndStocksRepository();

StocksDtoWithProductName stock = new StocksDtoWithProductName();
stock.Amount = 100;
stock.ProductId = 30;

StocksDtoWithProductName stock2 = new StocksDtoWithProductName();
stock2.Amount = 13;
stock2.ProductId = 34;

GroupRepository groupRepo = new GroupRepository();

ProductService pM = new ProductService(productsRepository, prRev, tR, groupRepo);

//var delTag = tR.DeleteTagProductByProductId(1);

//var deleteProduct = pM.DeleteProduct(1);


//var getGr = groupRepo.GetGroupById(19);

ProductModel prostokvashino = new ProductModel();
prostokvashino.GroupId = 5; ;
prostokvashino.Name = "prostokvashino";

var addProd = pM.AddProduct(prostokvashino);

//var updHugardan = pM.UpdateProduct(milkUlun);

//var addStock = prReviewAndStocks.AddScoreAndCommentToProductReview(productReview);

//prReviewAndStocks.GetAllScoresAndCommentsForProducts();

//var allAmounts = prReviewAndStocks.GetAmountsOfAllProducts();

//var scoresAndCommentsByClientId = prReviewAndStocks.GetAllScoresAndCommentsForProductsByClientId(2);

//var scoresAndCommentsByProductId = prReviewAndStocks.GetAllScoresAndCommentsForProductByProductId(30);

//var scoresAndCommentsByPrIdAndClId = prReviewAndStocks.GetAllScoresAndCommentsForProductByProductIDAndClientId(12,2);

Console.WriteLine();

var pr = new ProductsRepository();

ProductsDto product = new ProductsDto();
product.Name = "tea milk ulun";
product.Id = 29;
product.GroupId = 1;

ProductsDto earlGrey = new ProductsDto();
earlGrey.Name = "earlGrey";
earlGrey.GroupId = 1;

ProductsDto lipton = new ProductsDto();
lipton.Name = "tea lipton";
lipton.GroupId = 1;
lipton.Id = 34;

//var addProduct = pr.AddProduct(product);
//var getProduct = pr.GetAllProducts();
//var getPrById = pr.GetAllProductsByGroupId(1);
//var updPrName = pr.UpdateProductsName(product);
//var delProduct = pr.DeleteProduct(29);
//var earlGreyId = pr.AddProduct(earlGrey);
var prMilkYlyn = pr.UpdateProduct(lipton);

Console.WriteLine();

