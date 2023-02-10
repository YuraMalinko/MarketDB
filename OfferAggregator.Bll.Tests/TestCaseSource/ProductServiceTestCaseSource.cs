using OfferAggregator.Bll.Models;
using OfferAggregator.Dal.Models;
using System.Collections;

namespace OfferAggregator.Bll.Tests.TestCaseSource
{
    public class ProductServiceTestCaseSource
    {
        public static IEnumerable AddProductTestCaseSource()
        {
            ProductModel product = new ProductModel
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

                ProductModel productsModel1 = new ProductModel
                {
                    Id = 100,
                    Name = "100",
                    GroupId = 11
                };
                ProductModel productsModel2 = new ProductModel
                {
                    Id = 200,
                    Name = "200",
                    GroupId = 22
                };
                List<ProductModel> expectedProductModels = new List<ProductModel> { productsModel1, productsModel2 };

                yield return new object[] { allProducts, expectedProductModels };

                productsDto1 = new ProductsDto();
                productsDto2 = new ProductsDto
                {
                    Id = 2002,
                    Name = "2002",
                    GroupId = 222
                };
                allProducts = new List<ProductsDto> { productsDto1, productsDto2 };

                productsModel1 = new ProductModel();
                productsModel2 = new ProductModel
                {
                    Id = 2002,
                    Name = "2002",
                    GroupId = 222
                };
                expectedProductModels = new List<ProductModel> { productsModel1, productsModel2 };

                yield return new object[] { allProducts, expectedProductModels };

                productsDto1 = new ProductsDto();
                productsDto2 = new ProductsDto();
                allProducts = new List<ProductsDto> { productsDto1, productsDto2 };

                productsModel1 = new ProductModel();
                productsModel2 = new ProductModel();
                expectedProductModels = new List<ProductModel> { productsModel1, productsModel2 };

                yield return new object[] { allProducts, expectedProductModels };

                allProducts = new List<ProductsDto>();

                expectedProductModels = new List<ProductModel>();

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

            ProductModel productsModel1 = new ProductModel
            {
                Id = 11,
                Name = "11",
                GroupId = 10
            };
            ProductModel productsModel2 = new ProductModel
            {
                Id = 12,
                Name = "12",
                GroupId = 10
            };
            int groupId = 10;
            List<ProductModel> expectedProductModels = new List<ProductModel> { productsModel1, productsModel2 };

            yield return new object[] { allProducts, expectedProductModels, groupId };

            productsDto1 = new ProductsDto
            {
                Id = 112,
                Name = "112",
                GroupId = 102
            };
            productsDto2 = new ProductsDto();
            allProducts = new List<ProductsDto> { productsDto1, productsDto2 };

            productsModel1 = new ProductModel
            {
                Id = 112,
                Name = "112",
                GroupId = 102
            };
            productsModel2 = new ProductModel();
            groupId = 102;
            expectedProductModels = new List<ProductModel> { productsModel1, productsModel2 };

            yield return new object[] { allProducts, expectedProductModels, groupId };

            allProducts = new List<ProductsDto>();
            groupId = 1023;
            expectedProductModels = new List<ProductModel>();

            yield return new object[] { allProducts, expectedProductModels, groupId };
        }

        public static IEnumerable UpdateProductTestCaseSource()
        {
            ProductModel product = new ProductModel
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
            ProductModel product = new ProductModel
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
            ProductModel product = new ProductModel
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
            ProductModel product = new ProductModel
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
            ProductModel product = new ProductModel
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

            FullProductModel expectedFullProductModel = new FullProductModel
            {
                Id = 117,
                Name = "117",
                GroupId = 1107,
                Amount = 1007,
                Tags = new List<TagModel>
            {
            new TagModel{ Id = 17, Name = "17"},
            new TagModel{ Id = 27, Name = "27"}
            },
                AverageScore = 2.7f
            };
            int productId = 117;

            yield return new object[] { productId, fullProductDto, expectedFullProductModel };


            fullProductDto = new FullProductDto();
            expectedFullProductModel = new FullProductModel { Tags = new ()} ;
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

            expectedFullProductModel = new FullProductModel
            {
                Id = 1138,
                Name = "1138",
                GroupId = 11038,
                Amount = 10038,
                Tags = new List<TagModel>(),
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

            expectedFullProductModel = new FullProductModel
            {
                Id = 11386,
                Name = "11386",
                GroupId = 110386,
                Amount = 100386,
                Tags = new List<TagModel>()
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

            FullProductModel fullProductModel1 = new FullProductModel
            {
                Id = 15,
                Name = "15",
                GroupId = 105,
                Amount = 1005,
                AverageScore = 4.6f,
                Tags = new List<TagModel>
                {
                new TagModel{ Id = 15, Name = "tag15"},
                new TagModel{ Id = 25, Name = "tag25"}
                }
            };
            List<FullProductModel> expectedFullProductModels = new List<FullProductModel> { fullProductModel1 };

            yield return new object[] { fullProductDtos, expectedFullProductModels };

            fullProductDtos = new List<FullProductDto>();
            expectedFullProductModels = new List<FullProductModel>();

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

            TagModel tagModel1 = new TagModel
            {
                Id = 116,
                Name = "116"
            };
            TagModel tagModel2 = new TagModel();
            List<TagModel> tagModels = new List<TagModel> { tagModel1, tagModel2 };

            fullProductModel1 = new FullProductModel
            {
                Id = 116,
                Name = "116",
                GroupId = 1016,
                Amount = 10016,
                AverageScore = 3f,
                Tags = tagModels
            };
            FullProductModel fullProductModel2 = new FullProductModel() { Tags = new() };
            expectedFullProductModels = new List<FullProductModel> { fullProductModel1, fullProductModel2 };

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

            fullProductModel1 = new FullProductModel
            {
                Id = 154,
                Name = "154",
                GroupId = 1054,
                Amount = 10054,
                Tags = new List<TagModel>
                {
                new TagModel{ Id = 154, Name = "tag154"},
                new TagModel{ Id = 254, Name = "tag254"}
                }
            };
            fullProductModel2 = new FullProductModel { Tags = new() };
            expectedFullProductModels = new List<FullProductModel> { fullProductModel1, fullProductModel2 };

            yield return new object[] { fullProductDtos, expectedFullProductModels };
        }
    }
}

