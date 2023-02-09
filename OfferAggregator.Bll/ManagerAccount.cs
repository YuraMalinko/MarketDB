using OfferAggregator.Bll.Models;
using OfferAggregator.Dal.Models;
using OfferAggregator.Dal.Repositories;

namespace OfferAggregator.Bll
{
    public class ManagerAccount
    {
        private Mapper _map = Mapper.GetInstance();

        private ManagerRepository _managerRep = new ManagerRepository();

        public int AddManager(ManagerAuthInput manager)
        {
            return _managerRep.AddManager(_map.MapManagerAuthInputToManagerDto(manager));
        }

        public ManagerAuthOutput GetSingleManager(ManagerAuthInput manager)
        {
            ManagerDto result = _managerRep.GetSingleManager(_map.MapManagerAuthInputToManagerDto(manager));

            return _map.MapManagerDtoToManagerAuthOutput(result);
        }

        public bool UpdateManager(ManagerInput manager)
        {
            return _managerRep.UpdateManager(_map.MapManagerInputToManagerDto(manager));
        }

        public bool DeleteManager(int id)
        {
            return _managerRep.DeleteManager(id);
        }

        public List<ManagerOutput> GetAllManager()
        {
            return _map.MapManagerDtoToManagerOutput(_managerRep.GetAllManagers());
        }
    }
}
