using OfferAggregator.Bll;
using OfferAggregator.Bll.Models;
using OfferAggregator.Dal.Models;
using OfferAggregator.Dal.Repositories;
using OfferAggregator.Bll;
using OfferAggregator.Bll.Models;
using System.Net.Http.Headers;

AggregatorService AS = new AggregatorService();



//var tmp = AR.GetComboTagGroupOfLikeOrDislikeByClientId(18);
//var t = AS.SelectOfPotentialProductsForClient(7);


//var t = AR.GetAvgScoreGroupeAndTagOnProductsReviewsByClientId(18);

//var ex = Mapper.GetInstance().MapComboTagGroupDtoToComboTagGroupOutputModel(t);

//var get4 = AR.GetGroupTagCountProductsCountOrdersByClientId(2000);

//AggregatorService service = new AggregatorService();

//var getMap = service.

//var getMap = service.GetGroupTagCountProductsCountOrdersByClientId(2);



var big = AS.SelectOfPotentialProductsForClient(39);

Console.WriteLine();