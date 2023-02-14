namespace OfferAggregator.Bll.Models
{
    public class CommentForClientModel
    {
        public int Id { get; set; }

        public string? Text { get; set; }

        public int ClientId { get; set; }
    }
}
