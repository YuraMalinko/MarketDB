using AutoMapper;
using OfferAggregator.Bll.Models;
using OfferAggregator.Dal;
using OfferAggregator.Dal.Models;

namespace OfferAggregator.Bll
{
    public class Mapper
    {
        private MapperConfiguration _configuration;

        private IMapper _mapper;

        private static Mapper _instanceMapper;

        private Mapper()
        {
            _configuration = new MapperConfiguration(
                cfg => {
                    cfg.CreateMap<ProductsDto, ProductModel>();
                    cfg.CreateMap<ProductModel, ProductsDto>();
                    cfg.CreateMap<ClientsDto, InfoAllClientsOutputModel>();
                    cfg.CreateMap<InfoAllClientsOutputModel, ClientsDto>();
                    cfg.CreateMap<CommentForClientDto, InfoAllClientsOutputModel>();
                    cfg.CreateMap<InfoAllClientsOutputModel, CommentForClientDto>();
                    cfg.CreateMap<FullProductDto, FullProductModel>();
                    cfg.CreateMap<TagDto, TagModel>();
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

        public List<ProductModel> MapProductsDtosToProductModels(List<ProductsDto> products)
        {
            return _mapper.Map<List<ProductModel>>(products);
        }

        public ProductsDto MapProductModelToProductsDto(ProductModel product)
        {
            return _mapper.Map<ProductsDto>(product);
        }

        public List<InfoAllClientsOutputModel> MapClientsDtoToClientsOutputModel(List<ClientsDto> clients)
        {
            return _configuration.CreateMapper().Map<List<InfoAllClientsOutputModel>>(clients);
        }

        public ClientsDto MapClientsOutputModelToClientsDto(InfoAllClientsOutputModel clients)
        {
            return _mapper.Map<ClientsDto>(clients);
        }

        public List<FullProductModel> MapFullProductDtosToFullProductModels(List<FullProductDto> fullProduct)
        {
            return _mapper.Map<List<FullProductModel>>(fullProduct);
        }
    }
}
