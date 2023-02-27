using OfferAggregator.Bll.Models;
using OfferAggregator.Dal.Models;
using System.Collections;
using System.Net;

namespace OfferAggregator.Bll.Tests.TestCaseSource
{
    public class OrderServiceTestCaseSource
    {
        public static IEnumerable CreateNewOrderWithOneProductTestCaseSource()
        {
            //1. Проверка с одним продуктом, когда все заполнено

            DateTime dateCreate = new DateTime(2023, 02, 14, 11, 00, 00);
            DateTime complitionDate = new DateTime(2023, 02, 27, 19, 45, 00);
            OrderModel orderModel = new OrderModel
            {
                ManagerId = 1,
                ClientId = 2,
                DateCreate = dateCreate,
                ComplitionDate = complitionDate,
                Manager = new CurrentManager(1, "OneMan", "111"),
                Client = new ClientInputModel
                {
                    Name = "OneClient",
                    PhoneNumber = "11111"
                }
            };
            ProductCountModel pr1 = new ProductCountModel
            {
                Id = 1,
                Name = "product1",
                Count = 10
            };
            List<ProductCountModel> products = new List<ProductCountModel> { pr1 };
            CommentForClientOutputModel com1Cl = new CommentForClientOutputModel
            {
                Text = "commentClient",
                ClientId = 2
            };
            List<CommentForClientOutputModel> comClList = new List<CommentForClientOutputModel> { com1Cl };
            CommentForOrderModel comOr1 = new CommentForOrderModel
            {
                Text = "commentOrder",
                OrderId = 100
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
                ManagerId = 1,
                ClientId = 2,
                DateCreate = dateCreate,
                ComplitionDate = complitionDate,
                Manager = new ManagerDto
                {
                    Id = 1,
                    Login = "OneMan",
                    Password = "111"
                },
                Client = new ClientsDto
                {
                    Id = 2,
                    Name = "OneClient",
                    PhoneNumber = "11111"
                }
            };
            ProductCountDto pr1Dto = new ProductCountDto
            {
                Id = 1,
                Name = "product1",
                Count = 10
            };
            List<ProductCountDto> productsDto = new List<ProductCountDto> { pr1Dto };
            CommentForClientDto com1ClDto = new CommentForClientDto
            {
                Text = "commentClient",
                ClientId = 2
            };
            List<CommentForClientDto> comClListDto = new List<CommentForClientDto> { com1ClDto };
            CommenForOrderDto comOr1Dto = new CommenForOrderDto
            {
                Text = "commentOrder",
                OrderId = 100
            };
            List<CommenForOrderDto> comOrListDto = new List<CommenForOrderDto> { comOr1Dto };
            CreatingOrderDto creatingOrderDto = new CreatingOrderDto
            {
                Order = orderDto,
                Products = productsDto,
                CommentsForOrder = comOrListDto,
                CommentsForClient = comClListDto
            };
            int addOrder = 100;
            ClientsDto getClient = new ClientsDto
            {
                Id = 2,
                Name = "OneClient",
                PhoneNumber = "11111"
            };
            int addCommentForOrder = 99;
            int addCommentForClient = 98;
            ProductCountModel crntProductModel = new ProductCountModel
            {
                Id = 1,
                Name = "product1",
                Count = 10
            };
            ProductsDto getProductById = new ProductsDto
            {
                Id = 1,
                Name = "product1",
                GroupId = 1,
                IsDeleted = false
            };
            OrdersProductsDto ordersProductsDto = new OrdersProductsDto
            {
                OrderId = 100,
                ProductId = 1,
                CountProduct = 10
            };
            ManagerDto getManager = new ManagerDto
            {
                Id = 1,
                Login = "OneMan",
                Password = "111"
            };
            bool addProductToOrder = true;
            int expected = 100;
            StocksDtoWithProductName getAmountProductOnStock = new StocksDtoWithProductName
            {
                ProductId = 1,
                Name = "product1",
                Amount = 10
            };
            StocksDtoWithProductName stockProduct = new StocksDtoWithProductName
            {
                ProductId = 1,
                Name = "product1",
                Amount = 0
            };

            yield return new object[] { creatingOrderModel, getClient, creatingOrderDto, addOrder, addCommentForOrder, addCommentForClient,
                                       crntProductModel, getProductById, ordersProductsDto, addProductToOrder, expected, getManager, getAmountProductOnStock, stockProduct };
        }

        public static IEnumerable CreateNewOrderWithTwoProductTestCaseSource()
        {
            DateTime dateCreate = new DateTime(2023, 03, 14, 22, 10, 00);
            DateTime complitionDate = new DateTime(2023, 09, 27, 10, 31, 00);
            OrderModel orderModel = new OrderModel
            {
                ManagerId = 12,
                ClientId = 22,
                DateCreate = dateCreate,
                ComplitionDate = complitionDate,
                Manager = new CurrentManager(12, "OneMan2", "1112"),
                Client = new ClientInputModel
                {
                    Name = "OneClient2",
                    PhoneNumber = "111112"
                }
            };
            ProductCountModel pr1 = new ProductCountModel
            {
                Id = 12,
                Name = "product12",
                Count = 102
            };
            ProductCountModel pr2 = new ProductCountModel
            {
                Id = 22,
                Name = "product22",
                Count = 22
            };
            List<ProductCountModel> products = new List<ProductCountModel> { pr1, pr2 };
            CommentForClientOutputModel com1Cl = new CommentForClientOutputModel
            {
                Text = "commentClient2",
                ClientId = 22
            };
            List<CommentForClientOutputModel> comClList = new List<CommentForClientOutputModel> { com1Cl };
            CommentForOrderModel comOr1 = new CommentForOrderModel
            {
                Text = "commentOrder2",
                OrderId = 1002
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
                ManagerId = 12,
                ClientId = 22,
                DateCreate = dateCreate,
                ComplitionDate = complitionDate,
                Manager = new ManagerDto
                {
                    Id = 12,
                    Login = "OneMan2",
                    Password = "1112"
                },
                Client = new ClientsDto
                {
                    Id = 22,
                    Name = "OneClient2",
                    PhoneNumber = "111112"
                }
            };
            ProductCountDto pr1Dto = new ProductCountDto
            {
                Id = 12,
                Name = "product12",
                Count = 102
            };
            ProductCountDto pr2Dto = new ProductCountDto
            {
                Id = 22,
                Name = "product22",
                Count = 22
            };
            List<ProductCountDto> productsDto = new List<ProductCountDto> { pr1Dto, pr1Dto };
            CommentForClientDto com1ClDto = new CommentForClientDto
            {
                Text = "commentClient2",
                ClientId = 22
            };
            List<CommentForClientDto> comClListDto = new List<CommentForClientDto> { com1ClDto };
            CommenForOrderDto comOr1Dto = new CommenForOrderDto
            {
                Text = "commentOrder2",
                OrderId = 1002
            };
            List<CommenForOrderDto> comOrListDto = new List<CommenForOrderDto> { comOr1Dto };
            CreatingOrderDto creatingOrderDto = new CreatingOrderDto
            {
                Order = orderDto,
                Products = productsDto,
                CommentsForOrder = comOrListDto,
                CommentsForClient = comClListDto
            };
            int addOrder = 1002;
            ClientsDto getClient = new ClientsDto
            {
                Id = 22,
                Name = "OneClient2",
                PhoneNumber = "111112"
            };
            int addCommentForOrder = 992;
            int addCommentForClient = 982;
            ProductCountModel crntProductModel1 = new ProductCountModel
            {
                Id = 12,
                Name = "product12",
                Count = 102
            };
            ProductCountModel crntProductModel2 = new ProductCountModel
            {
                Id = 22,
                Name = "product22",
                Count = 22
            };
            ProductsDto getProductById = new ProductsDto
            {
                Id = 12,
                Name = "product12",
                GroupId = 12,
                IsDeleted = false
            };
            OrdersProductsDto ordersProductsDto1 = new OrdersProductsDto
            {
                OrderId = 1002,
                ProductId = 12,
                CountProduct = 102
            };
            OrdersProductsDto ordersProductsDto2 = new OrdersProductsDto
            {
                OrderId = 1002,
                ProductId = 22,
                CountProduct = 22
            };
            ManagerDto getManager = new ManagerDto
            {
                Id = 12,
                Login = "OneMan2",
                Password = "1112"
            };
            bool addProductToOrder = true;
            int expected = 1002;
            StocksDtoWithProductName getAmountProductOnStock1 = new StocksDtoWithProductName
            {
                ProductId = 12,
                Name = "product12",
                Amount = 200
            };
            StocksDtoWithProductName getAmountProductOnStock2 = new StocksDtoWithProductName
            {
                ProductId = 22,
                Name = "product22",
                Amount = 101
            };
            StocksDtoWithProductName stockProduct1 = new StocksDtoWithProductName
            {
                ProductId = 12,
                Name = "product12",
                Amount = 98
            };
            StocksDtoWithProductName stockProduct2 = new StocksDtoWithProductName
            {
                ProductId = 22,
                Name = "product22",
                Amount = 79
            };


            yield return new object[] { creatingOrderModel, getClient, creatingOrderDto, addOrder, addCommentForOrder, addCommentForClient,crntProductModel1, crntProductModel2,
                                          getProductById, ordersProductsDto1, ordersProductsDto2, addProductToOrder, expected, getManager, getAmountProductOnStock1, 
                                          getAmountProductOnStock2, stockProduct1, stockProduct2 };
        }

        public static IEnumerable CreateNewOrderWithOneProduct_WhenManagerIsNotExistTestCaseSource()
        {
            DateTime dateCreate = new DateTime(2023, 11, 01, 11, 10, 00);
            DateTime complitionDate = new DateTime(2023, 12, 02, 12, 45, 00);
            OrderModel orderModel = new OrderModel
            {
                ManagerId = 123,
                ClientId = 223,
                DateCreate = dateCreate,
                ComplitionDate = complitionDate,
                Manager = new CurrentManager(123, "OneMan23", "11123"),
                Client = new ClientInputModel
                {
                    Name = "OneClient23",
                    PhoneNumber = "1111123"
                }
            };
            ProductCountModel pr1 = new ProductCountModel
            {
                Id = 123,
                Name = "product123",
                Count = 102
            };
            List<ProductCountModel> products = new List<ProductCountModel> { pr1 };
            CommentForClientOutputModel com1Cl = new CommentForClientOutputModel
            {
                Text = "commentClient23",
                ClientId = 223
            };
            List<CommentForClientOutputModel> comClList = new List<CommentForClientOutputModel> { com1Cl };
            CommentForOrderModel comOr1 = new CommentForOrderModel
            {
                Text = "commentOrder23",
                OrderId = 10023
            };
            List<CommentForOrderModel> comOrList = new List<CommentForOrderModel> { comOr1 };
            CreatingOrderModel creatingOrderModel = new CreatingOrderModel
            {
                Order = orderModel,
                Products = products,
                CommentsForOrder = comOrList,
                CommentsForClient = comClList
            };
            ClientsDto getClient = new ClientsDto
            {
                Id = 223,
                Name = "OneClient23",
                PhoneNumber = "1111123"
            };
            ManagerDto getManager = null;
            int expected = -1;

            yield return new object[] { creatingOrderModel, getClient, getManager, expected };
        }

        public static IEnumerable CreateNewOrderWithOneProduct_WhenClientIsNotExistTestCaseSource()
        {
            DateTime dateCreate = new DateTime(2020, 07, 15, 11, 10, 49);
            DateTime complitionDate = new DateTime(2021, 01, 01, 12, 00, 00);
            OrderModel orderModel = new OrderModel
            {
                ManagerId = 1234,
                ClientId = 2234,
                DateCreate = dateCreate,
                ComplitionDate = complitionDate,
                Manager = new CurrentManager(1234, "OneMan234", "111234"),
                Client = new ClientInputModel
                {
                    Name = "OneClient234",
                    PhoneNumber = "11111234"
                }
            };
            ProductCountModel pr1 = new ProductCountModel
            {
                Id = 1234,
                Name = "product1234",
                Count = 1024
            };
            List<ProductCountModel> products = new List<ProductCountModel> { pr1 };
            CommentForClientOutputModel com1Cl = new CommentForClientOutputModel
            {
                Text = "commentClient234",
                ClientId = 2234
            };
            List<CommentForClientOutputModel> comClList = new List<CommentForClientOutputModel> { com1Cl };
            CommentForOrderModel comOr1 = new CommentForOrderModel
            {
                Text = "commentOrder234",
                OrderId = 100234
            };
            List<CommentForOrderModel> comOrList = new List<CommentForOrderModel> { comOr1 };
            CreatingOrderModel creatingOrderModel = new CreatingOrderModel
            {
                Order = orderModel,
                Products = products,
                CommentsForOrder = comOrList,
                CommentsForClient = comClList
            };
            ClientsDto getClient = null;
            ManagerDto getManager = new ManagerDto
            {
                Id = 1234,
                Login = "OneMan234",
                Password = "111234"
            };
            int expected = -1;

            yield return new object[] { creatingOrderModel, getClient, getManager, expected };
        }

        public static IEnumerable CreateNewOrderWithOneProduct_WhenComplitionDateEarlierThenDateCreateTestCaseSource()
        {
            DateTime dateCreate = new DateTime(2022, 07, 15, 12, 15, 49);
            DateTime complitionDate = new DateTime(2022, 07, 05, 12, 00, 00);
            OrderModel orderModel = new OrderModel
            {
                ManagerId = 12345,
                ClientId = 22345,
                DateCreate = dateCreate,
                ComplitionDate = complitionDate,
                Manager = new CurrentManager(12345, "OneMan2345", "1112345"),
                Client = new ClientInputModel
                {
                    Name = "OneClient2345",
                    PhoneNumber = "111112345"
                }
            };
            ProductCountModel pr1 = new ProductCountModel
            {
                Id = 12345,
                Name = "product12345",
                Count = 10245
            };
            List<ProductCountModel> products = new List<ProductCountModel> { pr1 };
            CommentForClientOutputModel com1Cl = new CommentForClientOutputModel
            {
                Text = "commentClient2345",
                ClientId = 22345
            };
            List<CommentForClientOutputModel> comClList = new List<CommentForClientOutputModel> { com1Cl };
            CommentForOrderModel comOr1 = new CommentForOrderModel
            {
                Text = "commentOrder2345",
                OrderId = 1002345
            };
            List<CommentForOrderModel> comOrList = new List<CommentForOrderModel> { comOr1 };
            CreatingOrderModel creatingOrderModel = new CreatingOrderModel
            {
                Order = orderModel,
                Products = products,
                CommentsForOrder = comOrList,
                CommentsForClient = comClList
            };
            ClientsDto getClient = new ClientsDto
            {
                Id = 22345,
                Name = "OneClient2345",
                PhoneNumber = "111112345"
            };
            ManagerDto getManager = new ManagerDto
            {
                Id = 12345,
                Login = "OneMan2345",
                Password = "1112345"
            };
            int expected = -1;

            yield return new object[] { creatingOrderModel, getClient, getManager, expected };
        }

        public static IEnumerable CreateNewOrderWithOneProduct_WhenCommentsForOrderIsNullTestCaseSource()
        {
            DateTime dateCreate = new DateTime(2022, 11, 11, 11, 11, 11);
            DateTime complitionDate = new DateTime(2023, 11, 27, 09, 36, 00);
            OrderModel orderModel = new OrderModel
            {
                ManagerId = 147,
                ClientId = 247,
                DateCreate = dateCreate,
                ComplitionDate = complitionDate,
                Manager = new CurrentManager(147, "OneMan47", "11147"),
                Client = new ClientInputModel
                {
                    Name = "OneClient47",
                    PhoneNumber = "1111147"
                }
            };
            ProductCountModel pr1 = new ProductCountModel
            {
                Id = 147,
                Name = "product147",
                Count = 1047
            };
            List<ProductCountModel> products = new List<ProductCountModel> { pr1 };
            List<CommentForClientOutputModel> comClList = new List<CommentForClientOutputModel>
            {
            new CommentForClientOutputModel
            {
                Text = "comment7",
                ClientId = 247
            }
            };
            List<CommentForOrderModel> comOrList = new List<CommentForOrderModel>();
            CreatingOrderModel creatingOrderModel = new CreatingOrderModel
            {
                Order = orderModel,
                Products = products,
                CommentsForOrder = comOrList,
                CommentsForClient = comClList
            };

            OrderDto orderDto = new OrderDto
            {
                ManagerId = 147,
                ClientId = 247,
                DateCreate = dateCreate,
                ComplitionDate = complitionDate,
                Manager = new ManagerDto
                {
                    Id = 147,
                    Login = "OneMan47",
                    Password = "11147"
                },
                Client = new ClientsDto
                {
                    Id = 247,
                    Name = "OneClient47",
                    PhoneNumber = "1111147"
                }
            };
            ProductCountDto pr1Dto = new ProductCountDto
            {
                Id = 147,
                Name = "product147",
                Count = 1047
            };
            List<ProductCountDto> productsDto = new List<ProductCountDto> { pr1Dto };
            List<CommentForClientDto> comClListDto = new List<CommentForClientDto>
            {
            new CommentForClientDto
            {
                Text = "comment7",
                ClientId = 247
            }
            };
            List<CommenForOrderDto> comOrListDto = new List<CommenForOrderDto>();
            CreatingOrderDto creatingOrderDto = new CreatingOrderDto
            {
                Order = orderDto,
                Products = productsDto,
                CommentsForOrder = comOrListDto,
                CommentsForClient = comClListDto
            };
            int addOrder = 10047;
            ClientsDto getClient = new ClientsDto
            {
                Id = 247,
                Name = "OneClient7",
                PhoneNumber = "1111147"
            };
            int addCommentForOrder = 9947;
            int addCommentForClient = 9847;
            ProductCountModel crntProductModel = new ProductCountModel
            {
                Id = 147,
                Name = "product147",
                Count = 1047
            };
            ProductsDto getProductById = new ProductsDto
            {
                Id = 147,
                Name = "product147",
                GroupId = 147,
                IsDeleted = false
            };
            OrdersProductsDto ordersProductsDto = new OrdersProductsDto
            {
                OrderId = 10047,
                ProductId = 147,
                CountProduct = 1047
            };
            ManagerDto getManager = new ManagerDto
            {
                Id = 147,
                Login = "OneMan47",
                Password = "11147"
            };
            bool addProductToOrder = true;
            int expected = 10047;
            StocksDtoWithProductName getAmountProductOnStock = new StocksDtoWithProductName
            {
                ProductId = 147,
                Name = "product147",
                Amount = 2000
            };
            StocksDtoWithProductName stockProduct = new StocksDtoWithProductName
            {
                ProductId = 147,
                Name = "product147",
                Amount = 953
            };

            yield return new object[] { creatingOrderModel, getClient, creatingOrderDto, addOrder, addCommentForClient,crntProductModel, getProductById, 
                                         ordersProductsDto, addProductToOrder, expected, getManager, getAmountProductOnStock, stockProduct };
        }

        public static IEnumerable CreateNewOrderWithOneProduct_WhenCommentsForClientIsNullTestCaseSource()
        {
            DateTime dateCreate = new DateTime(2023, 11, 01, 19, 11, 11);
            DateTime complitionDate = new DateTime(2023, 11, 27, 15, 17, 00);
            OrderModel orderModel = new OrderModel
            {
                ManagerId = 1478,
                ClientId = 2478,
                DateCreate = dateCreate,
                ComplitionDate = complitionDate,
                Manager = new CurrentManager(1478, "OneMan478", "111478"),
                Client = new ClientInputModel
                {
                    Name = "OneClient478",
                    PhoneNumber = "11111478"
                }
            };
            ProductCountModel pr1 = new ProductCountModel
            {
                Id = 1478,
                Name = "product1478",
                Count = 10478
            };
            List<ProductCountModel> products = new List<ProductCountModel> { pr1 };
            List<CommentForClientOutputModel> comClList = new List<CommentForClientOutputModel>();
            List<CommentForOrderModel> comOrList = new List<CommentForOrderModel>
            {
                new CommentForOrderModel
                {
                Text = "comment",
                OrderId = 100478
                }
            };
            CreatingOrderModel creatingOrderModel = new CreatingOrderModel
            {
                Order = orderModel,
                Products = products,
                CommentsForOrder = comOrList,
                CommentsForClient = comClList
            };

            OrderDto orderDto = new OrderDto
            {
                ManagerId = 1478,
                ClientId = 2478,
                DateCreate = dateCreate,
                ComplitionDate = complitionDate,
                Manager = new ManagerDto
                {
                    Id = 1478,
                    Login = "OneMan478",
                    Password = "111478"
                },
                Client = new ClientsDto
                {
                    Id = 2478,
                    Name = "OneClient478",
                    PhoneNumber = "11111478"
                }
            };
            ProductCountDto pr1Dto = new ProductCountDto
            {
                Id = 1478,
                Name = "product1478",
                Count = 10478
            };
            List<ProductCountDto> productsDto = new List<ProductCountDto> { pr1Dto };
            List<CommentForClientDto> comClListDto = new List<CommentForClientDto>();
            List<CommenForOrderDto> comOrListDto = new List<CommenForOrderDto>
            {
            new CommenForOrderDto
                {
                Text = "comment",
                OrderId = 100478
                }
            };
            CreatingOrderDto creatingOrderDto = new CreatingOrderDto
            {
                Order = orderDto,
                Products = productsDto,
                CommentsForOrder = comOrListDto,
                CommentsForClient = comClListDto
            };
            int addOrder = 100478;
            ClientsDto getClient = new ClientsDto
            {
                Id = 2478,
                Name = "OneClient78",
                PhoneNumber = "11111478"
            };
            int addCommentForOrder = 99478;
            int addCommentForClient = 98478;
            ProductCountModel crntProductModel = new ProductCountModel
            {
                Id = 1478,
                Name = "product1478",
                Count = 10478
            };
            ProductsDto getProductById = new ProductsDto
            {
                Id = 1478,
                Name = "product1478",
                GroupId = 1478,
                IsDeleted = false
            };
            OrdersProductsDto ordersProductsDto = new OrdersProductsDto
            {
                OrderId = 100478,
                ProductId = 1478,
                CountProduct = 10478
            };
            ManagerDto getManager = new ManagerDto
            {
                Id = 1478,
                Login = "OneMan478",
                Password = "111478"
            };
            bool addProductToOrder = true;
            int expected = 100478;
            StocksDtoWithProductName getAmountProductOnStock = new StocksDtoWithProductName
            {
                ProductId = 1478,
                Name = "product1478",
                Amount = 10500
            };
            StocksDtoWithProductName stockProduct = new StocksDtoWithProductName
            {
                ProductId = 1478,
                Name = "product1478",
                Amount = 22
            };

            yield return new object[] { creatingOrderModel, getClient, creatingOrderDto, addOrder, addCommentForClient,crntProductModel, getProductById,
                                         ordersProductsDto, addProductToOrder, expected, getManager, getAmountProductOnStock, stockProduct };
        }

        public static IEnumerable CreateNewOrderWithOneProduct_WhenProductIsNotExistTestCaseSource()
        {
            DateTime dateCreate = new DateTime(2022, 11, 01, 00, 11, 11);
            DateTime complitionDate = new DateTime(2023, 12, 27, 02, 17, 00);
            OrderModel orderModel = new OrderModel
            {
                ManagerId = 14787,
                ClientId = 24787,
                DateCreate = dateCreate,
                ComplitionDate = complitionDate,
                Manager = new CurrentManager(14787, "OneMan4787", "11147877"),
                Client = new ClientInputModel
                {
                    Name = "OneClient4787",
                    PhoneNumber = "111114787"
                }
            };
            ProductCountModel pr1 = new ProductCountModel
            {
                Id = 14787,
                Name = "product14787",
                Count = 104787
            };
            List<ProductCountModel> products = new List<ProductCountModel> { pr1 };
            List<CommentForClientOutputModel> comClList = new List<CommentForClientOutputModel>
                {
                new CommentForClientOutputModel
                {
                Text = "comment7",
                ClientId = 24787
                }
            };
            List<CommentForOrderModel> comOrList = new List<CommentForOrderModel>
            {
                new CommentForOrderModel
                {
                Text = "comment7",
                OrderId = 1004787
                }
            };
            CreatingOrderModel creatingOrderModel = new CreatingOrderModel
            {
                Order = orderModel,
                Products = products,
                CommentsForOrder = comOrList,
                CommentsForClient = comClList
            };

            OrderDto orderDto = new OrderDto
            {
                ManagerId = 14787,
                ClientId = 24787,
                DateCreate = dateCreate,
                ComplitionDate = complitionDate,
                Manager = new ManagerDto
                {
                    Id = 14787,
                    Login = "OneMan4787",
                    Password = "11147877"
                },
                Client = new ClientsDto
                {
                    Id = 24787,
                    Name = "OneClient4787",
                    PhoneNumber = "111114787"
                }
            };
            ProductCountDto pr1Dto = new ProductCountDto
            {
                Id = 14787,
                Name = "product14787",
                Count = 104787
            };
            List<ProductCountDto> productsDto = new List<ProductCountDto> { pr1Dto };
            List<CommentForClientDto> comClListDto = new List<CommentForClientDto>
                 {
            new CommentForClientDto
                {
                Text = "comment7",
                ClientId = 24787
                }
            };
            List<CommenForOrderDto> comOrListDto = new List<CommenForOrderDto>
            {
            new CommenForOrderDto
                {
                Text = "comment7",
                OrderId = 1004787
                }
            };
            CreatingOrderDto creatingOrderDto = new CreatingOrderDto
            {
                Order = orderDto,
                Products = productsDto,
                CommentsForOrder = comOrListDto,
                CommentsForClient = comClListDto
            };
            int addOrder = 1004787;
            ClientsDto getClient = new ClientsDto
            {
                Id = 24787,
                Name = "OneClient787",
                PhoneNumber = "111114787"
            };
            int addCommentForOrder = 994787;
            int addCommentForClient = 984787;
            ProductCountModel crntProductModel = new ProductCountModel
            {
                Id = 14787,
                Name = "product14787",
                Count = 104787
            };
            ProductsDto getProductById = null;
            ManagerDto getManager = new ManagerDto
            {
                Id = 14787,
                Login = "OneMan4787",
                Password = "11147877"
            };
            int expected = -1;

            yield return new object[] { creatingOrderModel, getClient, creatingOrderDto,
                                       addOrder, addCommentForClient, crntProductModel, addCommentForOrder,
                                       getProductById, expected, getManager };
        }

        public static IEnumerable CreateNewOrderWithOneProduct_WhenAmountOnStockLessThenAmountProductInOrderTestCaseSource()
        {
            DateTime dateCreate = new DateTime(2023, 11, 01, 05, 11, 11);
            DateTime complitionDate = new DateTime(2023, 12, 01, 02, 17, 00);
            OrderModel orderModel = new OrderModel
            {
                ManagerId = 147870,
                ClientId = 247870,
                DateCreate = dateCreate,
                ComplitionDate = complitionDate,
                Manager = new CurrentManager(147870, "OneMan47870", "111478770"),
                Client = new ClientInputModel
                {
                    Name = "OneClient47870",
                    PhoneNumber = "1111147870"
                }
            };
            ProductCountModel pr1 = new ProductCountModel
            {
                Id = 147870,
                Name = "product147870",
                Count = 1047870
            };
            List<ProductCountModel> products = new List<ProductCountModel> { pr1 };
            List<CommentForClientOutputModel> comClList = new List<CommentForClientOutputModel>
                {
                new CommentForClientOutputModel
                {
                Text = "comment70",
                ClientId = 247870
                }
            };
            List<CommentForOrderModel> comOrList = new List<CommentForOrderModel>
            {
                new CommentForOrderModel
                {
                Text = "comment70",
                OrderId = 10047870
                }
            };
            CreatingOrderModel creatingOrderModel = new CreatingOrderModel
            {
                Order = orderModel,
                Products = products,
                CommentsForOrder = comOrList,
                CommentsForClient = comClList
            };

            OrderDto orderDto = new OrderDto
            {
                ManagerId = 147870,
                ClientId = 247870,
                DateCreate = dateCreate,
                ComplitionDate = complitionDate,
                Manager = new ManagerDto
                {
                    Id = 147870,
                    Login = "OneMan47870",
                    Password = "111478770"
                },
                Client = new ClientsDto
                {
                    Id = 247870,
                    Name = "OneClient47870",
                    PhoneNumber = "1111147870"
                }
            };
            ProductCountDto pr1Dto = new ProductCountDto
            {
                Id = 147870,
                Name = "product147870",
                Count = 104787
            };
            List<ProductCountDto> productsDto = new List<ProductCountDto> { pr1Dto };
            List<CommentForClientDto> comClListDto = new List<CommentForClientDto>
                 {
            new CommentForClientDto
                {
                Text = "comment70",
                ClientId = 247870
                }
            };
            List<CommenForOrderDto> comOrListDto = new List<CommenForOrderDto>
            {
            new CommenForOrderDto
                {
                Text = "comment70",
                OrderId = 10047870
                }
            };
            CreatingOrderDto creatingOrderDto = new CreatingOrderDto
            {
                Order = orderDto,
                Products = productsDto,
                CommentsForOrder = comOrListDto,
                CommentsForClient = comClListDto
            };
            int addOrder = 10047870;
            ClientsDto getClient = new ClientsDto
            {
                Id = 247870,
                Name = "OneClient7870",
                PhoneNumber = "1111147870"
            };
            int addCommentForOrder = 9947870;
            int addCommentForClient = 9847870;
            ProductCountModel crntProductModel = new ProductCountModel
            {
                Id = 147870,
                Name = "product147870",
                Count = 1047870
            };
            ProductsDto getProductById = new ProductsDto
            {
                Id = 147870,
                Name = "product147870"
            };
            ManagerDto getManager = new ManagerDto
            {
                Id = 147870,
                Login = "OneMan47870",
                Password = "111478770"
            };
            int expected = -1;
            StocksDtoWithProductName getAmountProductOnStock = new StocksDtoWithProductName
            {
                ProductId = 147870,
                Name = "product147870",
                Amount = 1000
            };

            yield return new object[] { creatingOrderModel, getClient, creatingOrderDto,
                                       addOrder, addCommentForClient, crntProductModel, addCommentForOrder,
                                       getProductById, expected, getManager, getAmountProductOnStock };
        }
    }
}

