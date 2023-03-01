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

        private Mock<IProductsReviewsAndStocksRepository> _mockProductReviewAndStockRepo;

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
            _mockProductReviewAndStockRepo = new Mock<IProductsReviewsAndStocksRepository>();
            _orderService = new OrderService(
               _mockManagerRepo.Object,
               _mockClientRepo.Object,
               _mockOrderRepo.Object,
               _mockOrdersProductsRepo.Object,
               _mockProductsRepo.Object,
               _mockCommentForOrderRepo.Object,
               _mockCommentForClientRepo.Object,
               _mockProductReviewAndStockRepo.Object);
        }

        [TestCaseSource(typeof(OrderServiceTestCaseSource), nameof(OrderServiceTestCaseSource.CreateNewOrderWithOneProductTestCaseSource))]
        public void CreateNewOrderWithOneProductTest(CreatingOrderInputModel creatingOrderModel, ClientsDto getClient, CreatingOrderDto creatingOrderDto,int addOrder, int addCommentForOrder, 
                                               int addCommentForClient, ProductCountInputModel crntProductModel, ProductsDto getProductById,OrdersProductsDto ordersProductsDto, bool addProductToOrder, 
                                               int expected, ManagerDto getManager, StocksDtoWithProductName getAmountProductOnStock, StocksDtoWithProductName stockProduct)
        {
            _mockClientRepo.Setup(c => c.GetClientById(creatingOrderModel.Order.ClientId)).Returns(getClient).Verifiable();
            _mockManagerRepo.Setup(m => m.GetManagerById(creatingOrderModel.Order.ManagerId)).Returns(getManager).Verifiable();
            _mockOrderRepo.Setup(o => o.AddOrder(It.Is<OrderDto>(co => co.Equals(creatingOrderDto.Order)))).Returns(addOrder).Verifiable();
            _mockCommentForOrderRepo.Setup(comO => comO.AddCommentOrder(It.IsAny<CommenForOrderDto>())).Returns(addCommentForOrder).Verifiable();
            _mockCommentForClientRepo.Setup(comO => comO.AddComment(It.IsAny<CommentForClientDto>())).Returns(addCommentForClient).Verifiable();
            _mockProductsRepo.Setup(p => p.GetProductById(crntProductModel.Id)).Returns(getProductById).Verifiable();
            _mockOrdersProductsRepo.Setup(op => op.AddProductToOrders(It.Is<OrdersProductsDto>(op => op.Equals(ordersProductsDto)))).Returns(addProductToOrder).Verifiable();
            _mockProductReviewAndStockRepo.Setup(prs => prs.GetAmountByProductId(crntProductModel.Id)).Returns(getAmountProductOnStock).Verifiable();
            _mockProductReviewAndStockRepo.Setup(prs => prs.UpdateAmountOfStocks(It.Is<StocksDtoWithProductName>(prs => prs.Equals(stockProduct)))).Returns(true).Verifiable();

            int actual = _orderService.CreateNewOrder(creatingOrderModel);

            _mockClientRepo.VerifyAll();
            _mockManagerRepo.VerifyAll();
            _mockOrderRepo.VerifyAll();
            _mockCommentForOrderRepo.VerifyAll();
            _mockCommentForClientRepo.VerifyAll();
            _mockProductsRepo.VerifyAll();
            _mockOrdersProductsRepo.VerifyAll();
            _mockProductReviewAndStockRepo.VerifyAll();

            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(OrderServiceTestCaseSource), nameof(OrderServiceTestCaseSource.CreateNewOrderWithTwoProductTestCaseSource))]
        public void CreateNewOrderWithTwoProductTest(CreatingOrderInputModel creatingOrderModel, ClientsDto getClient, CreatingOrderDto creatingOrderDto,
                                       int addOrder, int addCommentForOrder, int addCommentForClient, ProductCountInputModel crntProductModel1,
                                       ProductCountInputModel crntProductModel2, ProductsDto getProductById, OrdersProductsDto ordersProductsDto1,
                                       OrdersProductsDto ordersProductsDto2, bool addProductToOrder, int expected, ManagerDto getManager,
                                       StocksDtoWithProductName getAmountProductOnStock1, StocksDtoWithProductName getAmountProductOnStock2,
                                       StocksDtoWithProductName stockProduct1, StocksDtoWithProductName stockProduct2)
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
            _mockProductReviewAndStockRepo.Setup(prs => prs.GetAmountByProductId(crntProductModel1.Id)).Returns(getAmountProductOnStock1).Verifiable();
            _mockProductReviewAndStockRepo.Setup(prs => prs.GetAmountByProductId(crntProductModel2.Id)).Returns(getAmountProductOnStock2).Verifiable();
            _mockProductReviewAndStockRepo.Setup(prs => prs.UpdateAmountOfStocks(It.Is<StocksDtoWithProductName>(prs => prs.Equals(stockProduct1)))).Returns(true).Verifiable();
            _mockProductReviewAndStockRepo.Setup(prs => prs.UpdateAmountOfStocks(It.Is<StocksDtoWithProductName>(prs => prs.Equals(stockProduct2)))).Returns(true).Verifiable();

            int actual = _orderService.CreateNewOrder(creatingOrderModel);

            _mockClientRepo.VerifyAll();
            _mockManagerRepo.VerifyAll();
            _mockOrderRepo.VerifyAll();
            _mockCommentForOrderRepo.VerifyAll();
            _mockCommentForClientRepo.VerifyAll();
            _mockProductsRepo.VerifyAll();
            _mockOrdersProductsRepo.VerifyAll();
            _mockProductReviewAndStockRepo.VerifyAll();

            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(OrderServiceTestCaseSource), nameof(OrderServiceTestCaseSource.CreateNewOrderWithOneProduct_WhenManagerIsNotExistTestCaseSource))]
        public void CreateNewOrderWithOneProduct_WhenManagerIsNotExistTest(CreatingOrderInputModel creatingOrderModel, ClientsDto getClient, ManagerDto getManager, int expected)
        {
            _mockManagerRepo.Setup(m => m.GetManagerById(creatingOrderModel.Order.ManagerId)).Returns(getManager).Verifiable();

            int actual = _orderService.CreateNewOrder(creatingOrderModel);

            _mockClientRepo.Verify(c => c.GetClientById(It.IsAny<int>()), Times.Never);
            _mockManagerRepo.VerifyAll();
            _mockOrderRepo.Verify(or => or.AddOrder(It.IsAny<OrderDto>()), Times.Never);
            _mockCommentForOrderRepo.Verify(comO => comO.AddCommentOrder(It.IsAny<CommenForOrderDto>()), Times.Never);
            _mockCommentForClientRepo.Verify(comC => comC.AddComment(It.IsAny<CommentForClientDto>()), Times.Never);
            _mockProductsRepo.Verify(p => p.GetProductById(It.IsAny<int>()), Times.Never);
            _mockOrdersProductsRepo.Verify(op => op.AddProductToOrders(It.IsAny<OrdersProductsDto>()), Times.Never);

            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(OrderServiceTestCaseSource), nameof(OrderServiceTestCaseSource.CreateNewOrderWithOneProduct_WhenClientIsNotExistTestCaseSource))]
        public void CreateNewOrderWithOneProduct_WhenClientIsNotExistTest(CreatingOrderInputModel creatingOrderModel, ClientsDto getClient, ManagerDto getManager, int expected)
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
        public void CreateNewOrderWithOneProduct_WhenComplitionDateEarlierThenDateCreateTest(CreatingOrderInputModel creatingOrderModel, ClientsDto getClient, ManagerDto getManager, int expected)
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
        public void CreateNewOrderWithOneProduct_WhenCommentsForOrderIsNullTest(CreatingOrderInputModel creatingOrderModel, ClientsDto getClient, CreatingOrderDto creatingOrderDto,
                                       int addOrder, int addCommentForClient, ProductCountInputModel crntProductModel, ProductsDto getProductById, OrdersProductsDto ordersProductsDto,
                                       bool addProductToOrder, int expected, ManagerDto getManager, StocksDtoWithProductName getAmountProductOnStock, StocksDtoWithProductName stockProduct)
        {
            _mockClientRepo.Setup(c => c.GetClientById(creatingOrderModel.Order.ClientId)).Returns(getClient).Verifiable();
            _mockManagerRepo.Setup(m => m.GetManagerById(creatingOrderModel.Order.ManagerId)).Returns(getManager).Verifiable();
            _mockOrderRepo.Setup(o => o.AddOrder(It.Is<OrderDto>(co => co.Equals(creatingOrderDto.Order)))).Returns(addOrder).Verifiable();
            _mockCommentForClientRepo.Setup(comO => comO.AddComment(It.IsAny<CommentForClientDto>())).Returns(addCommentForClient).Verifiable();
            _mockProductsRepo.Setup(p => p.GetProductById(crntProductModel.Id)).Returns(getProductById).Verifiable();
            _mockOrdersProductsRepo.Setup(op => op.AddProductToOrders(It.Is<OrdersProductsDto>(op => op.Equals(ordersProductsDto)))).Returns(addProductToOrder).Verifiable();
            _mockProductReviewAndStockRepo.Setup(prs => prs.GetAmountByProductId(crntProductModel.Id)).Returns(getAmountProductOnStock).Verifiable();
            _mockProductReviewAndStockRepo.Setup(prs => prs.UpdateAmountOfStocks(It.Is<StocksDtoWithProductName>(prs => prs.Equals(stockProduct)))).Returns(true).Verifiable();

            int actual = _orderService.CreateNewOrder(creatingOrderModel);

            _mockClientRepo.VerifyAll();
            _mockManagerRepo.VerifyAll();
            _mockOrderRepo.VerifyAll();
            _mockCommentForOrderRepo.Verify(comO => comO.AddCommentOrder(It.IsAny<CommenForOrderDto>()), Times.Never);
            _mockCommentForClientRepo.VerifyAll();
            _mockProductsRepo.VerifyAll();
            _mockOrdersProductsRepo.VerifyAll();
            _mockProductReviewAndStockRepo.VerifyAll();


            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(OrderServiceTestCaseSource), nameof(OrderServiceTestCaseSource.CreateNewOrderWithOneProduct_WhenCommentsForClientIsNullTestCaseSource))]
        public void CreateNewOrderWithOneProduct_WhenCommentsForClientIsNullTest(CreatingOrderInputModel creatingOrderModel, ClientsDto getClient, CreatingOrderDto creatingOrderDto,
                                       int addOrder, int addCommentForOrder, ProductCountInputModel crntProductModel,ProductsDto getProductById, OrdersProductsDto ordersProductsDto,
                                       bool addProductToOrder, int expected, ManagerDto getManager, StocksDtoWithProductName getAmountProductOnStock, StocksDtoWithProductName stockProduct)
        {
            _mockClientRepo.Setup(c => c.GetClientById(creatingOrderModel.Order.ClientId)).Returns(getClient).Verifiable();
            _mockManagerRepo.Setup(m => m.GetManagerById(creatingOrderModel.Order.ManagerId)).Returns(getManager).Verifiable();
            _mockOrderRepo.Setup(o => o.AddOrder(It.Is<OrderDto>(co => co.Equals(creatingOrderDto.Order)))).Returns(addOrder).Verifiable();
            _mockCommentForOrderRepo.Setup(comO => comO.AddCommentOrder(It.IsAny<CommenForOrderDto>())).Returns(addCommentForOrder).Verifiable();
            _mockProductsRepo.Setup(p => p.GetProductById(crntProductModel.Id)).Returns(getProductById).Verifiable();
            _mockOrdersProductsRepo.Setup(op => op.AddProductToOrders(It.Is<OrdersProductsDto>(op => op.Equals(ordersProductsDto)))).Returns(addProductToOrder).Verifiable();
            _mockProductReviewAndStockRepo.Setup(prs => prs.GetAmountByProductId(crntProductModel.Id)).Returns(getAmountProductOnStock).Verifiable();
            _mockProductReviewAndStockRepo.Setup(prs => prs.UpdateAmountOfStocks(It.Is<StocksDtoWithProductName>(prs=>prs.Equals(stockProduct)))).Returns(true).Verifiable();

            int actual = _orderService.CreateNewOrder(creatingOrderModel);

            _mockClientRepo.VerifyAll();
            _mockManagerRepo.VerifyAll();
            _mockOrderRepo.VerifyAll();
            _mockCommentForOrderRepo.VerifyAll();
            _mockCommentForClientRepo.Verify(comC => comC.AddComment(It.IsAny<CommentForClientDto>()), Times.Never);
            _mockProductsRepo.VerifyAll();
            _mockOrdersProductsRepo.VerifyAll();
            _mockProductReviewAndStockRepo.VerifyAll();

            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(OrderServiceTestCaseSource), nameof(OrderServiceTestCaseSource.CreateNewOrderWithOneProduct_WhenProductIsNotExistTestCaseSource))]
        public void CreateNewOrderWithOneProduct_WhenProductIsNotExistTest(CreatingOrderInputModel creatingOrderModel, ClientsDto getClient, CreatingOrderDto creatingOrderDto,
                                       int addOrder, int addCommentForClient, ProductCountInputModel crntProductModel, int addCommentForOrder,
                                       ProductsDto getProductById, int expected, ManagerDto getManager)
        {
            _mockClientRepo.Setup(c => c.GetClientById(creatingOrderModel.Order.ClientId)).Returns(getClient).Verifiable();
            _mockManagerRepo.Setup(m => m.GetManagerById(creatingOrderModel.Order.ManagerId)).Returns(getManager).Verifiable();
            _mockProductsRepo.Setup(p => p.GetProductById(crntProductModel.Id)).Returns(getProductById).Verifiable();

            int actual = _orderService.CreateNewOrder(creatingOrderModel);

            _mockClientRepo.VerifyAll();
            _mockManagerRepo.VerifyAll();
            _mockOrderRepo.Verify(o => o.AddOrder(It.IsAny<OrderDto>()), Times.Never);
            _mockCommentForOrderRepo.Verify(comO => comO.AddCommentOrder(It.IsAny<CommenForOrderDto>()),Times.Never);
            _mockCommentForClientRepo.Verify(comC => comC.AddComment(It.IsAny<CommentForClientDto>()), Times.Never);
            _mockProductsRepo.VerifyAll();
            _mockOrdersProductsRepo.Verify(op => op.AddProductToOrders(It.IsAny<OrdersProductsDto>()), Times.Never);

            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(OrderServiceTestCaseSource), nameof(OrderServiceTestCaseSource.CreateNewOrderWithOneProduct_WhenAmountOnStockLessThenAmountProductInOrderTestCaseSource))]
        public void CreateNewOrderWithOneProduct_WhenAmountOnStockLessThenAmountProductInOrderTest(CreatingOrderInputModel creatingOrderModel, ClientsDto getClient, CreatingOrderDto creatingOrderDto,
                                       int addOrder, int addCommentForClient, ProductCountInputModel crntProductModel, int addCommentForOrder,
                                       ProductsDto getProductById, int expected, ManagerDto getManager, StocksDtoWithProductName getAmountProductOnStock)
        {
            _mockClientRepo.Setup(c => c.GetClientById(creatingOrderModel.Order.ClientId)).Returns(getClient).Verifiable();
            _mockManagerRepo.Setup(m => m.GetManagerById(creatingOrderModel.Order.ManagerId)).Returns(getManager).Verifiable();
            _mockProductsRepo.Setup(p => p.GetProductById(crntProductModel.Id)).Returns(getProductById).Verifiable();
            _mockProductReviewAndStockRepo.Setup(prs => prs.GetAmountByProductId(crntProductModel.Id)).Returns(getAmountProductOnStock).Verifiable();

            int actual = _orderService.CreateNewOrder(creatingOrderModel);

            _mockClientRepo.VerifyAll();
            _mockManagerRepo.VerifyAll();
            _mockOrderRepo.Verify(o => o.AddOrder(It.IsAny<OrderDto>()), Times.Never);
            _mockCommentForOrderRepo.Verify(comO => comO.AddCommentOrder(It.IsAny<CommenForOrderDto>()), Times.Never);
            _mockCommentForClientRepo.Verify(comC => comC.AddComment(It.IsAny<CommentForClientDto>()), Times.Never);
            _mockProductsRepo.VerifyAll();
            _mockOrdersProductsRepo.Verify(op => op.AddProductToOrders(It.IsAny<OrdersProductsDto>()), Times.Never);
            _mockProductReviewAndStockRepo.VerifyAll();
            _mockProductReviewAndStockRepo.Verify(prs => prs.UpdateAmountOfStocks(It.IsAny<StocksDtoWithProductName>()), Times.Never);

            Assert.AreEqual(expected, actual);
        }
    }
}