namespace OfferAggregator.Dal.Models
{
    public class CreatingOrderDto
    {
        public OrderDto Order { get; set; }

        public List<ProductCountDto> Products { get; set; }

        public List<CommenForOrderDto> CommentsForOrder { get; set; }

        public List<CommentForClientDto> CommentsForClient { get; set; }
    }
}
