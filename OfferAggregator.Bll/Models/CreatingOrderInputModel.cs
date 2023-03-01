namespace OfferAggregator.Bll.Models
{
    public class CreatingOrderInputModel
    {
        public OrderInputModel Order { get; set; }

        public List<ProductCountInputModel> Products { get; set; }

        public List<CommentForOrderInputModel> CommentsForOrder { get; set; }

        public List<CommentForClientInputModel> CommentsForClient { get; set; }
    }
}
