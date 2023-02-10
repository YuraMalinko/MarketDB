using OfferAggregator.Dal.Models;
using OfferAggregator.Dal.Repositories;
using OfferAggregator.Bll;
using OfferAggregator.Bll.Models;

ProductsRepository pr = new ProductsRepository();
ProductsReviewsAndStocksRepository prSr = new ProductsReviewsAndStocksRepository();
TagsRepository tr = new TagsRepository();
GroupRepository gr = new GroupRepository();

ProductService service = new ProductService(pr, prSr, tr, gr);

StocksWithProductModel stock = new StocksWithProductModel
{
    Amount = 8,
    ProductId = 1
};

//var reg = service.RegistrateProductInStock(stock);

ClientService clt = new ClientService();

var ccc = clt.GetAllClientsWithoutComment();

Console.WriteLine();

