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
                    cfg.CreateMap<ProductsDto, ProductOutputModel>();
                    cfg.CreateMap<ProductInputModel, ProductsDto>();
                    cfg.CreateMap<ClientsDto, InfoAllClientsOutputModel>();
                    cfg.CreateMap<InfoAllClientsOutputModel, ClientsDto>();
                    cfg.CreateMap<CommentForClientDto, InfoAllClientsOutputModel>();
                    cfg.CreateMap<InfoAllClientsOutputModel, CommentForClientDto>();
                    cfg.CreateMap<StocksWithProductInputModel, StocksDtoWithProductName>();
                    cfg.CreateMap<StocksDtoWithProductName, StocksWithProductOutputModel>();
                    cfg.CreateMap<FullProductDto, FullProductModel>();
                    cfg.CreateMap<TagDto, TagModel>();
                    cfg.CreateMap<ManagerAuthInput, ManagerDto>();
                    cfg.CreateMap<CurrentManager, ManagerDto>();
                    cfg.CreateMap<ManagerDto, CurrentManager>();
                    cfg.CreateMap<CreatingOrderModel, CreatingOrderDto>();
                    cfg.CreateMap<OrderModel, OrderDto>();
                    cfg.CreateMap<ProductCountModel, ProductCountDto>();
                    cfg.CreateMap<CurrentManager, ManagerDto>();
                    cfg.CreateMap<ClientModel, ClientsDto>().ReverseMap();
                    cfg.CreateMap<CommentForOrderModel, CommenForOrderDto>();
                    cfg.CreateMap<CommentForClientModel, CommentForClientDto>();
                    cfg.CreateMap<ProductsStatisticDto, ProductsStatisticOutputModel>();
                    cfg.CreateMap<GroupDto, GroupModel>();
                    cfg.CreateMap<ClientsProductDto, ClientsProductOutputModel>();
                    cfg.CreateMap<ProductReviewInputModel, ProductReviewsDto>();
                    cfg.CreateMap<ProductWithScoresAndCommentsDto, ProductWithScoresAndCommentsOutputModel>();
                    cfg.CreateMap<ProductReviewsDto, ProductReviewOutputModel>();
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

        public List<ProductOutputModel> MapProductsDtosToProductOutputModels(List<ProductsDto> products)
        {
            return _mapper.Map<List<ProductOutputModel>>(products);
        }

        public ProductsDto MapProductModelToProductsDto(ProductInputModel product)
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

        public StocksDtoWithProductName MapStocksWithProductInputModelToStocksDtoWithProductName(StocksWithProductInputModel stockProduct)
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

        public List<ProductsStatisticOutputModel> MapProductsStatisticDtosToProductsStatisticOutputModels(List<ProductsStatisticDto> productsStatistics)
        {
            return _mapper.Map<List<ProductsStatisticOutputModel>>(productsStatistics);
        }

        public CreatingOrderDto MapCreatingOrderModelToCreatingOrderDto(CreatingOrderModel creatingOrderModel)
        {
            return _mapper.Map<CreatingOrderDto>(creatingOrderModel);
        }

        public List<GroupModel> MapGroupDtosToGroupModels(List<GroupDto> groupsDtos)
        {
            return _mapper.Map<List<GroupModel>>(groupsDtos);
        }

        public ProductOutputModel MapProductDtoToProductOutputModel(ProductsDto productDto)
        {
            return _mapper.Map<ProductOutputModel>(productDto);
        }

        public StocksWithProductOutputModel MapStocksDtoWithProductNameToStocksWithProductOutputModel(StocksDtoWithProductName stockProductDto)
        {
            return _mapper.Map<StocksWithProductOutputModel>(stockProductDto);
        }

        public ClientsProductOutputModel MapClientsProductDtoToClientsProductOutpetModel(ClientsProductDto clientProductDto)
        {
            return _mapper.Map<ClientsProductOutputModel>(clientProductDto);
        }

        public ProductReviewsDto MapProductReviewInputModelToProductReviewsDto(ProductReviewInputModel productReviewModel)
        {
            return _mapper.Map<ProductReviewsDto>(productReviewModel);
        }

        public ProductsStatisticOutputModel MapProductStatisticDtoToProductStatisticOutputModel(ProductsStatisticDto productStatistic)
        {
            return _mapper.Map<ProductsStatisticOutputModel>(productStatistic);
        }

        public ProductWithScoresAndCommentsOutputModel MapProductWithScoresAndCommentsDtoToProductWithScoresAndCommentsOutputModel(ProductWithScoresAndCommentsDto productScoresCommentsDto)
        {
            return _mapper.Map<ProductWithScoresAndCommentsOutputModel>(productScoresCommentsDto);
        }
    }
}