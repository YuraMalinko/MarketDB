using OfferAggregator.Dal.Repositories;


namespace OfferAggregator.Bll
{
    public class AggregatorService
    {
        private Mapper _instanceMapper = Mapper.GetInstance();
        private IAggregatorRepository _aggregatorRepository = new AggregatorRepository();
    }
}
