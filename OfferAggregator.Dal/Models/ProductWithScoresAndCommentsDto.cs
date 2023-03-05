namespace OfferAggregator.Dal.Models
{
    public class ProductWithScoresAndCommentsDto
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public List<ProductReviewsDto> ProductReviews { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is ProductWithScoresAndCommentsDto p &&
                ProductId == p.ProductId &&
                Name == p.Name &&
                ProductReviews.SequenceEqual(p.ProductReviews);
        }
    }
}
