using OfferAggregator.Dal.Models;
using OfferAggregator.Dal;

var prReviewAndStocks = new ProductsReviewsAndStocksRepository();

StocksDto stock = new StocksDto();
stock.Amount = 100;
stock.ProductId = 30;

//var addAmount = prReviewAndStocks.AddAmountToStocks(stock);

ProductReviewsDto productReview= new ProductReviewsDto();
productReview.Score = 5;
productReview.Comment = "my score is 5";
productReview.ClientId = 1;
productReview.ProductId= 30;

//var addStock = prReviewAndStocks.AddScoreAndCommentToProductReview(productReview);

prReviewAndStocks.GetAllScoresAndCommentsForProducts();

Console.WriteLine();
