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

        public static IEnumerable GetProductsStatisticTestCaseSource()
        {

        }
    }
}

