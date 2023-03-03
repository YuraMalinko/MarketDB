using OfferAggregator.Dal.Models;

namespace OfferAggregator.Dal.Repositories
{
    public interface IGroupRepository
    {
        public GroupDto GetGroupById(int id);

        public List<GroupDto> GetAllGroups();

        public int AddGroup(string name);

        public bool UpdateGroup(GroupDto group);

        public bool DeleteGroup(int id);

        public List<ProductsDto> GetAllProductsByGroupIdWitchExist(int groupId);
    }
}