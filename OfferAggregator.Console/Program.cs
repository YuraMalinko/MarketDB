using OfferAggregator.Dal.Models;
using OfferAggregator.Dal;

var PrReviewAndStocks = new ProductsReviewsAndStocksRepository();

StocksDto stock = new StocksDto();
stock.Amount = 100;
stock.ProductId = 30;

var addAmount = PrReviewAndStocks.AddAmountToStocks(stock);


Console.WriteLine();
