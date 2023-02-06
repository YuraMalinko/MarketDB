using OfferAggregator.Dal.Models;

namespace OfferAggregator.Dal.Repositories
{
    public interface ICommentForClientRepository
    {
        public int AddComment(CommentForClientDto comment);

        public bool UpdateComment(CommentForClientDto comment);

        public bool DeleteComment(int id);
    }
}
