namespace OfferAggregator.Bll.Models
{
    public class CreatingOrderModel
    {
        public OrderModel Order { get; set; }

        public List<ProductCountModel> Products { get; set; }

        public List<CommentForOrderModel> CommentsForOrder { get; set; }

        public List<CommentForClientOutputModel> CommentsForClient { get; set; }
    }
}
