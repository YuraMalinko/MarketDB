using OfferAggregator.Bll.Models;
using OfferAggregator.Dal.Models;
using System.Collections;

namespace OfferAggregator.Bll.Tests.TestCaseSource
{
    public class ProductServiceTestCaseSource
    {
        public static IEnumerable AddProductTestCaseSource()
        {
            ProductInputModel product = new ProductInputModel
            {
                Name = "one",
                GroupId = 10,
                IsDeleted = false
            };
            ProductsDto addProduct = new ProductsDto
            {
                Name = "one",
                GroupId = 10,
                IsDeleted = false
            };
            int groupId = 10;
            GroupDto getGroup = new GroupDto
            {
                Id = 10,
                Name = "group for one"
            };
            int result = 1;
            int expectedProductId = 1;

            yield return new object[] { groupId, getGroup, addProduct, result, product, expectedProductId };
        }

        public static IEnumerable GetAllProductsTestCaseSource()
        {
            {
                ProductsDto productsDto1 = new ProductsDto
                {
                    Id = 100,
                    Name = "100",
                    GroupId = 11
                };
                ProductsDto productsDto2 = new ProductsDto
                {
                    Id = 200,
                    Name = "200",
                    GroupId = 22
                };
                List<ProductsDto> allProducts = new List<ProductsDto> { productsDto1, productsDto2 };

                ProductOutputModel productsModel1 = new ProductOutputModel
                {
                    Id = 100,
                    Name = "100",
                    GroupId = 11
                };
                ProductOutputModel productsModel2 = new ProductOutputModel
                {
                    Id = 200,
                    Name = "200",
                    GroupId = 22
                };
                List<ProductOutputModel> expectedProductModels = new List<ProductOutputModel> { productsModel1, productsModel2 };

                yield return new object[] { allProducts, expectedProductModels };

                productsDto1 = new ProductsDto();
                productsDto2 = new ProductsDto
                {
                    Id = 2002,
                    Name = "2002",
                    GroupId = 222
                };
                allProducts = new List<ProductsDto> { productsDto1, productsDto2 };

                productsModel1 = new ProductOutputModel();
                productsModel2 = new ProductOutputModel
                {
                    Id = 2002,
                    Name = "2002",
                    GroupId = 222
                };
                expectedProductModels = new List<ProductOutputModel> { productsModel1, productsModel2 };

                yield return new object[] { allProducts, expectedProductModels };

                productsDto1 = new ProductsDto();
                productsDto2 = new ProductsDto();
                allProducts = new List<ProductsDto> { productsDto1, productsDto2 };

                productsModel1 = new ProductOutputModel();
                productsModel2 = new ProductOutputModel();
                expectedProductModels = new List<ProductOutputModel> { productsModel1, productsModel2 };

                yield return new object[] { allProducts, expectedProductModels };

                allProducts = new List<ProductsDto>();

                expectedProductModels = new List<ProductOutputModel>();

                yield return new object[] { allProducts, expectedProductModels };
            }
        }

        public static IEnumerable GetAllProductsByGroupIdTestCaseSource()
        {
            ProductsDto productsDto1 = new ProductsDto
            {
                Id = 11,
                Name = "11",
                GroupId = 10
            };
            ProductsDto productsDto2 = new ProductsDto
            {
                Id = 12,
                Name = "12",
                GroupId = 10
            };
            List<ProductsDto> allProducts = new List<ProductsDto> { productsDto1, productsDto2 };

            ProductOutputModel productsModel1 = new ProductOutputModel
            {
                Id = 11,
                Name = "11",
                GroupId = 10
            };
            ProductOutputModel productsModel2 = new ProductOutputModel
            {
                Id = 12,
                Name = "12",
                GroupId = 10
            };
            int groupId = 10;
            List<ProductOutputModel> expectedProductModels = new List<ProductOutputModel> { productsModel1, productsModel2 };

            yield return new object[] { allProducts, expectedProductModels, groupId };

            productsDto1 = new ProductsDto
            {
                Id = 112,
                Name = "112",
                GroupId = 102
            };
            productsDto2 = new ProductsDto();
            allProducts = new List<ProductsDto> { productsDto1, productsDto2 };

            productsModel1 = new ProductOutputModel
            {
                Id = 112,
                Name = "112",
                GroupId = 102
            };
            productsModel2 = new ProductOutputModel();
            groupId = 102;
            expectedProductModels = new List<ProductOutputModel> { productsModel1, productsModel2 };

            yield return new object[] { allProducts, expectedProductModels, groupId };

            allProducts = new List<ProductsDto>();
            groupId = 1023;
            expectedProductModels = new List<ProductOutputModel>();

            yield return new object[] { allProducts, expectedProductModels, groupId };
        }

        public static IEnumerable UpdateProductTestCaseSource()
        {
            ProductInputModel product = new ProductInputModel
            {
                Id = 111,
                Name = "111",
                GroupId = 1,
                IsDeleted = false
            };
            ProductsDto productDto = new ProductsDto
            {
                Id = 111,
                Name = "111",
                GroupId = 1,
                IsDeleted = false
            };
            GroupDto getGroup = new GroupDto
            {
                Id = 1,
                Name = "group1"
            };
            ProductsDto getProductDto = new ProductsDto
            {
                Id = 111,
                Name = "111",
                GroupId = 1,
                IsDeleted = false
            };
            bool result = true;
            bool expected = true;

            yield return new object[] { getGroup, getProductDto, productDto, product, expected, result };
        }

        public static IEnumerable UpdateProductTest_WhenProductIsNotExistTestCaseSource()
        {
            ProductInputModel product = new ProductInputModel
            {
                Id = 1112,
                Name = "1112",
                GroupId = 12,
                IsDeleted = false
            };
            ProductsDto productDto = new ProductsDto
            {
                Id = 1112,
                Name = "1112",
                GroupId = 12,
                IsDeleted = false
            };
            GroupDto getGroup = new GroupDto
            {
                Id = 12,
                Name = "group12"
            };
            ProductsDto getProductDto = null;

            bool expected = false;

            yield return new object[] { getGroup, getProductDto, productDto, product, expected };
        }

        public static IEnumerable UpdateProductTest_WhenProductIsDeletedTestCaseSource()
        {
            ProductInputModel product = new ProductInputModel
            {
                Id = 11123,
                Name = "11123",
                GroupId = 123,
                IsDeleted = true
            };
            ProductsDto productDto = new ProductsDto
            {
                Id = 11123,
                Name = "11123",
                GroupId = 123,
                IsDeleted = true
            };
            GroupDto getGroup = new GroupDto
            {
                Id = 123,
                Name = "group123"
            };
            ProductsDto getProductDto = new ProductsDto
            {
                Id = 11123,
                Name = "11123",
                GroupId = 123,
                IsDeleted = true
            };

            bool expected = false;

            yield return new object[] { getGroup, getProductDto, productDto, product, expected };
        }

        public static IEnumerable UpdateProductTest_WhenGroupIsNotExistTestCaseSource()
        {
            ProductInputModel product = new ProductInputModel
            {
                Id = 111234,
                Name = "111234",
                GroupId = 1234,
                IsDeleted = false
            };
            ProductsDto productDto = new ProductsDto
            {
                Id = 111234,
                Name = "111234",
                GroupId = 1234,
                IsDeleted = false
            };
            GroupDto getGroup = null;
            ProductsDto getProductDto = new ProductsDto
            {
                Id = 111234,
                Name = "111234",
                GroupId = 8,
                IsDeleted = false
            };

            bool expected = false;

            yield return new object[] { getGroup, getProductDto, productDto, product, expected };
        }

        public static IEnumerable UpdateProductTest_WhenNameNotUnigue_ShouldExceptionTestCaseSource()
        {
            ProductInputModel product = new ProductInputModel
            {
                Id = 1112345,
                Name = "1112345",
                GroupId = 12345,
                IsDeleted = false
            };
            ProductsDto productDto = new ProductsDto
            {
                Id = 1112345,
                Name = "1112345",
                GroupId = 12345,
                IsDeleted = false
            };
            GroupDto getGroup = new GroupDto
            {
                Id = 12345,
                Name = "group12345"
            };
            ProductsDto getProductDto = new ProductsDto
            {
                Id = 1112345,
                Name = "1112345",
                GroupId = 12345,
                IsDeleted = false
            };

            bool expected = false;

            yield return new object[] { getGroup, getProductDto, productDto, product, expected };
        }

        public static IEnumerable DeleteProductTestCaseSource()
        {
            int productId = 69;
            bool boolProduct = true;
            bool boolReviewAndStock = true;
            bool boolTag = true;

            bool expected = true;

            yield return new object[] { productId, boolProduct, boolReviewAndStock, boolTag, expected };

            productId = 22;
            boolProduct = true;
            boolReviewAndStock = false;
            boolTag = true;

            expected = true;

            yield return new object[] { productId, boolProduct, boolReviewAndStock, boolTag, expected };

            productId = 39;
            boolProduct = true;
            boolReviewAndStock = true;
            boolTag = false;

            expected = true;

            yield return new object[] { productId, boolProduct, boolReviewAndStock, boolTag, expected };

            productId = 47;
            boolProduct = true;
            boolReviewAndStock = false;
            boolTag = false;

            expected = true;

            yield return new object[] { productId, boolProduct, boolReviewAndStock, boolTag, expected };
        }

        public static IEnumerable DeleteProductTest_WhenProductIdIsNotExistTestCaseSource()
        {
            int productId = 666;
            bool boolProduct = false;

            bool expected = false;

            yield return new object[] { productId, boolProduct, expected };
        }

        public static IEnumerable RegistrateProductInStockTest_WhenAddNewProductTestCaseSource()
        {
            StocksWithProductInputModel stockProductModel = new StocksWithProductInputModel
            {
                Name = "one",
                ProductId = 1,
                Amount = 101
            };
            StocksDtoWithProductName stockProductDto = new StocksDtoWithProductName
            {
                Name = "one",
                ProductId = 1,
                Amount = 101
            };
            ProductsDto getProductDto = new ProductsDto
            {
                Id = 1,
                Name = "one",
                GroupId = 10,
                IsDeleted = false
            };
            StocksDtoWithProductName getAmountByProductId = new StocksDtoWithProductName
            {
                Amount = 0,
                Name = "one",
                ProductId = 1
            };
            bool resultOfUpdate = true;
            bool expected = true;

            yield return new object[] { stockProductDto, getProductDto, getAmountByProductId, resultOfUpdate, expected, stockProductModel };
        }

        public static IEnumerable RegistrateProductInStockTest_WhenUpdateExistProductTestCaseSource()
        {
            StocksWithProductInputModel stockProductModel = new StocksWithProductInputModel
            {
                Name = "two",
                ProductId = 2,
                Amount = 200
            };
            StocksDtoWithProductName stockProductDto = new StocksDtoWithProductName
            {
                Name = "two",
                ProductId = 2,
                Amount = 200
            };
            ProductsDto getProductDto = new ProductsDto
            {
                Id = 2,
                Name = "two",
                GroupId = 20,
                IsDeleted = false
            };
            StocksDtoWithProductName getAmountByProductId = new StocksDtoWithProductName
            {
                Name = "two",
                ProductId = 2,
                Amount = 10
            };
            StocksDtoWithProductName stockUpdateProductDto = new StocksDtoWithProductName
            {
                Name = "two",
                ProductId = 2,
                Amount = 210
            };
            bool resultUpdate = true;
            bool expected = true;

            yield return new object[] { stockProductDto, getProductDto, getAmountByProductId, resultUpdate, expected, stockProductModel, stockUpdateProductDto };
        }

        public static IEnumerable RegistrateProductInStockTest_WhenProductIsNotExistTestCaseSource()
        {
            StocksWithProductInputModel stockProductModel = new StocksWithProductInputModel
            {
                Name = "one3",
                ProductId = 13,
                Amount = 1013
            };
            StocksDtoWithProductName stockProductDto = new StocksDtoWithProductName
            {
                Name = "one3",
                ProductId = 13,
                Amount = 1013
            };
            ProductsDto getProductDto = null;
            bool expected = false;

            yield return new object[] { stockProductDto, getProductDto, stockProductModel, expected };
        }

        public static IEnumerable RegistrateProductInStockTest_WhenAmountLessZeroTestCaseSource()
        {
            StocksWithProductInputModel stockProductModel = new StocksWithProductInputModel
            {
                Name = "one34",
                ProductId = 134,
                Amount = -9
            };
            StocksDtoWithProductName stockProductDto = new StocksDtoWithProductName
            {
                Name = "one34",
                ProductId = 134,
                Amount = -9
            };
            ProductsDto getProductDto = new ProductsDto
            {
                Id = 134,
                Name = "one34",
                GroupId = 13,
                IsDeleted = false,
            };
            bool expected = false;

            yield return new object[] { stockProductDto, getProductDto, stockProductModel, expected };
        }

        public static IEnumerable RegistrateProductInStockTest_WhenProductIsDeletedTestCaseSource()
        {
            StocksWithProductInputModel stockProductModel = new StocksWithProductInputModel
            {
                Name = "one345",
                ProductId = 1345,
                Amount = 5
            };
            StocksDtoWithProductName stockProductDto = new StocksDtoWithProductName
            {
                Name = "one345",
                ProductId = 1345,
                Amount = 5
            };
            ProductsDto getProductDto = new ProductsDto
            {
                Id = 1345,
                Name = "one345",
                GroupId = 135,
                IsDeleted = true,
            };
            bool expected = false;

            yield return new object[] { stockProductDto, getProductDto, stockProductModel, expected };
        }

        public static IEnumerable GetFullProductByIdTestCaseSource()
        {
            FullProductDto fullProductDto = new FullProductDto
            {
                Id = 117,
                Name = "117",
                GroupId = 1107,
                Amount = 1007,
                Tags = new List<TagDto>
            {
            new TagDto{ Id = 17, Name = "17"},
            new TagDto{ Id = 27, Name = "27"}
            },
                AverageScore = 2.7f
            };

            FullProductOutputModel expectedFullProductModel = new FullProductOutputModel
            {
                Id = 117,
                Name = "117",
                GroupId = 1107,
                Amount = 1007,
                Tags = new List<TagOutputModel>
            {
            new TagOutputModel{ Id = 17, Name = "17"},
            new TagOutputModel{ Id = 27, Name = "27"}
            },
                AverageScore = 2.7f
            };
            int productId = 117;

            yield return new object[] { productId, fullProductDto, expectedFullProductModel };


            fullProductDto = new FullProductDto();
            expectedFullProductModel = new FullProductOutputModel { Tags = new() };
            productId = 9;

            yield return new object[] { productId, fullProductDto, expectedFullProductModel };


            fullProductDto = new FullProductDto
            {
                Id = 1138,
                Name = "1138",
                GroupId = 11038,
                Amount = 10038,
                Tags = new List<TagDto>(),
                AverageScore = 3
            };

            expectedFullProductModel = new FullProductOutputModel
            {
                Id = 1138,
                Name = "1138",
                GroupId = 11038,
                Amount = 10038,
                Tags = new List<TagOutputModel>(),
                AverageScore = 3
            };
            productId = 1138;

            yield return new object[] { productId, fullProductDto, expectedFullProductModel };

            fullProductDto = new FullProductDto
            {
                Id = 11386,
                Name = "11386",
                GroupId = 110386,
                Amount = 100386,
                Tags = new List<TagDto>()
            };

            expectedFullProductModel = new FullProductOutputModel
            {
                Id = 11386,
                Name = "11386",
                GroupId = 110386,
                Amount = 100386,
                Tags = new List<TagOutputModel>()
            };
            productId = 11386;

            yield return new object[] { productId, fullProductDto, expectedFullProductModel };
        }

        public static IEnumerable GetFullProducsTestCaseSource()
        {
            FullProductDto fullProduct1 = new FullProductDto
            {
                Id = 15,
                Name = "15",
                GroupId = 105,
                Amount = 1005,
                AverageScore = 4.6f,
                Tags = new List<TagDto>
                {
                new TagDto{ Id = 15, Name = "tag15"},
                new TagDto{ Id = 25, Name = "tag25"}
                }
            };
            List<FullProductDto> fullProductDtos = new List<FullProductDto> { fullProduct1 };

            FullProductOutputModel fullProductModel1 = new FullProductOutputModel
            {
                Id = 15,
                Name = "15",
                GroupId = 105,
                Amount = 1005,
                AverageScore = 4.6f,
                Tags = new List<TagOutputModel>
                {
                new TagOutputModel{ Id = 15, Name = "tag15"},
                new TagOutputModel{ Id = 25, Name = "tag25"}
                }
            };
            List<FullProductOutputModel> expectedFullProductModels = new List<FullProductOutputModel> { fullProductModel1 };

            yield return new object[] { fullProductDtos, expectedFullProductModels };

            fullProductDtos = new List<FullProductDto>();
            expectedFullProductModels = new List<FullProductOutputModel>();

            yield return new object[] { fullProductDtos, expectedFullProductModels };

            TagDto tag1 = new TagDto
            {
                Id = 116,
                Name = "116"
            };
            TagDto tag2 = new TagDto();
            List<TagDto> tags = new List<TagDto> { tag1, tag2 };

            fullProduct1 = new FullProductDto
            {
                Id = 116,
                Name = "116",
                GroupId = 1016,
                Amount = 10016,
                AverageScore = 3f,
                Tags = tags
            };
            FullProductDto fullProduct2 = new FullProductDto();
            fullProductDtos = new List<FullProductDto> { fullProduct1, fullProduct2 };

            TagOutputModel tagModel1 = new TagOutputModel
            {
                Id = 116,
                Name = "116"
            };
            TagOutputModel tagModel2 = new TagOutputModel();
            List<TagOutputModel> tagModels = new List<TagOutputModel> { tagModel1, tagModel2 };

            fullProductModel1 = new FullProductOutputModel
            {
                Id = 116,
                Name = "116",
                GroupId = 1016,
                Amount = 10016,
                AverageScore = 3f,
                Tags = tagModels
            };
            FullProductOutputModel fullProductModel2 = new FullProductOutputModel() { Tags = new() };
            expectedFullProductModels = new List<FullProductOutputModel> { fullProductModel1, fullProductModel2 };

            yield return new object[] { fullProductDtos, expectedFullProductModels };

            fullProduct1 = new FullProductDto
            {
                Id = 154,
                Name = "154",
                GroupId = 1054,
                Amount = 10054,
                Tags = new List<TagDto>
                {
                new TagDto{ Id = 154, Name = "tag154"},
                new TagDto{ Id = 254, Name = "tag254"}
                }
            };
            fullProduct2 = new FullProductDto();
            fullProductDtos = new List<FullProductDto> { fullProduct1, fullProduct2 };

            fullProductModel1 = new FullProductOutputModel
            {
                Id = 154,
                Name = "154",
                GroupId = 1054,
                Amount = 10054,
                Tags = new List<TagOutputModel>
                {
                new TagOutputModel{ Id = 154, Name = "tag154"},
                new TagOutputModel{ Id = 254, Name = "tag254"}
                }
            };
            fullProductModel2 = new FullProductOutputModel { Tags = new() };
            expectedFullProductModels = new List<FullProductOutputModel> { fullProductModel1, fullProductModel2 };

            yield return new object[] { fullProductDtos, expectedFullProductModels };
        }

        public static IEnumerable GetProductsStatisticTestCaseSource()
        {
            ProductsStatisticDto productsStatistiDto1 = new ProductsStatisticDto
            {
                Id = 19,
                Name = "19",
                SumOfCountofProduct = 109,
                CountOfOrders = 9,
                CountOfClients = 7,
                AverageScore = 3.5f
            };
            ProductsStatisticDto productsStatistiDto2 = new ProductsStatisticDto
            {
                Id = 29,
                Name = "29",
                SumOfCountofProduct = 209,
                CountOfOrders = 8,
                CountOfClients = 5,
                AverageScore = 4f
            };
            List<ProductsStatisticDto> productsStatisticDtos = new List<ProductsStatisticDto> { productsStatistiDto1, productsStatistiDto2 };

            ProductsStatisticOutputModel productsStatisticModel1 = new ProductsStatisticOutputModel
            {
                Id = 19,
                Name = "19",
                SumOfCountofProduct = 109,
                CountOfOrders = 9,
                CountOfClients = 7,
                AverageScore = 3.5f
            };
            ProductsStatisticOutputModel productsStatisticModel2 = new ProductsStatisticOutputModel
            {
                Id = 29,
                Name = "29",
                SumOfCountofProduct = 209,
                CountOfOrders = 8,
                CountOfClients = 5,
                AverageScore = 4f
            };
            List<ProductsStatisticOutputModel> expectedProductsStatisticModels = new List<ProductsStatisticOutputModel> { productsStatisticModel1, productsStatisticModel2 };

            yield return new object[] { productsStatisticDtos, expectedProductsStatisticModels };


            productsStatisticDtos = new List<ProductsStatisticDto>();

            expectedProductsStatisticModels = new List<ProductsStatisticOutputModel>();

            yield return new object[] { productsStatisticDtos, expectedProductsStatisticModels };


            productsStatistiDto1 = new ProductsStatisticDto
            {
                Id = 137,
                Name = "137",
                SumOfCountofProduct = 1037,
                CountOfOrders = 137,
                CountOfClients = 130,
                AverageScore = 3.9f
            };
            productsStatistiDto2 = new ProductsStatisticDto();
            productsStatisticDtos = new List<ProductsStatisticDto> { productsStatistiDto1, productsStatistiDto2 };

            productsStatisticModel1 = new ProductsStatisticOutputModel
            {
                Id = 137,
                Name = "137",
                SumOfCountofProduct = 1037,
                CountOfOrders = 137,
                CountOfClients = 130,
                AverageScore = 3.9f
            };
            productsStatisticModel2 = new ProductsStatisticOutputModel();
            expectedProductsStatisticModels = new List<ProductsStatisticOutputModel> { productsStatisticModel1, productsStatisticModel2 };

            yield return new object[] { productsStatisticDtos, expectedProductsStatisticModels };

            productsStatistiDto1 = new ProductsStatisticDto();
            productsStatistiDto2 = new ProductsStatisticDto
            {
                Id = 246,
                Name = "246",
                SumOfCountofProduct = 2046,
                CountOfOrders = 246,
                CountOfClients = 246,
                AverageScore = null
            };
            productsStatisticDtos = new List<ProductsStatisticDto> { productsStatistiDto1, productsStatistiDto2 };

            productsStatisticModel1 = new ProductsStatisticOutputModel();
            productsStatisticModel2 = new ProductsStatisticOutputModel
            {
                Id = 246,
                Name = "246",
                SumOfCountofProduct = 2046,
                CountOfOrders = 246,
                CountOfClients = 246,
                AverageScore = null
            };
            expectedProductsStatisticModels = new List<ProductsStatisticOutputModel> { productsStatisticModel1, productsStatisticModel2 };

            yield return new object[] { productsStatisticDtos, expectedProductsStatisticModels };

            productsStatistiDto1 = new ProductsStatisticDto
            {
                Id = 152,
                Name = "152"
            };
            productsStatisticDtos = new List<ProductsStatisticDto> { productsStatistiDto1 };

            productsStatisticModel1 = new ProductsStatisticOutputModel
            {
                Id = 152,
                Name = "152"
            };
            expectedProductsStatisticModels = new List<ProductsStatisticOutputModel> { productsStatisticModel1 };

            yield return new object[] { productsStatisticDtos, expectedProductsStatisticModels };
        }
    }
}

