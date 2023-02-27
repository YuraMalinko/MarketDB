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
            List<FullProductModel> expectedFullProductModels = new List<FullProductModel> { fullProductModel1 };

            yield return new object[] { fullProductDtos, expectedFullProductModels };

            fullProductDtos = new List<FullProductDto>();
            expectedFullProductModels = new List<FullProductModel>();

            yield return new object[] { fullProductDtos, expectedFullProductModels };

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
            expectedFullProductModels = new List<FullProductModel> { fullProductModel1, fullProductModel2 };

            yield return new object[] { fullProductDtos, expectedFullProductModels };
        }

        public static IEnumerable MapFullProductDtoToFullProductModelTestTestCaseSource()
        {
            FullProductDto fullProductDto = new FullProductDto
            {
                Id = 7,
                Name = "7",
                GroupId = 70,
                Amount = 700,
                AverageScore = 34.5f,
                Tags = new List<TagDto>
                {
                new TagDto{ Id = 10, Name = "tag10"},
                new TagDto{ Id = 20, Name = "tag20"}
                }
            };

            FullProductModel expectedFullProductModel = new FullProductModel
            {
                Id = 7,
                Name = "7",
                GroupId = 70,
                Amount = 700,
                AverageScore = 34.5f,
                Tags = new List<TagModel>
                {
                new TagModel{ Id = 10, Name = "tag10"},
                new TagModel{ Id = 20, Name = "tag20"}
                }
            };

            yield return new object[] { fullProductDto, expectedFullProductModel };

            fullProductDto = new FullProductDto
            {
                Id = 7,
                Name = "7",
                GroupId = 70,
                Amount = 700,
                AverageScore = 34.5f,
                Tags = new List<TagDto>()
            };

            expectedFullProductModel = new FullProductModel
            {
                Id = 7,
                Name = "7",
                GroupId = 70,
                Amount = 700,
                AverageScore = 34.5f,
                Tags = new List<TagModel>()
            };

            yield return new object[] { fullProductDto, expectedFullProductModel };
        }

        public static IEnumerable MapStocksWithProductModelToStocksWithProductModelTestCaseSource()
        {
            StocksWithProductModel baseStockModel = new StocksWithProductModel
            {
                Amount = 10,
                ProductId = 1,
                Name = "one"
            };

            StocksDtoWithProductName exepectedStockDto = new StocksDtoWithProductName
            {
                Amount = 10,
                ProductId = 1,
                Name = "one"
            };

            yield return new object[] { baseStockModel, exepectedStockDto };
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

        public static IEnumerable MapCreatingOrderModelToCreatingOrderDtoTestCaseSource()
        {
            DateTime date1 = new DateTime(2023, 01, 29, 10, 00, 00);
            DateTime complitionDate = new DateTime(2023, 01, 30, 10, 00, 00);
            OrderModel orderModel = new OrderModel
            {
                Id = 4,
                ManagerId = 6,
                ClientId = 1,
                DateCreate = date1,
                ComplitionDate = complitionDate,
                Manager = new CurrentManager(6, "Andrew", "qqq"),
                Client = new ClientInputModel
                {
                    Name = "Medvedev",
                    PhoneNumber = "8800"
                }
            };
            ProductCountModel pr1 = new ProductCountModel
            {
                Id = 1,
                Name = "Kurica 1",
                Count = 10
            };
            ProductCountModel pr2 = new ProductCountModel
            {
                Id = 2,
                Name = "Sheep",
                Count = 20
            };
            ProductCountModel pr3 = new ProductCountModel
            {
                Id = 3,
                Name = "Okuny 1",
                Count = 30
            };
            List<ProductCountModel> products = new List<ProductCountModel>
{
pr1, pr2, pr3
};
            CommentForClientOutputModel com1Cl = new CommentForClientOutputModel
            {
                Text = "qqq",
            };
            CommentForClientOutputModel com2Cl = new CommentForClientOutputModel
            {
                Text = "ppp",
            };
            List<CommentForClientOutputModel> comClList = new List<CommentForClientOutputModel> { com1Cl, com2Cl };
            CommentForOrderModel comOr1 = new CommentForOrderModel
            {
                Id = 1,
                Text = "Доставить в полночь",
                OrderId = 4
            };
            List<CommentForOrderModel> comOrList = new List<CommentForOrderModel> { comOr1 };
            CreatingOrderModel creatingOrderModel = new CreatingOrderModel
            {
                Order = orderModel,
                Products = products,
                CommentsForOrder = comOrList,
                CommentsForClient = comClList
            };

            OrderDto orderDto = new OrderDto
            {
                Id = 4,
                ManagerId = 6,
                ClientId = 1,
                DateCreate = date1,
                ComplitionDate = complitionDate,
                Manager = new ManagerDto
                {
                    Id = 6,
                    Login = "Andrew",
                    Password = "qqq"
                },
                Client = new ClientsDto
                {
                    Id = 1,
                    Name = "Medvedev",
                    PhoneNumber = "8800"
                }
            };
            ProductCountDto pr1Dto = new ProductCountDto
            {
                Id = 1,
                Name = "Kurica 1",
                Count = 10
            };
            ProductCountDto pr2Dto = new ProductCountDto
            {
                Id = 2,
                Name = "Sheep",
                Count = 20
            };
            ProductCountDto pr3Dto = new ProductCountDto
            {
                Id = 3,
                Name = "Okuny 1",
                Count = 30
            };
            List<ProductCountDto> productsDto = new List<ProductCountDto>
{
pr1Dto, pr2Dto, pr3Dto
};
            CommentForClientDto com1ClDto = new CommentForClientDto
            {
                Id = 1,
                Text = "qqq",
                ClientId = 1
            };
            CommentForClientDto com2ClDto = new CommentForClientDto
            {
                Id = 2,
                Text = "ppp",
                ClientId = 1
            };
            List<CommentForClientDto> comClListDto = new List<CommentForClientDto> { com1ClDto, com2ClDto };
            CommenForOrderDto comOr1Dto = new CommenForOrderDto
            {
                Id = 1,
                Text = "Доставить в полночь",
                OrderId = 4
            };
            List<CommenForOrderDto> comOrListDto = new List<CommenForOrderDto> { comOr1Dto };
            CreatingOrderDto expectedCreatingOrderDto = new CreatingOrderDto
            {
                Order = orderDto,
                Products = productsDto,
                CommentsForOrder = comOrListDto,
                CommentsForClient = comClListDto
            };

            yield return new object[] { creatingOrderModel, expectedCreatingOrderDto };
        }
    }
}

