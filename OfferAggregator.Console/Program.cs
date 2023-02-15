using OfferAggregator.Bll;
using OfferAggregator.Bll.Models;
using OfferAggregator.Dal.Models;
using OfferAggregator.Dal.Repositories;
using OfferAggregator.Bll;
using OfferAggregator.Bll.Models;


ProductsRepository pr = new ProductsRepository();

ProductsReviewsAndStocksRepository productsReviewsAndStocksRepository = new ProductsReviewsAndStocksRepository();

TagsRepository tagsRepository = new TagsRepository();

GroupRepository groupRepository = new GroupRepository();

ProductService productService = new ProductService(pr, productsReviewsAndStocksRepository, tagsRepository, groupRepository);

//var get = pr.GetProductsStatistic();

var getSer = productService.GetProductsStatistic(); 


Console.WriteLine();

