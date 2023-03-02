namespace OfferAggregator.Bll.Models
{
    public class CommentForOrderInputModel
    {
        //public int Id { get; set; }

        public string? Text { get; set; }

        public int OrderId { get; set; }
    }
}
