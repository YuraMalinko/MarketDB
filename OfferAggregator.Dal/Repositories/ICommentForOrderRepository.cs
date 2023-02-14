using OfferAggregator.Dal.Models;

namespace OfferAggregator.Dal.Repositories
{
    public interface ICommentForOrderRepository
    {
        public int AddCommentOrder(CommenForOrderDto comment);

        public bool UpdateCommentOrder(CommenForOrderDto comment);

        public bool DeleteCommentOrder(int id);
    }
}
