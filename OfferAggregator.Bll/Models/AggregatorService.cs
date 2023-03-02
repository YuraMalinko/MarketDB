using OfferAggregator.Dal.Repositories;


namespace OfferAggregator.Bll.Models
{
    public class AggregatorService
    {
        private Mapper _instanceMapper = Mapper.GetInstance();
        private IAggregatorRepository _aggregatorRepository = new AggregatorRepository();
    }
}
