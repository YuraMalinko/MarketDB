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

        public OrderService(IManagerRepository managerRepository, IClientRepository clientRepository, IOrderRepository orderRepository,
                            IOrdersProductsRepository ordersProductsRepository, IProductsRepository productsRepository, ICommentForOrderRepository commentForOrderRepository,
                            ICommentForClientRepository commentForClientRepository)
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
                ManagerDto getManager = _instanceMapper.MapCurrentManagerToManagerDto(creatingOrderModel.Order.Manager);
                ClientsDto getClient = _clientRepository.GetClientById(creatingOrderModel.Order.ClientId);
                OrderDto getOrder = _orderRepository.GetOrderById(creatingOrderModel.Order.Id);
                if (getManager != null && getClient != null && getOrder != null)
                {
                    CreatingOrderDto creatingOrderDto = _instanceMapper.MapCreatingOrderModelToCreatingOrderDto(creatingOrderModel);
                    int addOrder = _orderRepository.AddOrder(creatingOrderDto.Order);

                    if (creatingOrderDto.CommentsForOrder != null)
                    {
                        foreach (var crnt in creatingOrderDto.CommentsForOrder)
                        {
                            int addCommentForOrder = _commentForOrderRepository.AddCommentOrder(crnt);
                        }
                    }

                    if (creatingOrderDto.CommentsForClient != null)
                    {
                        foreach (var crnt in creatingOrderDto.CommentsForClient)
                        {
                            int addCommentForClient = _commentForClientRepository.AddComment(crnt);
                        }
                    }

                    List<ProductCountModel> getProducts = creatingOrderModel.Products;
                    if (getProducts != null)
                    {
                        foreach (var crnt in getProducts)
                        {
                            var getProductById = _productsRepository.GetProductById(crnt.Id);
                            if (getProductById != null)
                            {
                                OrdersProductsDto ordersProductsDto = new OrdersProductsDto
                                {
                                    OrderId = creatingOrderModel.Order.Id,
                                    ProductId = crnt.Id,
                                    CountProduct = crnt.Count
                                };
                                bool addProductToOrder = _ordersProductsRepository.AddProductToOrders(ordersProductsDto);
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

