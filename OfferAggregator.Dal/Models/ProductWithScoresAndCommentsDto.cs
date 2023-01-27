namespace OfferAggregator.Dal.Models
{
    public class ProductWithScoresAndCommentsDto
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public List<ProductReviewsDto> ProductReviews { get; set; }
    }
}
