using OfferAggregator.Bll;
using OfferAggregator.Bll.Models;
using OfferAggregator.Dal.Models;
using OfferAggregator.Dal.Repositories;
using OfferAggregator.Bll;
using OfferAggregator.Bll.Models;
using System.Net.Http.Headers;

Console.WriteLine( );

AggregatorRepository AR = new AggregatorRepository();

var t = AR.GetAvgScoreGroupeAndTagOnProductsReviewsByClientId(18);

var ex = Mapper.GetInstance().MapComboTagGroupDtoToComboTagGroupOutputModel(t);

Console.WriteLine();

