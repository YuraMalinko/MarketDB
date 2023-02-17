using OfferAggregator.Bll;
using OfferAggregator.Bll.Models;
using OfferAggregator.Dal.Models;
using OfferAggregator.Dal.Repositories;
using OfferAggregator.Bll;
using OfferAggregator.Bll.Models;
using System.Net.Http.Headers;


//ManagerModel manM = new ManagerModel
//{
//    Id = 6,
//    Login = "Andrew",
//    Password = "qqq"
//};

DateTime date1 = new DateTime(2022, 02, 15, 12, 00, 00);
DateTime complitionDate = new DateTime(2023, 02, 15, 12, 30, 00);

OrderModel orderModel = new OrderModel
{
    ManagerId = 15,
    ClientId = 12,
    DateCreate = date1,
    ComplitionDate = complitionDate,
    Manager = new CurrentManager(15, "Kristina", "qqq"),
    Client = new ClientModel
    {
        Id = 12,
        Name = "client",
        PhoneNumber = "999999"
    }
};

ProductCountModel pr1 = new ProductCountModel
{
    Id = 50,
    Name = "earlGrey",
    Count = 0
};

ProductCountModel pr2 = new ProductCountModel
{
    Id = 50,
    Name = "Baltika",
    Count = 0
};



List<ProductCountModel> products = new List<ProductCountModel>
{
pr1, pr2
};

//OrdersProductModel op1 = new OrdersProductModel
//{ 
//OrderId = 4,
//ProductId = 1,
//CountProduct = 2
//};

//OrdersProductModel op2 = new OrdersProductModel
//{
//    OrderId = 4,
//    ProductId = 2,
//    CountProduct = 4
//};

//OrdersProductModel op3 = new OrdersProductModel
//{
//    OrderId = 4,
//    ProductId = 3,
//    CountProduct = 5
//};

//List <OrdersProductModel> opList= new List<OrdersProductModel> { op1 , op2 , op3 };

//List<CommentForOrderModel> commentsForOrder = new List<CommentForOrderModel>();

//List<CommentForClientModel> commentsForClient = new List<CommentForClientModel>();

CommentForClientModel com1Cl = new CommentForClientModel()
{
    
    Text = "love her!!!",
    ClientId = 12
};


List<CommentForClientModel> comClList = new List<CommentForClientModel>();

CommentForOrderModel comOr1 = new CommentForOrderModel
{
    Text = "cool !!!"
};

List<CommentForOrderModel> comOrList = new List<CommentForOrderModel>();

CreatingOrderModel creatingOrderModel = new CreatingOrderModel
{
    Order = orderModel,
    Products = products,
    CommentsForOrder = comOrList,
    CommentsForClient = comClList
};


Mapper map = Mapper.GetInstance();

//var res = map.MapCreatingOrderModelToCreatingOrderDto(creatingOrderModel);

ClientRepository clRepo = new ClientRepository();

//var get = clRepo.GetClientById(3);

OrderRepository orRepo = new OrderRepository();

//var get = orRepo.GetOrderById(13);


ManagerRepository _managerRepository = new ManagerRepository();

OrdersProductsRepository _ordersProductsRepository = new OrdersProductsRepository();

ProductsRepository _productsRepository = new ProductsRepository();

CommentForOrderRepository _commentForOrderRepository = new CommentForOrderRepository();

CommentForClientRepository _commentForClientRepository = new CommentForClientRepository();

ProductsReviewsAndStocksRepository _productsReviewsAndStocksRepository = new ProductsReviewsAndStocksRepository();

OrderService orderService = new OrderService(_managerRepository, clRepo, orRepo, _ordersProductsRepository, _productsRepository, _commentForOrderRepository, _commentForClientRepository, _productsReviewsAndStocksRepository);


var createOrder = orderService.CreateNewOrder(creatingOrderModel);

//OrderDto o1 = new OrderDto { Client = new ClientsDto() };
//OrderDto o2 = new OrderDto { Client = new ClientsDto() };
//o1.Equals(o2);

Console.WriteLine();

