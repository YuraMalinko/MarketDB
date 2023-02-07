using OfferAggregator.Bll.Models;
using OfferAggregator.Bll.Tests.TestCaseSource;
using OfferAggregator.Dal.Models;
using FluentAssertions;

namespace OfferAggregator.Bll.Tests
{
    public class MapperTests
    {
        private Mapper _mapper = Mapper.GetInstance();


        [TestCaseSource(typeof(MapperTestCaseSource), nameof(MapperTestCaseSource.MapProductsDtosToProductModelsTestCaseSource))]

        public void MapProductsDtosToProductModelsTest(List<ProductsDto> baseProductsDto, List<ProductModel> expectedProductModel)
        {
            List<ProductModel> actualProductModel = _mapper.MapProductsDtosToProductModels(baseProductsDto);

            actualProductModel.Should().BeEquivalentTo(expectedProductModel);
        }


        [TestCaseSource(typeof(MapperTestCaseSource), nameof(MapperTestCaseSource.MapProductModelToProductsDtoTestCaseSource))]

        public void MapProductModelToProductsDtoTest(ProductModel baseProductModel, ProductsDto expectedProductsDto)
        {
            ProductsDto actualProductsDto = _mapper.MapProductModelToProductsDto(baseProductModel);

            actualProductsDto.Should().BeEquivalentTo(expectedProductsDto);
        }


        [TestCaseSource(typeof(MapperTestCaseSource), nameof(MapperTestCaseSource.MapStocksWithProductModelToStocksDtoWithProductNameTestCaseSource))]

        public void MapStocksWithProductModelToStocksDtoWithProductNameTest(StocksWithProductModel baseStockModel, StocksDtoWithProductName exepectedStockDto)
        {
            StocksDtoWithProductName actualStockDto = _mapper.MapStocksWithProductModelToStocksDtoWithProductName(baseStockModel);

            actualStockDto.Should().BeEquivalentTo(exepectedStockDto);
        }

        [TestCaseSource(typeof(MapperTestCaseSource), nameof(MapperTestCaseSource.MapStocksDtoWithProductNameToStocksWithProductModelTestCaseSource))]

        public void MapStocksDtoWithProductNameToStocksWithProductModelTest(StocksDtoWithProductName baseStockDto, StocksWithProductModel exepectedStockModel)
        {
            StocksWithProductModel actualStockModel = _mapper.MapStocksDtoWithProductNameToStocksWithProductModel(baseStockDto);

            actualStockModel.Should().BeEquivalentTo(exepectedStockModel);
        }

        [TestCaseSource(typeof(MapperTestCaseSource), nameof(MapperTestCaseSource.MapStocksDtosWithProducrNameToStocksWithProductModelsTestCaseSource))]

        public void MapStocksDtosWithProducrNameToStocksWithProductModelsTest(List<StocksDtoWithProductName> baseStocksDto, List<StocksWithProductModel> expectedStocksModel)
        {
            List<StocksWithProductModel> actualStocksModel = _mapper.MapStocksDtosWithProducrNameToStocksWithProductModels(baseStocksDto);

            actualStocksModel.Should().BeEquivalentTo(expectedStocksModel);
        }
    }
}
