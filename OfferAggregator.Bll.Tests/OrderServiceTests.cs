﻿using OfferAggregator.Bll.Models;
using OfferAggregator.Bll.Tests.TestCaseSource;
using OfferAggregator.Dal.Models;
using FluentAssertions;
using Moq;
using OfferAggregator.Dal.Repositories;
using System.Text.RegularExpressions;

namespace OfferAggregator.Bll.Tests
{
    public class OrderServiceTests
    {
        private OrderService _orderService;

        private Mock<IManagerRepository> _mockManagerRepo;

        private Mock<IClientRepository> _mockClientRepo;

        private Mock<IOrderRepository> _mockOrderRepo;

        private Mock<IOrdersProductsRepository> _mockOrdersProductsRepo;

        private Mock<IProductsRepository> _mockProductsRepo;

        private Mock<ICommentForOrderRepository> _mockCommentForOrderRepo;

        private Mock<ICommentForClientRepository> _mockCommentForClientRepo;

        [SetUp]

        public void SetUp()
        {
            _mockManagerRepo = new Mock<IManagerRepository>();
            _mockClientRepo = new Mock<IClientRepository>();
            _mockOrderRepo = new Mock<IOrderRepository>();
            _mockOrdersProductsRepo = new Mock<IOrdersProductsRepository>();
            _mockProductsRepo = new Mock<IProductsRepository>();
            _mockCommentForOrderRepo = new Mock<ICommentForOrderRepository>();
            _mockCommentForClientRepo = new Mock<ICommentForClientRepository>();
            _orderService = new OrderService(
               _mockManagerRepo.Object,
               _mockClientRepo.Object,
               _mockOrderRepo.Object,
               _mockOrdersProductsRepo.Object,
               _mockProductsRepo.Object,
               _mockCommentForOrderRepo.Object,
               _mockCommentForClientRepo.Object);
        }

        [TestCaseSource(typeof(OrderServiceTestCaseSource), nameof(OrderServiceTestCaseSource.CreateNewOrderWithOneProductTestCaseSource))]
        public void CreateNewOrderWithOneProductTest(CreatingOrderModel creatingOrderModel, ClientsDto getClient, CreatingOrderDto creatingOrderDto,
                                       int addOrder, int addCommentForOrder, int addCommentForClient, ProductCountModel crntProductModel,
                                       ProductsDto getProductById, OrdersProductsDto ordersProductsDto, bool addProductToOrder, int expected, ManagerDto getManager)
        {
            _mockClientRepo.Setup(c => c.GetClientById(creatingOrderModel.Order.ClientId)).Returns(getClient).Verifiable();
            _mockManagerRepo.Setup(m => m.GetManagerById(creatingOrderModel.Order.ManagerId)).Returns(getManager).Verifiable();
            _mockOrderRepo.Setup(o => o.AddOrder(It.Is<OrderDto>(co => co.Equals(creatingOrderDto.Order)))).Returns(addOrder).Verifiable();
            _mockCommentForOrderRepo.Setup(comO => comO.AddCommentOrder(It.IsAny<CommenForOrderDto>())).Returns(addCommentForOrder).Verifiable();
            _mockCommentForClientRepo.Setup(comO => comO.AddComment(It.IsAny<CommentForClientDto>())).Returns(addCommentForClient).Verifiable();
            _mockProductsRepo.Setup(p => p.GetProductById(crntProductModel.Id)).Returns(getProductById).Verifiable();
            _mockOrdersProductsRepo.Setup(op => op.AddProductToOrders(It.Is<OrdersProductsDto>(op => op.Equals(ordersProductsDto)))).Returns(addProductToOrder).Verifiable();

            int actual = _orderService.CreateNewOrder(creatingOrderModel);

            _mockClientRepo.VerifyAll();
            _mockManagerRepo.VerifyAll();
            _mockOrderRepo.VerifyAll();
            _mockCommentForOrderRepo.VerifyAll();
            _mockCommentForClientRepo.VerifyAll();
            _mockProductsRepo.VerifyAll();
            _mockOrdersProductsRepo.VerifyAll();

            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(OrderServiceTestCaseSource), nameof(OrderServiceTestCaseSource.CreateNewOrderWithTwoProductTestCaseSource))]
        public void CreateNewOrderWithTwoProductTest(CreatingOrderModel creatingOrderModel, ClientsDto getClient, CreatingOrderDto creatingOrderDto,
                                       int addOrder, int addCommentForOrder, int addCommentForClient, ProductCountModel crntProductModel1,
                                       ProductCountModel crntProductModel2, ProductsDto getProductById, OrdersProductsDto ordersProductsDto1,
                                       OrdersProductsDto ordersProductsDto2, bool addProductToOrder, int expected, ManagerDto getManager)
        {
            _mockClientRepo.Setup(c => c.GetClientById(creatingOrderModel.Order.ClientId)).Returns(getClient).Verifiable();
            _mockManagerRepo.Setup(m => m.GetManagerById(creatingOrderModel.Order.ManagerId)).Returns(getManager).Verifiable();
            _mockOrderRepo.Setup(o => o.AddOrder(It.Is<OrderDto>(co => co.Equals(creatingOrderDto.Order)))).Returns(addOrder).Verifiable();
            _mockCommentForOrderRepo.Setup(comO => comO.AddCommentOrder(It.IsAny<CommenForOrderDto>())).Returns(addCommentForOrder).Verifiable();
            _mockCommentForClientRepo.Setup(comO => comO.AddComment(It.IsAny<CommentForClientDto>())).Returns(addCommentForClient).Verifiable();
            _mockProductsRepo.Setup(p => p.GetProductById(crntProductModel1.Id)).Returns(getProductById).Verifiable();
            _mockProductsRepo.Setup(p => p.GetProductById(crntProductModel2.Id)).Returns(getProductById).Verifiable();
            _mockOrdersProductsRepo.Setup(op => op.AddProductToOrders(It.Is<OrdersProductsDto>(op => op.Equals(ordersProductsDto1)))).Returns(addProductToOrder).Verifiable();
            _mockOrdersProductsRepo.Setup(op => op.AddProductToOrders(It.Is<OrdersProductsDto>(op => op.Equals(ordersProductsDto2)))).Returns(addProductToOrder).Verifiable();

            int actual = _orderService.CreateNewOrder(creatingOrderModel);

            _mockClientRepo.VerifyAll();
            _mockManagerRepo.VerifyAll();
            _mockOrderRepo.VerifyAll();
            _mockCommentForOrderRepo.VerifyAll();
            _mockCommentForClientRepo.VerifyAll();
            _mockProductsRepo.VerifyAll();
            _mockOrdersProductsRepo.VerifyAll();

            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(OrderServiceTestCaseSource), nameof(OrderServiceTestCaseSource.CreateNewOrderWithOneProduct_WhenManagerIsNotExistTestCaseSource))]
        public void CreateNewOrderWithOneProduct_WhenManagerIsNotExistTest(CreatingOrderModel creatingOrderModel, ClientsDto getClient, ManagerDto getManager, int expected)
        {
            _mockClientRepo.Setup(c => c.GetClientById(creatingOrderModel.Order.ClientId)).Returns(getClient).Verifiable();
            _mockManagerRepo.Setup(m => m.GetManagerById(creatingOrderModel.Order.ManagerId)).Returns(getManager).Verifiable();

            int actual = _orderService.CreateNewOrder(creatingOrderModel);

            _mockClientRepo.VerifyAll();
            _mockManagerRepo.VerifyAll();
            _mockOrderRepo.Verify(or => or.AddOrder(It.IsAny<OrderDto>()), Times.Never);
            _mockCommentForOrderRepo.Verify(comO => comO.AddCommentOrder(It.IsAny<CommenForOrderDto>()), Times.Never);
            _mockCommentForClientRepo.Verify(comC => comC.AddComment(It.IsAny<CommentForClientDto>()), Times.Never);
            _mockProductsRepo.Verify(p => p.GetProductById(It.IsAny<int>()), Times.Never);
            _mockOrdersProductsRepo.Verify(op => op.AddProductToOrders(It.IsAny<OrdersProductsDto>()), Times.Never);

            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(OrderServiceTestCaseSource), nameof(OrderServiceTestCaseSource.CreateNewOrderWithOneProduct_WhenClientIsNotExistTestCaseSource))]
        public void CreateNewOrderWithOneProduct_WhenClientIsNotExistTest(CreatingOrderModel creatingOrderModel, ClientsDto getClient, ManagerDto getManager, int expected)
        {
            _mockClientRepo.Setup(c => c.GetClientById(creatingOrderModel.Order.ClientId)).Returns(getClient).Verifiable();
            _mockManagerRepo.Setup(m => m.GetManagerById(creatingOrderModel.Order.ManagerId)).Returns(getManager).Verifiable();

            int actual = _orderService.CreateNewOrder(creatingOrderModel);

            _mockClientRepo.VerifyAll();
            _mockManagerRepo.VerifyAll();
            _mockOrderRepo.Verify(or => or.AddOrder(It.IsAny<OrderDto>()), Times.Never);
            _mockCommentForOrderRepo.Verify(comO => comO.AddCommentOrder(It.IsAny<CommenForOrderDto>()), Times.Never);
            _mockCommentForClientRepo.Verify(comC => comC.AddComment(It.IsAny<CommentForClientDto>()), Times.Never);
            _mockProductsRepo.Verify(p => p.GetProductById(It.IsAny<int>()), Times.Never);
            _mockOrdersProductsRepo.Verify(op => op.AddProductToOrders(It.IsAny<OrdersProductsDto>()), Times.Never);

            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(OrderServiceTestCaseSource), nameof(OrderServiceTestCaseSource.CreateNewOrderWithOneProduct_WhenComplitionDateEarlierThenDateCreateTestCaseSource))]
        public void CreateNewOrderWithOneProduct_WhenComplitionDateEarlierThenDateCreateTest(CreatingOrderModel creatingOrderModel, ClientsDto getClient, ManagerDto getManager, int expected)
        {
            _mockClientRepo.Setup(c => c.GetClientById(creatingOrderModel.Order.ClientId)).Returns(getClient).Verifiable();
            _mockManagerRepo.Setup(m => m.GetManagerById(creatingOrderModel.Order.ManagerId)).Returns(getManager).Verifiable();

            int actual = _orderService.CreateNewOrder(creatingOrderModel);

            _mockClientRepo.VerifyAll();
            _mockManagerRepo.VerifyAll();
            _mockOrderRepo.Verify(or => or.AddOrder(It.IsAny<OrderDto>()), Times.Never);
            _mockCommentForOrderRepo.Verify(comO => comO.AddCommentOrder(It.IsAny<CommenForOrderDto>()), Times.Never);
            _mockCommentForClientRepo.Verify(comC => comC.AddComment(It.IsAny<CommentForClientDto>()), Times.Never);
            _mockProductsRepo.Verify(p => p.GetProductById(It.IsAny<int>()), Times.Never);
            _mockOrdersProductsRepo.Verify(op => op.AddProductToOrders(It.IsAny<OrdersProductsDto>()), Times.Never);

            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(OrderServiceTestCaseSource), nameof(OrderServiceTestCaseSource.CreateNewOrderWithOneProduct_WhenCommentsForOrderIsNullTestCaseSource))]
        public void CreateNewOrderWithOneProduct_WhenCommentsForOrderIsNullTest(CreatingOrderModel creatingOrderModel, ClientsDto getClient, CreatingOrderDto creatingOrderDto,
                                       int addOrder, int addCommentForClient, ProductCountModel crntProductModel,
                                       ProductsDto getProductById, OrdersProductsDto ordersProductsDto,bool addProductToOrder, int expected, ManagerDto getManager)
        {
            _mockClientRepo.Setup(c => c.GetClientById(creatingOrderModel.Order.ClientId)).Returns(getClient).Verifiable();
            _mockManagerRepo.Setup(m => m.GetManagerById(creatingOrderModel.Order.ManagerId)).Returns(getManager).Verifiable();
            _mockOrderRepo.Setup(o => o.AddOrder(It.Is<OrderDto>(co => co.Equals(creatingOrderDto.Order)))).Returns(addOrder).Verifiable();
            _mockCommentForClientRepo.Setup(comO => comO.AddComment(It.IsAny<CommentForClientDto>())).Returns(addCommentForClient).Verifiable();
            _mockProductsRepo.Setup(p => p.GetProductById(crntProductModel.Id)).Returns(getProductById).Verifiable();
            _mockOrdersProductsRepo.Setup(op => op.AddProductToOrders(It.Is<OrdersProductsDto>(op => op.Equals(ordersProductsDto)))).Returns(addProductToOrder).Verifiable();

            int actual = _orderService.CreateNewOrder(creatingOrderModel);

            _mockClientRepo.VerifyAll();
            _mockManagerRepo.VerifyAll();
            _mockOrderRepo.VerifyAll();
            _mockCommentForOrderRepo.Verify(comO => comO.AddCommentOrder(It.IsAny<CommenForOrderDto>()), Times.Never);
            _mockCommentForClientRepo.VerifyAll();
            _mockProductsRepo.VerifyAll();
            _mockOrdersProductsRepo.VerifyAll();

            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(OrderServiceTestCaseSource), nameof(OrderServiceTestCaseSource.CreateNewOrderWithOneProduct_WhenCommentsForClientIsNullTestCaseSource))]
        public void CreateNewOrderWithOneProduct_WhenCommentsForClientIsNullTest(CreatingOrderModel creatingOrderModel, ClientsDto getClient, CreatingOrderDto creatingOrderDto,
                                       int addOrder, int addCommentForOrder, ProductCountModel crntProductModel,
                                       ProductsDto getProductById, OrdersProductsDto ordersProductsDto, bool addProductToOrder, int expected, ManagerDto getManager)
        {
            _mockClientRepo.Setup(c => c.GetClientById(creatingOrderModel.Order.ClientId)).Returns(getClient).Verifiable();
            _mockManagerRepo.Setup(m => m.GetManagerById(creatingOrderModel.Order.ManagerId)).Returns(getManager).Verifiable();
            _mockOrderRepo.Setup(o => o.AddOrder(It.Is<OrderDto>(co => co.Equals(creatingOrderDto.Order)))).Returns(addOrder).Verifiable();
            _mockCommentForOrderRepo.Setup(comO => comO.AddCommentOrder(It.IsAny<CommenForOrderDto>())).Returns(addCommentForOrder).Verifiable();
            _mockProductsRepo.Setup(p => p.GetProductById(crntProductModel.Id)).Returns(getProductById).Verifiable();
            _mockOrdersProductsRepo.Setup(op => op.AddProductToOrders(It.Is<OrdersProductsDto>(op => op.Equals(ordersProductsDto)))).Returns(addProductToOrder).Verifiable();

            int actual = _orderService.CreateNewOrder(creatingOrderModel);

            _mockClientRepo.VerifyAll();
            _mockManagerRepo.VerifyAll();
            _mockOrderRepo.VerifyAll();
            _mockCommentForOrderRepo.VerifyAll();
            _mockCommentForClientRepo.Verify(comC => comC.AddComment(It.IsAny<CommentForClientDto>()), Times.Never);
            _mockProductsRepo.VerifyAll();
            _mockOrdersProductsRepo.VerifyAll();

            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(OrderServiceTestCaseSource), nameof(OrderServiceTestCaseSource.CreateNewOrderWithOneProduct_WhenProductIsNotExistTestCaseSource))]
        public void CreateNewOrderWithOneProduct_WhenProductIsNotExistTest(CreatingOrderModel creatingOrderModel, ClientsDto getClient, CreatingOrderDto creatingOrderDto,
                                       int addOrder, int addCommentForClient, ProductCountModel crntProductModel, int addCommentForOrder,
                                       ProductsDto getProductById, int expected, ManagerDto getManager)
        {
            _mockClientRepo.Setup(c => c.GetClientById(creatingOrderModel.Order.ClientId)).Returns(getClient).Verifiable();
            _mockManagerRepo.Setup(m => m.GetManagerById(creatingOrderModel.Order.ManagerId)).Returns(getManager).Verifiable();
            _mockOrderRepo.Setup(o => o.AddOrder(It.Is<OrderDto>(co => co.Equals(creatingOrderDto.Order)))).Returns(addOrder).Verifiable();
            _mockCommentForOrderRepo.Setup(comO => comO.AddCommentOrder(It.IsAny<CommenForOrderDto>())).Returns(addCommentForOrder).Verifiable();
            _mockCommentForClientRepo.Setup(comO => comO.AddComment(It.IsAny<CommentForClientDto>())).Returns(addCommentForClient).Verifiable();
            _mockProductsRepo.Setup(p => p.GetProductById(crntProductModel.Id)).Returns(getProductById).Verifiable();

            int actual = _orderService.CreateNewOrder(creatingOrderModel);

            _mockClientRepo.VerifyAll();
            _mockManagerRepo.VerifyAll();
            _mockOrderRepo.VerifyAll();
            _mockCommentForOrderRepo.VerifyAll();
            _mockCommentForClientRepo.VerifyAll();
            _mockProductsRepo.VerifyAll();
            _mockOrdersProductsRepo.Verify(op => op.AddProductToOrders(It.IsAny<OrdersProductsDto>()), Times.Never);

            Assert.AreEqual(expected, actual);
        }
    }
}