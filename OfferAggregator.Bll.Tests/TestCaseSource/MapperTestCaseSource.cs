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


            baseProductsDto = new List<ProductsDto>();

            expectedProductModel = new List<ProductModel>();

            yield return new object[] { baseProductsDto, expectedProductModel };


            ProductsDto productsDto10 = new ProductsDto();
            ProductsDto productsDto20 = new ProductsDto
            {
                Id = 20,
                Name = "two2",
                IsDeleted = true,
                GroupId = 20
            };
            baseProductsDto = new List<ProductsDto> { productsDto10, productsDto20 };

            ProductModel productModel10 = new ProductModel();
            ProductModel productModel20 = new ProductModel
            {
                Id = 20,
                Name = "two2",
                IsDeleted = true,
                GroupId = 20
            };
            expectedProductModel = new List<ProductModel> { productModel10, productModel20 };

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

            yield return new object[] { baseProductModel, expectedProductsDto };
        }


        public static IEnumerable MapProductsStatisticDtosToProductsStatisticModelsTestCaseSource()
        {
            ProductsStatisticDto productsStatistiDto1 = new ProductsStatisticDto
            {
                Id = 1,
                Name = "1",
                SumOfCountofProduct = 10,
                CountOfOrders = 1,
                CountOfClients = 1,
                AverageScore = 4.9f
            };
            ProductsStatisticDto productsStatistiDto2 = new ProductsStatisticDto
            {
                Id = 2,
                Name = "2",
                SumOfCountofProduct = 20,
                CountOfOrders = 2,
                CountOfClients = 2,
                AverageScore = 3.5f
            };
            List<ProductsStatisticDto> productsStatisticDtos = new List<ProductsStatisticDto> { productsStatistiDto1, productsStatistiDto2 };

            ProductsStatisticModel productsStatisticModel1 = new ProductsStatisticModel
            {
                Id = 1,
                Name = "1",
                SumOfCountofProduct = 10,
                CountOfOrders = 1,
                CountOfClients = 1,
                AverageScore = 4.9f
            };
            ProductsStatisticModel productsStatisticModel2 = new ProductsStatisticModel
            {
                Id = 2,
                Name = "2",
                SumOfCountofProduct = 20,
                CountOfOrders = 2,
                CountOfClients = 2,
                AverageScore = 3.5f
            };
            List<ProductsStatisticModel> expectedProductsStatisticModels = new List<ProductsStatisticModel> { productsStatisticModel1, productsStatisticModel2 };

            yield return new object[] { productsStatisticDtos, expectedProductsStatisticModels };

            productsStatisticDtos = new List<ProductsStatisticDto>();

            expectedProductsStatisticModels = new List<ProductsStatisticModel>();

            yield return new object[] { productsStatisticDtos, expectedProductsStatisticModels };

            productsStatistiDto1 = new ProductsStatisticDto
            {
                Id = 13,
                Name = "13",
                SumOfCountofProduct = 103,
                CountOfOrders = 13,
                CountOfClients = 13,
                AverageScore = 1.3f
            };
            productsStatistiDto2 = new ProductsStatisticDto();
            productsStatisticDtos = new List<ProductsStatisticDto> { productsStatistiDto1, productsStatistiDto2 };

            productsStatisticModel1 = new ProductsStatisticModel
            {
                Id = 13,
                Name = "13",
                SumOfCountofProduct = 103,
                CountOfOrders = 13,
                CountOfClients = 13,
                AverageScore = 1.3f
            };
            productsStatisticModel2 = new ProductsStatisticModel();
            expectedProductsStatisticModels = new List<ProductsStatisticModel> { productsStatisticModel1, productsStatisticModel2 };

            yield return new object[] { productsStatisticDtos, expectedProductsStatisticModels };

            productsStatistiDto1 = new ProductsStatisticDto();
            productsStatistiDto2 = new ProductsStatisticDto
            {
                Id = 24,
                Name = "24",
                SumOfCountofProduct = 204,
                CountOfOrders = 24,
                CountOfClients = 24,
                AverageScore = null
            };
            productsStatisticDtos = new List<ProductsStatisticDto> { productsStatistiDto1, productsStatistiDto2 };

            productsStatisticModel1 = new ProductsStatisticModel();
            productsStatisticModel2 = new ProductsStatisticModel
            {
                Id = 24,
                Name = "24",
                SumOfCountofProduct = 204,
                CountOfOrders = 24,
                CountOfClients = 24,
                AverageScore = null
            };
            expectedProductsStatisticModels = new List<ProductsStatisticModel> { productsStatisticModel1, productsStatisticModel2 };

            yield return new object[] { productsStatisticDtos, expectedProductsStatisticModels };

            productsStatistiDto1 = new ProductsStatisticDto
            {
                Id = 15,
                Name = "15"
            };
            productsStatisticDtos = new List<ProductsStatisticDto> { productsStatistiDto1 };

            productsStatisticModel1 = new ProductsStatisticModel
            {
                Id = 15,
                Name = "15"
            };
            expectedProductsStatisticModels = new List<ProductsStatisticModel> { productsStatisticModel1 };

            yield return new object[] { productsStatisticDtos, expectedProductsStatisticModels };
        }
    }
}

