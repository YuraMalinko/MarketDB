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

        [TestCaseSource(typeof(MapperTestCaseSource), nameof(MapperTestCaseSource.MapStocksWithProductModelToStocksWithProductModelTestCaseSource))]

        public void MapStocksWithProductModelToStocksDtoWithProductNameTest(StocksWithProductModel baseStockModel, StocksDtoWithProductName exepectedStockDto)
        {
            StocksDtoWithProductName actualStockDto = _mapper.MapStocksWithProductModelToStocksWithProductModel(baseStockModel);

            actualStockDto.Should().BeEquivalentTo(exepectedStockDto);
        }

        [TestCaseSource(typeof(MapperTestCaseSource), nameof(MapperTestCaseSource.MapFullProductDtosToFullProductModelsTestCaseSource))]
        public void MapFullProductDtosToFullProductModelsTest(List<FullProductDto> fullProductDtos, List<FullProductModel> expectedFullProductModels)
        {
            List<FullProductModel> actualFullProductModels = _mapper.MapFullProductDtosToFullProductModels(fullProductDtos);

            actualFullProductModels.Should().BeEquivalentTo(expectedFullProductModels);
        }

        [TestCaseSource(typeof(MapperTestCaseSource), nameof(MapperTestCaseSource.MapFullProductDtoToFullProductModelTestTestCaseSource))]
        public void MapFullProductDtoToFullProductModelTest(FullProductDto fullProductDto, FullProductModel expectedFullProductModel)
        {
            FullProductModel actualFullProductModel = _mapper.MapFullProductDtoToFullProductModel(fullProductDto);

            actualFullProductModel.Should().BeEquivalentTo(expectedFullProductModel);
        }

        [TestCaseSource(typeof(MapperTestCaseSource), nameof(MapperTestCaseSource.MapProductsStatisticDtosToProductsStatisticModelsTestCaseSource))]
        public void MapProductsStatisticDtosToProductsStatisticModelsTest(List<ProductsStatisticDto> productsStatisticDtos, List<ProductsStatisticModel> expectedProductsStatisticModels)
        {
            List<ProductsStatisticModel> actualProductsStatisticModels = _mapper.MapProductsStatisticDtosToProductsStatisticModels(productsStatisticDtos);

            actualProductsStatisticModels.Should().BeEquivalentTo(expectedProductsStatisticModels);
        }


        [TestCaseSource(typeof(MapperTestCaseSource), nameof(MapperTestCaseSource.MapCreatingOrderModelToCreatingOrderDtoTestCaseSource))]
        public void MapCreatingOrderModelToCreatingOrderDtoTest(CreatingOrderModel creatingOrderModel, CreatingOrderDto expectedCreatingOrderDto)
        {
            CreatingOrderDto actualCreatingOrderDto = _mapper.MapCreatingOrderModelToCreatingOrderDto(creatingOrderModel);

            actualCreatingOrderDto.Should().BeEquivalentTo(expectedCreatingOrderDto);
        }
    }
}
