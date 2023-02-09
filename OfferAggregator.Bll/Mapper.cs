using AutoMapper;
using OfferAggregator.Bll.Models;
using OfferAggregator.Dal.Models;

namespace OfferAggregator.Bll
{
    public class Mapper
    {
        private MapperConfiguration _config;

        private static Mapper _instance;

        private Mapper()
        {
            _config = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<ManagerAuthInput, ManagerDto>();

                    cfg.CreateMap<ManagerInput, ManagerDto>();

                    cfg.CreateMap<ManagerDto, ManagerOutput>();

                });
        }

        public static Mapper GetInstance()
        {
            if (_instance is null)
            {
                _instance = new Mapper();
            }

            return _instance;
        }

        public ManagerDto MapManagerAuthInputToManagerDto(ManagerAuthInput manager)
        {
            return _config.CreateMapper().Map<ManagerDto>(manager);
        }

        public ManagerAuthOutput MapManagerDtoToManagerAuthOutput(ManagerDto manager)
        {
            return _config.CreateMapper().Map<ManagerAuthOutput>(manager);
        }

        public List<ManagerOutput> MapManagerDtoToManagerOutput(List<ManagerDto> manager)
        {
            return _config.CreateMapper().Map<List<ManagerOutput>>(manager);
        }

        public ManagerDto MapManagerInputToManagerDto(ManagerInput manager)
        {
            return _config.CreateMapper().Map<ManagerDto>(manager);
        }


    }
}