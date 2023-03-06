namespace OfferAggregator.Dal.Models
{
    public class ProductReviewsDto
    {
        public int? Score { get; set; }

        public string? Comment { get; set; }

        public int ClientId { get; set; }

        public string Name { get; set; }

        public int ProductId { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is ProductReviewsDto p &&
                Score==p.Score &&
                Comment==p.Comment && 
                ClientId==p.ClientId && 
                Name==p.Name && 
                ProductId==p.ProductId;
        }
    }
}
