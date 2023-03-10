using AutoMapper;
using OfferAggregator.Bll.Models;
using OfferAggregator.Dal.Models;

namespace OfferAggregator.Bll
{
    public class Mapper
    {
        private MapperConfiguration _configuration;

        private IMapper _mapper;

        public IMapper IMapper => _mapper;

        private static Mapper _instanceMapper;

        private Mapper()
        {
            _configuration = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<ProductInputModel, ProductsDto>();
                    cfg.CreateMap<StocksWithProductInputModel, StocksDtoWithProductName>();
                    cfg.CreateMap<StocksDtoWithProductName, StocksWithProductOutputModel>();
                    cfg.CreateMap<ProductsDto, ProductOutputModel>();
                    cfg.CreateMap<CommentForClientDto, CommentForClientOutputModel>();
                    cfg.CreateMap<CommentForClientInputModel, CommentForClientDto>();
                    cfg.CreateMap<FullProductDto, FullProductOutputModel>();
                    cfg.CreateMap<TagDto, TagOutputModel>();
                    cfg.CreateMap<ManagerAuthInputModel, ManagerDto>();
                    cfg.CreateMap<CurrentManager, ManagerDto>();
                    cfg.CreateMap<ManagerDto, CurrentManager>();
                    cfg.CreateMap<CreatingOrderInputModel, CreatingOrderDto>();
                    cfg.CreateMap<OrderInputModel, OrderDto>();
                    cfg.CreateMap<ProductCountInputModel, ProductCountDto>();
                    cfg.CreateMap<CurrentManager, ManagerDto>();
                    cfg.CreateMap<ClientInputModel, ClientsDto>();
                    cfg.CreateMap<CommentForOrderInputModel, CommenForOrderDto>();
                    cfg.CreateMap<ProductsStatisticDto, ProductsStatisticOutputModel>();
                    cfg.CreateMap<GroupDto, GroupOutputModel>();
                    cfg.CreateMap<ClientsProductDto, ClientsProductOutputModel>();
                    cfg.CreateMap<ProductReviewInputModel, ProductReviewsDto>();
                    cfg.CreateMap<ProductWithScoresAndCommentsDto, ProductWithScoresAndCommentsOutputModel>();
                    cfg.CreateMap<ProductReviewsDto, ProductReviewOutputModel>();
                    cfg.CreateMap<TagProductInputModel, TagProductDto>();
                    cfg.CreateMap<CommentForClientOutputModel, CommentForClientDto>();
                    cfg.CreateMap<ProductsStatisticDto, ProductsStatisticOutputModel>();
                    cfg.CreateMap<ClientsDto, ClientOutputModel>();
                    cfg.CreateMap<OrderDto, OrderOutputModel>();
                    cfg.CreateMap<ClientOutputModel, ClientsDto>();
                    cfg.CreateMap<ComboTagGroupDto, ComboTagGroupOutputModel>();
                    cfg.CreateMap<FullProductDto, SelectProductForClientOutputModel>();
                    cfg.CreateMap<GroupInputModel, GroupDto>().ReverseMap();
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

        public ClientOutputModel MapClientDtoToClientOutputModel(ClientsDto clients)
        {
            return _mapper.Map<ClientOutputModel>(clients);
        }

        public List<ClientOutputModel> MapClientsDtoToClientsOutputModel(List<ClientsDto> clients)
        {
            return _mapper.Map<List<ClientOutputModel>>(clients);
        }

        public ClientsDto MapClientsInputModelModelToClientsDto(ClientInputModel clients)
        {
            return _mapper.Map<ClientsDto>(clients);
        }

        public List<CommentForClientOutputModel> MapCommentForClientDtoToCommentForClientOutputModel(List<CommentForClientDto> comment)
        {
            return _mapper.Map<List<CommentForClientOutputModel>>(comment);
        }

        public CommentForClientDto MapCommentForClientInputModelToCommentForClientDto(CommentForClientInputModel comment)
        {
            return _mapper.Map<CommentForClientDto>(comment);
        }

        public StocksDtoWithProductName MapStocksWithProductInputModelToStocksDtoWithProductName(StocksWithProductInputModel stockProduct)
        {
            return _mapper.Map<StocksDtoWithProductName>(stockProduct);
        }

        public List<FullProductOutputModel> MapFullProductDtosToFullProductModels(List<FullProductDto> fullProduct)
        {
            return _mapper.Map<List<FullProductOutputModel>>(fullProduct);
        }

        public FullProductOutputModel MapFullProductDtoToFullProductModel(FullProductDto fullProduct)
        {
            return _mapper.Map<FullProductOutputModel>(fullProduct);
        }

        public ManagerDto MapManagerAuthInputToManagerDto(ManagerAuthInputModel manager)
        {
            return _mapper.Map<ManagerDto>(manager);
        }

        public CurrentManager MapManagerDtoToCurrentManager(ManagerDto manager)
        {
            return _mapper.Map<CurrentManager>(manager);
        }

        public ManagerDto MapCurrentManagerToManagerDto(CurrentManager manager)
        {
            return _mapper.Map<ManagerDto>(manager);
        }

        public List<ProductsStatisticOutputModel> MapProductsStatisticDtosToProductsStatisticOutputModels(List<ProductsStatisticDto> productsStatistics)
        {
            return _mapper.Map<List<ProductsStatisticOutputModel>>(productsStatistics);
        }

        public CreatingOrderDto MapCreatingOrderModelToCreatingOrderDto(CreatingOrderInputModel creatingOrderModel)
        {
            return _mapper.Map<CreatingOrderDto>(creatingOrderModel);
        }

        public List<GroupOutputModel> MapGroupDtosToGroupModels(List<GroupDto> groupsDtos)
        {
            return _mapper.Map<List<GroupOutputModel>>(groupsDtos);
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

        public List<TagOutputModel> MapTagDtosToTagOutputModels(List<TagDto> tags)
        {
            return _mapper.Map<List<TagOutputModel>>(tags);
        }

        public TagProductDto MapTagProductInputModelToTagProductDto(TagProductInputModel tagProductModel)
        {
            return _mapper.Map<TagProductDto>(tagProductModel);
        }

        public List<OrderOutputModel> MapOrderDtoToOrderOutputModel(OrderDto order)
        {
            return _mapper.Map<List<OrderOutputModel>>(order);
        }

        public List<OrderOutputModel> MapOrdersDtoToOrderOutputModel(List<OrderDto> orders)
        {
            return _mapper.Map<List<OrderOutputModel>>(orders);
        }

        public List<ComboTagGroupOutputModel> MapComboTagGroupDtoToComboTagGroupOutputModel(List<ComboTagGroupDto> combinations)
        {
            return _mapper.Map<List<ComboTagGroupOutputModel>>(combinations);
        }

        public List<SelectProductForClientOutputModel> MapFullProductDtoToSelectProductForClientOutputModel(List<FullProductDto> products)
        {
            return _mapper.Map<List<SelectProductForClientOutputModel>>(products);
        }
        public GroupDto MapGroupInputModelToGroupDto(GroupInputModel groupModel)
        {
            return _mapper.Map<GroupDto>(groupModel);
        }
    }
}