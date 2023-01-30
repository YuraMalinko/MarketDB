using OfferAggregator.Dal.Models;
using OfferAggregator.Dal;

var prReviewAndStocks = new ProductsReviewsAndStocksRepository();

StocksDtoWithProductName stock = new StocksDtoWithProductName();
stock.Amount = 100;
stock.ProductId = 30;

StocksDtoWithProductName stock2 = new StocksDtoWithProductName();
stock2.Amount = 13;
stock2.ProductId = 34;

//var addAmount = prReviewAndStocks.AddAmountToStocks(stock);

ProductReviewsDto productReview= new ProductReviewsDto();
productReview.Score = 5;
productReview.Comment = "my score is 5";
productReview.ClientId = 1;
productReview.ProductId= 30;

//var addStock = prReviewAndStocks.AddScoreAndCommentToProductReview(productReview);

//prReviewAndStocks.GetAllScoresAndCommentsForProducts();

var allAmounts = prReviewAndStocks.GetAmountsOfAllProducts();

Console.WriteLine();
