namespace OfferAggregator.Bll.Models
{
    public class ProductWithScoresAndCommentsOutputModel
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public List<ProductReviewOutputModel> ProductReviews { get; set; }
    }
}
