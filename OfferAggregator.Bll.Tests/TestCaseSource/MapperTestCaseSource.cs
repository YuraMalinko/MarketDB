using OfferAggregator.Bll.Models;
using OfferAggregator.Dal.Models;
using System.Collections;
using System.Net.Http.Headers;

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

        public static IEnumerable MapFullProductDtosToFullProductModelsTestCaseSource()
        {

            FullProductDto fullProduct1 = new FullProductDto
            {
                Id = 1,
                Name = "1",
                GroupId = 10,
                Amount = 100,
                AverageScore = 3.5f,
                Tags = new List<TagDto>
                {
                new TagDto{ Id = 1, Name = "tag1"},
                new TagDto{ Id = 2, Name = "tag2"}
                }
            };
            List<FullProductDto> fullProductDtos = new List<FullProductDto> { fullProduct1 };

            FullProductModel fullProductModel1 = new FullProductModel
            {
                Id = 1,
                Name = "1",
                GroupId = 10,
                Amount = 100,
                AverageScore = 3.5f,
                Tags = new List<TagModel>
                {
                new TagModel{ Id = 1, Name = "tag1"},
                new TagModel{ Id = 2, Name = "tag2"}
                }
            };
            List<FullProductModel> expectedFullProductModel = new List<FullProductModel> { fullProductModel1 };

            yield return new object[] { fullProductDtos, expectedFullProductModel };

            fullProductDtos = new List<FullProductDto>();
            expectedFullProductModel = new List<FullProductModel>();

            yield return new object[] { fullProductDtos, expectedFullProductModel };

            TagDto tag1 = new TagDto
            {
                Id = 11,
                Name = "11"
            };
            TagDto tag2 = new TagDto();
            List<TagDto> tags = new List<TagDto> { tag1, tag2 };

            fullProduct1 = new FullProductDto
            {
                Id = 11,
                Name = "11",
                GroupId = 101,
                Amount = 1001,
                AverageScore = 4.2f,
                Tags = tags
            };
            FullProductDto fullProduct2 = new FullProductDto();
            fullProductDtos = new List<FullProductDto> { fullProduct1, fullProduct2 };

            TagModel tagModel1 = new TagModel
            {
                Id = 11,
                Name = "11"
            };
            TagModel tagModel2 = new TagModel();
            List<TagModel> tagModels = new List<TagModel> { tagModel1, tagModel2 };

            fullProductModel1 = new FullProductModel
            {
                Id = 11,
                Name = "11",
                GroupId = 101,
                Amount = 1001,
                AverageScore = 4.2f,
                Tags = tagModels
            };
            FullProductModel fullProductModel2 = new FullProductModel() { Tags = new() };
            expectedFullProductModel = new List<FullProductModel> { fullProductModel1, fullProductModel2 };

            yield return new object[] { fullProductDtos, expectedFullProductModel };
        }
    }
}

