using OfferAggregator.Bll.Models;
using OfferAggregator.Dal.Models;
using System.Collections;
using System.Net.Http.Headers;

namespace OfferAggregator.Bll.Tests.TestCaseSource
{
    public class MapperTestCaseSource
    {
        public static IEnumerable MapProductsDtosToProductOutputModelsTestCaseSource()
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

            ProductOutputModel productModel1 = new ProductOutputModel
            {
                Id = 1,
                Name = "one",
                IsDeleted = false,
                GroupId = 1
            };
            ProductOutputModel productModel2 = new ProductOutputModel
            {
                Id = 2,
                Name = "two",
                IsDeleted = false,
                GroupId = 2
            };
            List<ProductOutputModel> expectedProductModel = new List<ProductOutputModel> { productModel1, productModel2 };

            yield return new object[] { baseProductsDto, expectedProductModel };


            baseProductsDto = new List<ProductsDto>();

            expectedProductModel = new List<ProductOutputModel>();

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

            ProductOutputModel productModel10 = new ProductOutputModel();
            ProductOutputModel productModel20 = new ProductOutputModel
            {
                Id = 20,
                Name = "two2",
                IsDeleted = true,
                GroupId = 20
            };
            expectedProductModel = new List<ProductOutputModel> { productModel10, productModel20 };

            yield return new object[] { baseProductsDto, expectedProductModel };
        }

        public static IEnumerable MapProductModelToProductsDtoTestCaseSource()
        {
            ProductInputModel baseProductModel = new ProductInputModel
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

            FullProductOutputModel fullProductModel1 = new FullProductOutputModel
            {
                Id = 1,
                Name = "1",
                GroupId = 10,
                Amount = 100,
                AverageScore = 3.5f,
                Tags = new List<TagOutputModel>
                {
                new TagOutputModel{ Id = 1, Name = "tag1"},
                new TagOutputModel{ Id = 2, Name = "tag2"}
                }
            };
            List<FullProductOutputModel> expectedFullProductModels = new List<FullProductOutputModel> { fullProductModel1 };

            yield return new object[] { fullProductDtos, expectedFullProductModels };

            fullProductDtos = new List<FullProductDto>();
            expectedFullProductModels = new List<FullProductOutputModel>();

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

            TagOutputModel tagModel1 = new TagOutputModel
            {
                Id = 11,
                Name = "11"
            };
            TagOutputModel tagModel2 = new TagOutputModel();
            List<TagOutputModel> tagModels = new List<TagOutputModel> { tagModel1, tagModel2 };

            fullProductModel1 = new FullProductOutputModel
            {
                Id = 11,
                Name = "11",
                GroupId = 101,
                Amount = 1001,
                AverageScore = 4.2f,
                Tags = tagModels
            };
            FullProductOutputModel fullProductModel2 = new FullProductOutputModel() { Tags = new() };
            expectedFullProductModels = new List<FullProductOutputModel> { fullProductModel1, fullProductModel2 };

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

            FullProductOutputModel expectedFullProductModel = new FullProductOutputModel
            {
                Id = 7,
                Name = "7",
                GroupId = 70,
                Amount = 700,
                AverageScore = 34.5f,
                Tags = new List<TagOutputModel>
                {
                new TagOutputModel{ Id = 10, Name = "tag10"},
                new TagOutputModel{ Id = 20, Name = "tag20"}
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

            expectedFullProductModel = new FullProductOutputModel
            {
                Id = 7,
                Name = "7",
                GroupId = 70,
                Amount = 700,
                AverageScore = 34.5f,
                Tags = new List<TagOutputModel>()
            };

            yield return new object[] { fullProductDto, expectedFullProductModel };
        }

        public static IEnumerable MapStocksWithProductModelToStocksWithProductModelTestCaseSource()
        {
            StocksWithProductInputModel baseStockModel = new StocksWithProductInputModel
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

            ProductsStatisticOutputModel productsStatisticModel1 = new ProductsStatisticOutputModel
            {
                Id = 1,
                Name = "1",
                SumOfCountofProduct = 10,
                CountOfOrders = 1,
                CountOfClients = 1,
                AverageScore = 4.9f
            };
            ProductsStatisticOutputModel productsStatisticModel2 = new ProductsStatisticOutputModel
            {
                Id = 2,
                Name = "2",
                SumOfCountofProduct = 20,
                CountOfOrders = 2,
                CountOfClients = 2,
                AverageScore = 3.5f
            };
            List<ProductsStatisticOutputModel> expectedProductsStatisticModels = new List<ProductsStatisticOutputModel> { productsStatisticModel1, productsStatisticModel2 };

            yield return new object[] { productsStatisticDtos, expectedProductsStatisticModels };

            productsStatisticDtos = new List<ProductsStatisticDto>();

            expectedProductsStatisticModels = new List<ProductsStatisticOutputModel>();

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

            productsStatisticModel1 = new ProductsStatisticOutputModel
            {
                Id = 13,
                Name = "13",
                SumOfCountofProduct = 103,
                CountOfOrders = 13,
                CountOfClients = 13,
                AverageScore = 1.3f
            };
            productsStatisticModel2 = new ProductsStatisticOutputModel();
            expectedProductsStatisticModels = new List<ProductsStatisticOutputModel> { productsStatisticModel1, productsStatisticModel2 };

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

            productsStatisticModel1 = new ProductsStatisticOutputModel();
            productsStatisticModel2 = new ProductsStatisticOutputModel
            {
                Id = 24,
                Name = "24",
                SumOfCountofProduct = 204,
                CountOfOrders = 24,
                CountOfClients = 24,
                AverageScore = null
            };
            expectedProductsStatisticModels = new List<ProductsStatisticOutputModel> { productsStatisticModel1, productsStatisticModel2 };

            yield return new object[] { productsStatisticDtos, expectedProductsStatisticModels };

            productsStatistiDto1 = new ProductsStatisticDto
            {
                Id = 15,
                Name = "15"
            };
            productsStatisticDtos = new List<ProductsStatisticDto> { productsStatistiDto1 };

            productsStatisticModel1 = new ProductsStatisticOutputModel
            {
                Id = 15,
                Name = "15"
            };
            expectedProductsStatisticModels = new List<ProductsStatisticOutputModel> { productsStatisticModel1 };

            yield return new object[] { productsStatisticDtos, expectedProductsStatisticModels };
        }

        public static IEnumerable MapCreatingOrderModelToCreatingOrderDtoTestCaseSource()
        {
            DateTime date1 = new DateTime(2023, 01, 29, 10, 00, 00);
            DateTime complitionDate = new DateTime(2023, 01, 30, 10, 00, 00);
            OrderInputModel orderModel = new OrderInputModel
            {
                //Id = 4,
                ManagerId = 6,
                ClientId = 1,
                DateCreate = date1,
                ComplitionDate = complitionDate,
                Manager = new CurrentManager(6, "Andrew", "qqq"),
                Client = new ClientOutputModel
                {
                    Id = 1,
                    Name = "Medvedev",
                    PhoneNumber = "8800"
                }
            };
            ProductCountInputModel pr1 = new ProductCountInputModel
            {
                Id = 1,
                Name = "Kurica 1",
                Count = 10
            };
            ProductCountInputModel pr2 = new ProductCountInputModel
            {
                Id = 2,
                Name = "Sheep",
                Count = 20
            };
            ProductCountInputModel pr3 = new ProductCountInputModel
            {
                Id = 3,
                Name = "Okuny 1",
                Count = 30
            };
            List<ProductCountInputModel> products = new List<ProductCountInputModel>
{
pr1, pr2, pr3
};
            CommentForClientInputModel com1Cl = new CommentForClientInputModel
            {
                // Id = 1,
                Text = "qqq",
                ClientId = 1
            };
            CommentForClientInputModel com2Cl = new CommentForClientInputModel
            {
               // Id = 2,
                Text = "ppp",
                ClientId = 1
            };
            List<CommentForClientInputModel> comClList = new List<CommentForClientInputModel> { com1Cl, com2Cl };
            CommentForOrderInputModel comOr1 = new CommentForOrderInputModel
            {
                //Id = 1,
                Text = "Доставить в полночь",
                OrderId = 4
            };
            List<CommentForOrderInputModel> comOrList = new List<CommentForOrderInputModel> { comOr1 };
            CreatingOrderInputModel creatingOrderModel = new CreatingOrderInputModel
            {
                Order = orderModel,
                Products = products,
                CommentsForOrder = comOrList,
                CommentsForClient = comClList
            };

            OrderDto orderDto = new OrderDto
            {
                //Id = 4,
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
                //Id = 1,
                Text = "qqq",
                ClientId = 1
            };
            CommentForClientDto com2ClDto = new CommentForClientDto
            {
                //Id = 2,
                Text = "ppp",
                ClientId = 1
            };
            List<CommentForClientDto> comClListDto = new List<CommentForClientDto> { com1ClDto, com2ClDto };
            CommenForOrderDto comOr1Dto = new CommenForOrderDto
            {
                //Id = 1,
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

