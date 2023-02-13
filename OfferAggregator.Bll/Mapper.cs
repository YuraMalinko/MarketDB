using AutoMapper;
using OfferAggregator.Bll.Models;
using OfferAggregator.Dal.Models;

namespace OfferAggregator.Bll
{
    public class Mapper
    {
        private MapperConfiguration _configuration;

        private static Mapper _instanceMapper;

        private IMapper _mapper;
        
        private Mapper()
        {
            _configuration = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<ManagerAuthInput, ManagerDto>();
                    cfg.CreateMap<CurrentManager, ManagerDto>();
                    cfg.CreateMap<ManagerDto, CurrentManager>();
                });

            _mapper = _configuration.CreateMapper();
        }

        public static Mapper GetInstance()
        {
            if (_instanceMapper is null)
            {
                _instanceMapper = new Mapper();
            }

            return _instanceMapper;
        }

        public ManagerDto MapManagerAuthInputToManagerDto(ManagerAuthInput manager)
        {
            return _mapper.Map<ManagerDto>(manager);
        }

        public CurrentManager MapManagerDtoToCurrentManager(ManagerDto manager)
        {
            return _mapper.Map<CurrentManager>(manager);
        }

        public List<OutsideManager> MapManagersDtoToOutsideManagers(List<ManagerDto> manager)
        {
            return _mapper.Map<List<OutsideManager>>(manager);
        }

        public ManagerDto MapCurrentManagerToManagerDto(CurrentManager manager)
        {
            return _mapper.Map<ManagerDto>(manager);
        }
    }
}