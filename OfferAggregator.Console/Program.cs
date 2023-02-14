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
    Client = new ClientModel
    { 
        Id = 1,
        Name = "Medvedev",
        PhoneNumber = "8800"
    }
};

ProductCountModel pr1 = new ProductCountModel
{
    Id = 1,
    Name ="Kurica 1",
    Count=2
};

ProductCountModel pr2 = new ProductCountModel
{
    Id = 2,
    Name = "Sheep",
    Count = 4
};

ProductCountModel pr3 = new ProductCountModel
{
    Id = 3,
    Name = "Okuny 1",
    Count = 5
};

List<ProductCountModel> products = new List<ProductCountModel>
{
pr1, pr2, pr3
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
    Order =orderModel, 
    Products = products,
    CommentsForOrder = comOrList,
    CommentsForClient= comClList
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

OrderService orderService = new OrderService(_managerRepository, clRepo, orRepo, _ordersProductsRepository, _productsRepository, _commentForOrderRepository, _commentForClientRepository);


//var createOrder = orderService.CreateNewOrder(creatingOrderModel);

OrderDto o1 = new OrderDto { Client = new ClientsDto() };
OrderDto o2 = new OrderDto { Client = new ClientsDto() };
o1.Equals(o2);

Console.WriteLine();

