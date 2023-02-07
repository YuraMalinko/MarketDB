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
                    cfg.CreateMap<StocksWithProductModel, StocksDtoWithProductName>();
                    cfg.CreateMap<StocksDtoWithProductName, StocksWithProductModel>();
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

        public StocksDtoWithProductName MapStocksWithProductModelToStocksDtoWithProductName(StocksWithProductModel stockProductModel)
        {
            return _mapper.Map<StocksDtoWithProductName>(stockProductModel);
        }

        public StocksWithProductModel MapStocksDtoWithProductNameToStocksWithProductModel(StocksDtoWithProductName stockProductDto)
        {
            return _mapper.Map<StocksWithProductModel>(stockProductDto);
        }

        public List<StocksWithProductModel> MapStocksDtosWithProducrNameToStocksWithProductModels(List<StocksDtoWithProductName> stocksDto)
        {
            return _mapper.Map<List<StocksWithProductModel>>(stocksDto);
        }
    }
}
