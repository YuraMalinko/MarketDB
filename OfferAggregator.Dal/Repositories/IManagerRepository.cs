using OfferAggregator.Dal.Models;

namespace OfferAggregator.Dal.Repositories
{
    public interface IManagerRepository
    {
        public int AddManager(ManagerDto manager);

        public void DeleteManager(int id);

        public List<ManagerDto> GetAllManagers();

        public ManagerDto GetSingleManager(string login, string password);

        public void UpdateManager(ManagerDto manager);
    }
}