using OfferAggregator.Dal.Models;

namespace OfferAggregator.Dal.Repositories
{
    public interface IGroupRepository
    {
        public GroupDto GetGroupById(int id);
        public List<GroupDto> GetAllGroups();
    }
}