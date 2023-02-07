using OfferAggregator;
using OfferAggregator.Dal;
using OfferAggregator.Dal.Models;
using OfferAggregator.Dal.Repositories;
using OfferAggregator.Bll;
using OfferAggregator.Bll.Models;

ProductModel product = new ProductModel();
product.Name = "Baltika";
product.GroupId = 9;

IProductsRepository productsRepository = new ProductsRepository();


//var addProduct = pM.AddProduct(product);

//var getAllProd = pM.GetAllProducts();

//var getAllProdByGroupId = pM.GetAllProductsByGroupId(101010);

ProductModel ovca = new ProductModel();
ovca.Name = "Sheep";
ovca.GroupId = 0;
ovca.Id = 2;

//var updPr = pM.UpdateProduct(ovca);

//var delProd = pM.DeleteProduct(505);

ProductsReviewsAndStocksRepository prRev = new ProductsReviewsAndStocksRepository();

//var dlete1 = prRev.DeleteProductReviewByProductId(1);

TagsRepository tR = new TagsRepository();

ProductService pM = new ProductService(productsRepository, prRev, tR);

//var delTag = tR.DeleteTagProductByProductId(1);

//var deleteProduct = pM.DeleteProduct(1);

StocksWithProductModel stPrModel = new StocksWithProductModel();
stPrModel.ProductId = 2;
stPrModel.Amount = -15;

//var regUpd = pM.RegistrateProductInStock(stPrModel);

StocksDtoWithProductName stPrDto = new StocksDtoWithProductName();
stPrDto.ProductId = 2;
stPrDto.Amount = 4;

//var addSt = prRev.AddAmountToStocks(stPrDto);

//var getAm = pM.GetAmountByProductId(1);

var getAllAmounts = pM.GetAmountsOfAllProducts();

Console.WriteLine();

