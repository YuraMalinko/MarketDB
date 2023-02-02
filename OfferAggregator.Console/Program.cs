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

var alltags30 = tR.GetAllTagsByProductId(30);

Console.WriteLine("O");
