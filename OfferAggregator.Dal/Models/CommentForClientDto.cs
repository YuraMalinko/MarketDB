namespace OfferAggregator.Dal.Models
{
    public class CommentForClientDto
    {
        public int Id { get; set; }

        public string? Text { get; set; }

        public int? ClientId { get; set; }
    }
}