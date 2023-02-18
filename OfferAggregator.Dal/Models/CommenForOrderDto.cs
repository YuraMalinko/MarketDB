namespace OfferAggregator.Dal.Models
{
    public class CommenForOrderDto
    {
        public int Id { get; set; }

        public string? Text { get; set; }

        public int OrderId { get; set; }
    }
}
