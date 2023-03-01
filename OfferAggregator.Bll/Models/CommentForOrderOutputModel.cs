namespace OfferAggregator.Bll.Models
{
    public class CommentForOrderOutputModel
    {
        public int Id { get; set; }

        public string? Text { get; set; }

        public int OrderId { get; set; }
    }
}
