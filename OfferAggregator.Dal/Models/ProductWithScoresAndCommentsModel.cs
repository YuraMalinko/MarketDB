namespace OfferAggregator.Dal.Models
{
    public class ProductWithScoresAndCommentsModel
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public List<ProductReviewsModel> ProductReviews { get; set; }
    }
}
