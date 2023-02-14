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
                Manager = new ManagerModel
                {
                    Id = 6,
                    Login = "Andrew",
                    Password = "qqq"
                },
                Client = new ClientModel
                {
                    Id = 1,
                    Name = "Medvedev",
                    PhoneNumber = "8800"
                }
            };
            ProductModel pr1 = new ProductModel
            {
                Id = 1,
                Name = "Kurica 1",
                IsDeleted = true,
                GroupId = 2
            };
            ProductModel pr2 = new ProductModel
            {
                Id = 2,
                Name = "Sheep",
                IsDeleted = false,
                GroupId = 2
            };
            ProductModel pr3 = new ProductModel
            {
                Id = 3,
                Name = "Okuny 1",
                IsDeleted = false,
                GroupId = 3
            };
            List<ProductModel> products = new List<ProductModel>
{
pr1, pr2, pr3
};
            OrdersProductModel op1 = new OrdersProductModel
            {
                OrderId = 4,
                ProductId = 1,
                CountProduct = 2
            };
            OrdersProductModel op2 = new OrdersProductModel
            {
                OrderId = 4,
                ProductId = 2,
                CountProduct = 4
            };
            OrdersProductModel op3 = new OrdersProductModel
            {
                OrderId = 4,
                ProductId = 3,
                CountProduct = 5
            };
            List<OrdersProductModel> opList = new List<OrdersProductModel> { op1, op2, op3 };
            CommentForClientModel com1Cl = new CommentForClientModel
            {
                Id = 1,
                Text = "qqq",
                ClientId = 1
            };
            CommentForClientModel com2Cl = new CommentForClientModel
            {
                Id = 2,
                Text = "ppp",
                ClientId = 1
            };
            List<CommentForClientModel> comClList = new List<CommentForClientModel> { com1Cl, com2Cl };
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
                CommentsForClient = comClList,
                OrdersProducts = opList
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
            ProductsDto pr1Dto = new ProductsDto
            {
                Id = 1,
                Name = "Kurica 1",
                IsDeleted = true,
                GroupId = 2
            };
            ProductsDto pr2Dto = new ProductsDto
            {
                Id = 2,
                Name = "Sheep",
                IsDeleted = false,
                GroupId = 2
            };
            ProductsDto pr3Dto = new ProductsDto
            {
                Id = 3,
                Name = "Okuny 1",
                IsDeleted = false,
                GroupId = 3
            };
            List<ProductsDto> productsDto = new List<ProductsDto>
{
pr1Dto, pr2Dto, pr3Dto
};
            OrdersProductsDto op1Dto = new OrdersProductsDto
            {
                OrderId = 4,
                ProductId = 1,
                CountProduct = 2
            };
            OrdersProductsDto op2Dto = new OrdersProductsDto
            {
                OrderId = 4,
                ProductId = 2,
                CountProduct = 4
            };
            OrdersProductsDto op3Dto = new OrdersProductsDto
            {
                OrderId = 4,
                ProductId = 3,
                CountProduct = 5
            };
            List<OrdersProductsDto> opListDto = new List<OrdersProductsDto> { op1Dto, op2Dto, op3Dto };
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
                CommentsForClient = comClListDto,
                OrdersProducts = opListDto
            };

            yield return new object[] { creatingOrderModel, expectedCreatingOrderDto };
        }
    }
}
