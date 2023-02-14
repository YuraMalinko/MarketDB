using OfferAggregator.Dal.Models;
using OfferAggregator.Dal.Repositories;
using OfferAggregator.Bll;
using OfferAggregator.Bll.Models;

ProductsRepository pr = new ProductsRepository();
//var get = pr.GetFullProductById(30);

ProductsReviewsAndStocksRepository prS = new ProductsReviewsAndStocksRepository();

TagsRepository tagsRepository = new TagsRepository();

GroupRepository groupRepository = new GroupRepository();

ProductService serv = new ProductService(pr, prS, tagsRepository, groupRepository);

//var get = serv.GetFullProductById(30);

//var getAll = pr.GetFullProducts();

var getAllServ = serv.GetFullProducts();

Console.WriteLine();

//