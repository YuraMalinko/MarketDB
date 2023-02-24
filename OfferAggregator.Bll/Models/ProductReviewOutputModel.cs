namespace OfferAggregator.Bll.Models
{
    public class ProductReviewOutputModel
    {
        public int? Score { get; set; }

        public string? Comment { get; set; }

        public int ClientId { get; set; }

        public string Name { get; set; }

        public int ProductId { get; set; }
    }
}
