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

var nTag = tR.UpdateTagName(newTag);

Console.WriteLine("O");
