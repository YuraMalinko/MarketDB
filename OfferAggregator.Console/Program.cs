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
ProductService pM = new ProductService(productsRepository);

//var addProduct = pM.AddProduct(product);

var getAllProd = pM.GetAllProducts();

Console.WriteLine();

