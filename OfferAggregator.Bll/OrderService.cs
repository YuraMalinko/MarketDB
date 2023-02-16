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
using System.Collections.Generic;

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

        //public int CreateNewOrder(CreatingOrderModel creatingOrderModel)
        //{
        //    try
        //    {
        //        ManagerDto getManager = _managerRepository.GetManagerById(creatingOrderModel.Order.ManagerId);
        //        ClientsDto getClient = _clientRepository.GetClientById(creatingOrderModel.Order.ClientId);
        //        if (getManager != null && getClient != null && creatingOrderModel.Order.DateCreate < creatingOrderModel.Order.ComplitionDate)
        //        {
        //            CreatingOrderDto creatingOrderDto = _instanceMapper.MapCreatingOrderModelToCreatingOrderDto(creatingOrderModel);
        //            int addOrder = _orderRepository.AddOrder(creatingOrderDto.Order);
        //            creatingOrderModel.Order.Id = addOrder;

        //            if (creatingOrderDto.CommentsForOrder != null)
        //            {
        //                foreach (var crnt in creatingOrderDto.CommentsForOrder)
        //                {
        //                    crnt.OrderId = addOrder;
        //                    int addCommentForOrder = _commentForOrderRepository.AddCommentOrder(crnt);
        //                }
        //            }

        //            if (creatingOrderDto.CommentsForClient != null)
        //            {
        //                foreach (var crnt in creatingOrderDto.CommentsForClient)
        //                {
        //                    int addCommentForClient = _commentForClientRepository.AddComment(crnt);
        //                }
        //            }

        //            List<ProductCountModel> getProducts = creatingOrderModel.Products;

        //            if (getProducts != null)
        //            {
        //                foreach (var crnt in getProducts)
        //                {
        //                    var getProductById = _productsRepository.GetProductById(crnt.Id);
        //                    if (getProductById != null)
        //                    {
        //                        OrdersProductsDto ordersProductsDto = new OrdersProductsDto
        //                        {
        //                            OrderId = creatingOrderModel.Order.Id,
        //                            ProductId = crnt.Id,
        //                            CountProduct = crnt.Count
        //                        };
        //                        bool addProductToOrder = _ordersProductsRepository.AddProductToOrders(ordersProductsDto);
        //                    }
        //                    else
        //                    {
        //                        return -1;
        //                    };
        //                }
        //            }

        //            return addOrder;
        //        }
        //        else
        //        {
        //            return -1;
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        return -1;
        //    }
        //}

        public int CreateNewOrder(CreatingOrderModel creatingOrderModel)
        {
            try
            {
                if (CheckManager(creatingOrderModel.Order.ManagerId)
                     && CheckClient(creatingOrderModel.Order.ClientId)
                     && creatingOrderModel.Order.DateCreate < creatingOrderModel.Order.ComplitionDate
                     && CheckProduct(creatingOrderModel.Products))
                {
                    CreatingOrderDto creatingOrderDto = _instanceMapper.MapCreatingOrderModelToCreatingOrderDto(creatingOrderModel);
                    int addOrder = _orderRepository.AddOrder(creatingOrderDto.Order);
                    creatingOrderModel.Order.Id = addOrder;

                    if (creatingOrderDto.CommentsForOrder != null)
                    {
                        AddCommentsForOrder(creatingOrderDto.CommentsForOrder, addOrder);
                    }

                    if (creatingOrderDto.CommentsForClient != null)
                    {
                        AddCommentsForClient(creatingOrderDto.CommentsForClient);
                    }

                    foreach (var crnt in creatingOrderModel.Products)
                    {
                        AddProductDto(creatingOrderModel.Order.Id, crnt.Id, crnt.Count);
                    }

                    return addOrder;
                }
                else if (CheckManager(creatingOrderModel.Order.ManagerId)
                     && CheckClient(creatingOrderModel.Order.ClientId)
                     && creatingOrderModel.Order.DateCreate < creatingOrderModel.Order.ComplitionDate
                     && !CheckListProductsCounts(creatingOrderModel.Products))
                {
                    CreatingOrderDto creatingOrderDto = _instanceMapper.MapCreatingOrderModelToCreatingOrderDto(creatingOrderModel);
                    int addOrder = _orderRepository.AddOrder(creatingOrderDto.Order);
                    creatingOrderModel.Order.Id = addOrder;

                    if (creatingOrderDto.CommentsForOrder != null)
                    {
                        AddCommentsForOrder(creatingOrderDto.CommentsForOrder, addOrder);
                    }

                    if (creatingOrderDto.CommentsForClient != null)
                    {
                        AddCommentsForClient(creatingOrderDto.CommentsForClient);
                    }

                    return addOrder;
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        private bool CheckManager(int managerId)
        {
            ManagerDto getManager = _managerRepository.GetManagerById(managerId);

            return getManager != null;
        }

        private bool CheckClient(int clientId)
        {
            ClientsDto getClient = _clientRepository.GetClientById(clientId);

            return getClient != null;
        }

        private bool CheckListProductsCounts(List<ProductCountModel> productsCounts)
        {
            return productsCounts != null;
        }

        private bool CheckProduct(List<ProductCountModel> productsCounts)
        {
            if (productsCounts != null)
            {
                foreach (var crnt in productsCounts)
                {
                    var getProductById = _productsRepository.GetProductById(crnt.Id);
                    if (getProductById == null)
                    {
                        return false;
                    }
                }
                return true;
            }

            return false;
        }

        private bool AddCommentsForOrder(List<CommenForOrderDto> commentsForOrder, int addOrder)
        {
            foreach (var crnt in commentsForOrder)
            {
                if (crnt != null)
                {
                    crnt.OrderId = addOrder;
                    int addCommentForOrder = _commentForOrderRepository.AddCommentOrder(crnt);
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        private bool AddCommentsForClient(List<CommentForClientDto> commentsForClient)
        {
            foreach (var crnt in commentsForClient)
            {
                if (crnt != null)
                {
                    int addComment = _commentForClientRepository.AddComment(crnt);
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        private bool AddProductDto(int orderId, int productId, int countProduct)
        {
            OrdersProductsDto ordersProductsDto = new OrdersProductsDto
            {
                OrderId = orderId,
                ProductId = productId,
                CountProduct = countProduct
            };

            return _ordersProductsRepository.AddProductToOrders(ordersProductsDto);
        }
    }
}
