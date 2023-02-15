using OfferAggregator.Dal.Models;

namespace OfferAggregator.Dal.Repositories
{
    public interface IManagerRepository
    {
        public int AddManager(ManagerDto manager);

        public bool DeleteManager(int id);

        public List<ManagerDto> GetAllManagers();

        public ManagerDto GetSingleManager(ManagerDto manager);

        public bool UpdateManager(ManagerDto manager);

        public ManagerDto GetManagerByLogin(string login);
    }
}