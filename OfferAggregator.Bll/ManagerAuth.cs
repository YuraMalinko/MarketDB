using OfferAggregator.Bll.Models;
using OfferAggregator.Dal.Models;
using OfferAggregator.Dal.Repositories;

namespace OfferAggregator.Bll
{
    public class ManagerAuth
    {
        private Mapper _instanceMapper = Mapper.GetInstance();

        public IManagerRepository ManagerRep { get; set; }

        public IOrderRepository OrderRepository { get; set; } 

        public ManagerAuth(IManagerRepository managerRep=null,IOrderRepository orderRepository=null)
        {
            ManagerRep = managerRep;
            OrderRepository = orderRepository;
        }

        public int AddManager(ManagerAuthInputModel manager)
        {
            int result = -1;

            try
            {
                ManagerDto tmp = ManagerRep.GetManagerByLogin(manager.Login!);

                if (tmp == null)
                {
                    result = ManagerRep.AddManager(
                        _instanceMapper.MapManagerAuthInputToManagerDto(manager));
                }
            }
            catch (Exception ex)
            {
                return result;
            }

            return result;
        }

        public CurrentManager ManagerAuthentication(ManagerAuthInputModel manager)
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
