namespace OfferAggregator.Bll.Models
{
    public class ProductWithScoresAndCommentsInputModel
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public List<ProductReviewInputModel> ProductReviews { get; set; }
    }
}
