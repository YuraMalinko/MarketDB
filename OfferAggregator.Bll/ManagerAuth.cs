using OfferAggregator.Bll.Models;
using OfferAggregator.Dal.Models;
using OfferAggregator.Dal.Repositories;

namespace OfferAggregator.Bll
{
    public class ManagerAuth
    {
        private Mapper _instanceMapper = Mapper.GetInstance();

        public IManagerRepository ManagerRep { get; set; } = new ManagerRepository();

        public ManagerAuth(IManagerRepository managerRep=null)
        {
                ManagerRep = managerRep;
        }

        public int AddManager(ManagerAuthInput manager)
        {
            ManagerDto tmp = ManagerRep.GetManagerByLogin(manager.Login!);

            if (tmp == null)
            {
                return ManagerRep.AddManager(
                    _instanceMapper.MapManagerAuthInputToManagerDto(manager));
            }
            else
            {
                return -1;
            }
        }

        public CurrentManager GetSingleManager(ManagerAuthInput manager)
        {
            ManagerDto result = ManagerRep.GetSingleManager(
                _instanceMapper.MapManagerAuthInputToManagerDto(manager));

            return _instanceMapper.MapManagerDtoToCurrentManager(result);
        }

        public bool UpdateManager(CurrentManager manager)
        {
            return ManagerRep.UpdateManager(
                _instanceMapper.MapCurrentManagerToManagerDto(manager));
        }

        public bool DeleteManager(int id)
        {
            return ManagerRep.DeleteManager(id);
        }
    }
}
