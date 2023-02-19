namespace OfferAggregator.Dal.Models
{
    public class ProductReviewsModel
    {
        public int? Score { get; set; }

        public string? Comment { get; set; }

        public int ClientId { get; set; }

        public int ProductId { get; set; }
    }
}
