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
                cfg =>
                {
                    cfg.CreateMap<ProductsDto, ProductModel>();
                    cfg.CreateMap<ProductModel, ProductsDto>();
                    cfg.CreateMap<CommentForClientDto, ClientOutput>();
                    cfg.CreateMap<ClientOutput, CommentForClientDto>();
                    cfg.CreateMap<StocksWithProductModel, StocksDtoWithProductName>();
                    cfg.CreateMap<FullProductDto, FullProductModel>();
                    cfg.CreateMap<TagDto, TagModel>();
                    cfg.CreateMap<ManagerAuthInput, ManagerDto>();
                    cfg.CreateMap<CurrentManager, ManagerDto>();
                    cfg.CreateMap<ManagerDto, CurrentManager>();
                    cfg.CreateMap<CreatingOrderModel, CreatingOrderDto>();
                    cfg.CreateMap<OrderModel, OrderDto>();
                    cfg.CreateMap<ProductCountModel, ProductCountDto>();
                    cfg.CreateMap<CurrentManager, ManagerDto>();
                    cfg.CreateMap<ClientModel, ClientsDto>();
                    cfg.CreateMap<CommentForOrderModel, CommenForOrderDto>();
                    cfg.CreateMap<CommentForClientModel, CommentForClientDto>();
                    cfg.CreateMap<ProductsStatisticDto, ProductsStatisticModel>();
                    cfg.CreateMap<ClientsDto, ClientOutput>();
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

        public List<ClientOutput> MapClientsDtosToClientsOutput(List<ClientsDto> clients)
        {
            return _configuration.CreateMapper().Map<List<ClientOutput>>(clients);
        }

        public ClientsDto MapClientsOutputModelToClientsDto(ClientOutput clients)
        {
            return _mapper.Map<ClientsDto>(clients);
        }

        public StocksDtoWithProductName MapStocksWithProductModelToStocksWithProductModel(StocksWithProductModel stockProduct)
        {
            return _mapper.Map<StocksDtoWithProductName>(stockProduct);
        }

        public List<FullProductModel> MapFullProductDtosToFullProductModels(List<FullProductDto> fullProduct)
        {
            return _mapper.Map<List<FullProductModel>>(fullProduct);
        }

        public FullProductModel MapFullProductDtoToFullProductModel(FullProductDto fullProduct)
        {
            return _mapper.Map<FullProductModel>(fullProduct);
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

        public List<ProductsStatisticModel> MapProductsStatisticDtosToProductsStatisticModels(List<ProductsStatisticDto> productsStatistics)
        {
            return _mapper.Map<List<ProductsStatisticModel>>(productsStatistics);
        }

        public CreatingOrderDto MapCreatingOrderModelToCreatingOrderDto(CreatingOrderModel creatingOrderModel)
        {
            return _mapper.Map<CreatingOrderDto>(creatingOrderModel);
        }

        public ClientOutput MapClientDtoToClientOutput(ClientsDto client)
        {
            return _mapper.Map<ClientOutput>(client);
        }
    }
}