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

ProductReviewsDto productReview2 = new ProductReviewsDto();
productReview2.Score = 3;
productReview2.Comment = "dont like it";
productReview2.ClientId = 2;
productReview2.ProductId = 30;

ProductReviewsDto productReview3 = new ProductReviewsDto();
productReview3.Score = 4;
productReview3.Comment = "super";
productReview3.ClientId = 2;
productReview3.ProductId = 12;

//var addStock = prReviewAndStocks.AddScoreAndCommentToProductReview(productReview);

//prReviewAndStocks.GetAllScoresAndCommentsForProducts();

//var allAmounts = prReviewAndStocks.GetAmountsOfAllProducts();

//var scoresAndCommentsByClientId = prReviewAndStocks.GetAllScoresAndCommentsForProductsByClientId(2);

//var scoresAndCommentsByProductId = prReviewAndStocks.GetAllScoresAndCommentsForProductByProductId(30);

var scoresAndCommentsByPrIdAndClId = prReviewAndStocks.GetAllScoresAndCommentsForProductByProductIDAndClientId(2, 12);

Console.WriteLine();
