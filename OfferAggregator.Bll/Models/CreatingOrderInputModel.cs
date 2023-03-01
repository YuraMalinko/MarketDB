namespace OfferAggregator.Bll.Models
{
    public class CreatingOrderInputModel
    {
        public OrderModel Order { get; set; }

        public List<ProductCountInputModel> Products { get; set; }

        public List<CommentForOrderOutputModel> CommentsForOrder { get; set; }

        public List<CommentForClientOutputModel> CommentsForClient { get; set; }
    }
}
