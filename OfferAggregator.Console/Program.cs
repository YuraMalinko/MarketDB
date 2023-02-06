using OfferAggregator.Dal.Models;
using OfferAggregator.Dal.Repositories;

TagsRepository tR = new TagsRepository();

//var m = MR.GetSingleManager("ttt", "qqq");

//OrderRepository OR = new OrderRepository();


//for (int i = 5; i < 8; i++)
//try
//{
//    OrderDto O = new OrderDto()
//    {
//        DateCreate = DateTime.Now,
//        ComplitionDate = new DateTime(2023, 2, i, 13, 30, 00),
//        ManagerId = 8,
//        ClientId = 9,
//    };
//    var tag = tR.AddTag("black");
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.ToString());
//}

//    OR.AddOrder(O);
//}

//OR.AddOrder(O);
//O.Id = 123;
//O.ManagerId = 6;
//O.ManagerId = 1;
//var result = OR.UpdateOrder(O);
//var t = OR.GetAllOrders();
//var tag = tR.AddTag("black");

var cr = new ClientRepository();
var clients = cr.GetAllClients();
var products4clients = cr.GetAllPurchasedProductsByClientId(9);
Console.WriteLine();
////var client = new ClientsDto() { Name = "Melman", PhoneNumber = "555" };
////client.Id = cr.AddClient(client);
////client.Name = "Putin";
////cr.UpdateClient(client);
//var or = new OrderRepository();
//Console.WriteLine();


////O.Id=OR.AddOrder(O);
////O.ManagerId = 6;
////OR.UpdateOrder(O);
TagProductDto beefTenderloin = new TagProductDto
{
    TagId = 3,
    ProductId = 49
};

//var bF = tR.AddTagProduct(beefTenderloin);

//var allTags = tR.GetAllTags();

//var alltags30 = tR.GetAllTagsByProductId(30);

var newTag = new TagDto
{
    Id = 4,
    Name = "pork"
};

//var nTag = tR.UpdateTagName(newTag);

//Console.ReadLine();
//var prReviewAndStocks = new ProductsReviewsAndStocksRepository();
//var deleteTag = tR.DeleteTag(11);

//StocksDtoWithProductName stock = new StocksDtoWithProductName();
//stock.Amount = 100;
//stock.ProductId = 30;
ProductReviewsDto prRw = new ProductReviewsDto();
prRw.ProductId = 12;
prRw.ClientId = 2;

//StocksDtoWithProductName stock2 = new StocksDtoWithProductName();
//stock2.Amount = 13;
//stock2.ProductId = 34;
var prRevSt = new ProductsReviewsAndStocksRepository();

//var delPrRew = prRevSt.DeleteProductsReviews(prRw);

StocksDtoWithProductName stock = new StocksDtoWithProductName();
stock.ProductId = 8;
stock.Amount = 6;

//var delStock = prRevSt.DeleteStock(stock);

//ProductReviewsDto productReview= new ProductReviewsDto();
//productReview.Score = 5;
//productReview.Comment = "my score is 5";
//productReview.ClientId = 1;
//productReview.ProductId= 30;

//ProductReviewsDto productReview2 = new ProductReviewsDto();
//productReview2.Score = 3;
//productReview2.Comment = "dont like it";
//productReview2.ClientId = 2;
//productReview2.ProductId = 30;

//ProductReviewsDto productReview3 = new ProductReviewsDto();
//productReview3.Score = 5;
//productReview3.Comment = "super tea";
//productReview3.ClientId = 2;
//productReview3.ProductId = 12;

//ProductReviewsDto productReview4 = new ProductReviewsDto();
//productReview4.Score = 5;
//productReview4.Comment = "i like aHmad tea";
//productReview4.ClientId = 1;
//productReview4.ProductId = 47;

////var updScoresAndComment = prReviewAndStocks.AddScoreAndCommentToProductReview(productReview4);

//var updScoresAndCom = prReviewAndStocks.UpdateScoreAndCommentOfProductsReviews(productReview3);

//var addStock = prReviewAndStocks.AddScoreAndCommentToProductReview(productReview);

//prReviewAndStocks.GetAllScoresAndCommentsForProducts();

//var allAmounts = prReviewAndStocks.GetAmountsOfAllProducts();

//var scoresAndCommentsByClientId = prReviewAndStocks.GetAllScoresAndCommentsForProductsByClientId(2);

//var scoresAndCommentsByProductId = prReviewAndStocks.GetAllScoresAndCommentsForProductByProductId(30);

//var scoresAndCommentsByPrIdAndClId = prReviewAndStocks.GetAllScoresAndCommentsForProductByProductIDAndClientId(12,2);

//Console.WriteLine();

//var pr = new ProductsRepository();

//ProductsDto product = new ProductsDto();
//product.Name = "tea milk ulun";
//product.Id = 29;
//product.GroupId = 1;

//ProductsDto earlGrey = new ProductsDto();
//earlGrey.Name = "earlGrey";
//earlGrey.GroupId = 1;

//ProductsDto lipton = new ProductsDto();
//lipton.Name = "tea lipton";
//lipton.GroupId = 1;
//lipton.Id = 34;

//var addProduct = pr.AddProduct(product);
//var getProduct = pr.GetAllProducts();
//var getPrById = pr.GetAllProductsByGroupId(1);
//var updPrName = pr.UpdateProductsName(product);
//var delProduct = pr.DeleteProduct(29);
//var earlGreyId = pr.AddProduct(earlGrey);
//var prMilkYlyn = pr.UpdateProduct(lipton);
TagProductDto tagProduct = new TagProductDto
{ 
TagId = 7,
ProductId = 4,
};

var delTagPr = tR.DeleteTagProduct(tagProduct);

Console.WriteLine("O");
