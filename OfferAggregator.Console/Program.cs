using OfferAggregator.Dal;
using OfferAggregator.Dal.Models;

var pr = new ProductsRepository();

ProductsDto product = new ProductsDto();
product.Name = "green tea";
product.GroupId = 1;

//var addProduct = pr.AddProduct(product);

var getProduct = pr.GetAllProducts();

Console.WriteLine();

