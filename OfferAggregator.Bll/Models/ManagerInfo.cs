using OfferAggregator.Dal.Models;
using OfferAggregator.Dal.Repositories;
using OfferAggregator.Bll.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferAggregator.Bll.Models
{
    public class ManagerInfo
    {
        private Mapper _map = Mapper.GetInstance();

        private ManagerRepository _managerRepository;

        public ManagerAuthOutput AddManager (ManagerAuthInput manager)
        {
            ManagerDto newManager = _map.MapManagerAuthInputToManagerDto(manager);

            newManager.Id =_managerRepository.AddManager(newManager);

            return _map.MapManagerDtoToManagerAuthOutput(newManager);
        }

        public bool UpdateManager(ManagerInput manager)
        {
            return _managerRepository.UpdateManager(_map.MapManagerInputToManagerDto(manager));
        }

    }
}
