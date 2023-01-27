using OfferAggregator.Dal;
using OfferAggregator.Dal.Models;

var pr = new ProductsRepository();

ProductsDto product = new ProductsDto();
product.Name = "milk ulun";
product.Id = 29;

//var addProduct = pr.AddProduct(product);
//var getProduct = pr.GetAllProducts();
//var getPrById = pr.GetAllProductsByGroupId(1);
//var updPrName = pr.UpdateProductsName(product);
var delProduct = pr.DeleteProduct(29);

Console.WriteLine();

