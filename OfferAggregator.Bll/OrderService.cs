using AutoMapper;
using Microsoft.Data.SqlClient;
using OfferAggregator.Bll;
using OfferAggregator.Bll.Models;
using OfferAggregator.Dal.Models;
using OfferAggregator.Dal;
using System.Data;
using OfferAggregator.Dal.Repositories;
using Dapper;
using System.Linq.Expressions;

namespace OfferAggregator.Bll
{
    public class OrderService
    {
        private Mapper _instanceMapper = Mapper.GetInstance();

        IManagerRepository _managerRepository;

        IClientRepository _clientRepository;

        IOrderRepository _orderRepository;

        IOrdersProductsRepository _ordersProductsRepository;

        IProductsRepository _productsRepository;

        ICommentForOrderRepository _commentForOrderRepository;

        ICommentForClientRepository _commentForClientRepository;

        public OrderService(ManagerRepository managerRepository, ClientRepository clientRepository, OrderRepository orderRepository,
                            OrdersProductsRepository ordersProductsRepository, ProductsRepository productsRepository, CommentForOrderRepository commentForOrderRepository,
                            CommentForClientRepository commentForClientRepository)
        {
            _managerRepository = managerRepository;
            _clientRepository = clientRepository;
            _orderRepository = orderRepository;
            _ordersProductsRepository = ordersProductsRepository;
            _productsRepository = productsRepository;
            _commentForOrderRepository = commentForOrderRepository;
            _commentForClientRepository = commentForClientRepository;
        }

        public bool CreateNewOrder(CreatingOrderModel creatingOrderModel)
        {
            try
            {
                //обойтись без Пасворда?
                ManagerDto getManager = _managerRepository.GetSingleManager(creatingOrderModel.Order.Manager.Login, creatingOrderModel.Order.Manager.Password);
                ClientsDto getClient = _clientRepository.GetClientById(creatingOrderModel.Order.ClientId);
                OrderDto getOrder = _orderRepository.GetOrderById(creatingOrderModel.Order.Id);
                if (getManager != null && getClient != null && getOrder != null)
                {
                    CreatingOrderDto creatingOrderDto = _instanceMapper.MapCreatingOrderModelToCreatingOrderDto(creatingOrderModel);
                    int addOrder = _orderRepository.AddOrder(creatingOrderDto.Order);

                    if (creatingOrderDto.CommentsForOrder != null && creatingOrderDto.CommentsForClient != null)
                    {
                        foreach (var crnt in creatingOrderDto.CommentsForOrder)
                        {
                            int addCommentForOrder = _commentForOrderRepository.AddCommentOrder(crnt);
                        }

                        foreach (var crnt in creatingOrderDto.CommentsForClient)
                        {
                            int addCommentForClient = _commentForClientRepository.AddComment(crnt);
                        }
                    }

                    List<OrdersProductsDto> getOrderProducts = creatingOrderDto.OrdersProducts.ToList();
                    if (getOrderProducts != null)
                    {
                        foreach (var crnt in getOrderProducts)
                        {
                            var getProductById = _productsRepository.GetProductById(crnt.ProductId);
                            if (getProductById != null)
                            {
                                bool addProductToOrder = _ordersProductsRepository.AddProductToOrders(crnt);
                            }
                        }
                    }

                    return true;
                }
                else
                {
                    return false;
                };
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

