using OfferAggregator.Dal.Models;
using OfferAggregator.Dal.Repositories;

TagsRepository tR = new TagsRepository();

//try
//{
//    var tag = tR.AddTag("black");
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.ToString());
//}

//var tag = tR.AddTag("black");

TagProductDto beefTenderloin = new TagProductDto
{
    TagId = 3,
    ProductId = 49
};

//var bF = tR.AddTagProduct(beefTenderloin);

//var allTags = tR.GetAllTags();

//var alltags30 = tR.GetAllTagsByProductId(30);

var newTag = new TagDto
{
    Id = 4,
    Name = "pork"
};

//var nTag = tR.UpdateTagName(newTag);

//var deleteTag = tR.DeleteTag(11);

ProductReviewsDto prRw = new ProductReviewsDto();
prRw.ProductId = 12;
prRw.ClientId = 2;

var prRevSt = new ProductsReviewsAndStocksRepository();

//var delPrRew = prRevSt.DeleteProductsReviews(prRw);

StocksDtoWithProductName stock = new StocksDtoWithProductName();
stock.ProductId = 8;
stock.Amount = 6;

var delStock = prRevSt.DeleteStock(stock);

Console.WriteLine("O");
