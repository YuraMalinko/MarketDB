using OfferAggregator.Dal.Models;

namespace OfferAggregator.Dal.Repositories
{
    public interface IManagerRepository
    {
        int AddManager(ManagerDto manager);
        void DeleteManager(int id);
        List<ManagerDto> GetAllManagers();
        ManagerDto GetSingleManager(string login, string password);
        void UpdateManager(ManagerDto manager);
    }
}