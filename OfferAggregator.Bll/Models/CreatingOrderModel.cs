namespace OfferAggregator.Bll.Models
{
    public class CreatingOrderModel
    {
        public OrderModel Order { get; set; }

        public List<ProductModel> Products { get; set; }

        public List<OrdersProductModel> OrdersProducts { get; set;}

        public List<CommentForOrderModel> CommentsForOrder { get; set; }

        public List<CommentForClientModel> CommentsForClient { get; set; }
    }
}
