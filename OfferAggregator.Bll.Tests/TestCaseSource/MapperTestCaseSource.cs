using OfferAggregator.Bll.Models;
using OfferAggregator.Dal.Models;
using System.Collections;

namespace OfferAggregator.Bll.Tests.TestCaseSource
{
    public class MapperTestCaseSource
    {
        public static IEnumerable MapProductsDtosToProductModelsTestCaseSource()
        {
            ProductsDto productsDto1 = new ProductsDto
            {
                Id = 1,
                Name = "one",
                IsDeleted = false,
                GroupId = 1
            };
            ProductsDto productsDto2 = new ProductsDto
            {
                Id = 2,
                Name = "two",
                IsDeleted = false,
                GroupId = 2
            };
            List<ProductsDto> baseProductsDto = new List<ProductsDto> { productsDto1, productsDto2 };

            ProductModel productModel1 = new ProductModel
            {
                Id = 1,
                Name = "one",
                IsDeleted = false,
                GroupId = 1
            };
            ProductModel productModel2 = new ProductModel
            {
                Id = 2,
                Name = "two",
                IsDeleted = false,
                GroupId = 2
            };
            List<ProductModel> expectedProductModel = new List<ProductModel> { productModel1, productModel2 };

            yield return new object[] { baseProductsDto, expectedProductModel };
        }

        public static IEnumerable MapProductModelToProductsDtoTestCaseSource()
        {
            ProductModel baseProductModel = new ProductModel
            {
                Id = 10,
                Name = "ten",
                IsDeleted = false,
                GroupId = 12
            };
            ProductsDto expectedProductsDto = new ProductsDto
            {
                Id = 10,
                Name = "ten",
                IsDeleted = false,
                GroupId = 12
            };

            yield return new object[] { baseProductModel , expectedProductsDto };
        }
    }
}