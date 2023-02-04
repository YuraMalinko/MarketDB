namespace OfferAggregator.Dal.Repositories
{
    public interface ITagsRepository
    {
        bool DeleteTagProductByProductId(int productId);
    }
}