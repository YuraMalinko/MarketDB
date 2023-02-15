using OfferAggregator.Bll.Models;
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

        //[TestCaseSource(typeof(OrderServiceTestCaseSource), nameof(OrderServiceTestCaseSource.CreateNewOrderTestCaseSource))]
        //public void CreateNewOrderTest(CreatingOrderModel creatingOrderModel, ClientsDto getClient, OrderDto getOrder, CreatingOrderDto creatingOrderDto,
        //                               int addOrder, int addCommentForOrder, int addCommentForClient, ProductCountModel crntProductModel,
        //                               ProductsDto getProductById, OrdersProductsDto ordersProductsDto, bool addProductToOrder, bool expected)
        //{
        //    _mockClientRepo.Setup(c => c.GetClientById(creatingOrderModel.Order.ClientId)).Returns(getClient).Verifiable();
        //    _mockOrderRepo.Setup(o => o.GetOrderById(creatingOrderModel.Order.Id)).Returns(getOrder).Verifiable();
        //    _mockOrderRepo.Setup(o =>o.AddOrder(It.Is<OrderDto>(co => co.Equals(creatingOrderDto.Order)))).Returns(addOrder).Verifiable();
        //    _mockCommentForOrderRepo.Setup(comO => comO.AddCommentOrder(It.IsAny<CommenForOrderDto>())).Returns(addCommentForOrder).Verifiable();
        //    _mockCommentForClientRepo.Setup(comO => comO.AddComment(It.IsAny<CommentForClientDto>())).Returns(addCommentForClient).Verifiable();
        //    _mockProductsRepo.Setup(p => p.GetProductById(crntProductModel.Id)).Returns(getProductById).Verifiable();
        //    _mockOrdersProductsRepo.Setup(op => op.AddProductToOrders(ordersProductsDto)).Returns(addProductToOrder).Verifiable();

        //    bool actual = _orderService.CreateNewOrder(creatingOrderModel);

        //    _mockClientRepo.VerifyAll();
        //    _mockOrderRepo.VerifyAll();
        //    _mockCommentForOrderRepo.VerifyAll();
        //    _mockCommentForClientRepo.VerifyAll();
        //    _mockProductsRepo.VerifyAll();
        //    _mockOrdersProductsRepo.VerifyAll();

        //    Assert.AreEqual(expected, actual);
        //}

    }
}
