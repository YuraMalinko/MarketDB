﻿using AutoMapper;
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

        IProductsReviewsAndStocksRepository _productsReviewsAndStocksRepository;

        public OrderService(IManagerRepository managerRepository, IClientRepository clientRepository, IOrderRepository orderRepository,
                            IOrdersProductsRepository ordersProductsRepository, IProductsRepository productsRepository, ICommentForOrderRepository commentForOrderRepository,
                            ICommentForClientRepository commentForClientRepository, IProductsReviewsAndStocksRepository productsReviewsAndStocksRepository)
        {
            _managerRepository = managerRepository;
            _clientRepository = clientRepository;
            _orderRepository = orderRepository;
            _ordersProductsRepository = ordersProductsRepository;
            _productsRepository = productsRepository;
            _commentForOrderRepository = commentForOrderRepository;
            _commentForClientRepository = commentForClientRepository;
            _productsReviewsAndStocksRepository = productsReviewsAndStocksRepository;
        }

        public int CreateNewOrder(CreatingOrderModel creatingOrderModel)
        {
            try
            {
                if (CheckManager(creatingOrderModel.Order.ManagerId)
                     && CheckClient(creatingOrderModel.Order.ClientId)
                     && creatingOrderModel.Order.DateCreate < creatingOrderModel.Order.ComplitionDate
                     && CheckProduct(creatingOrderModel.Products)
                     && CheckAmountsListProducts(creatingOrderModel.Products))
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

                    if (creatingOrderModel.Products != null)
                    {
                        foreach (var crnt in creatingOrderModel.Products)
                        {
                            UpdateAmountProductOnStock(crnt.Count, crnt.Id, crnt.Name);
                            AddProductDto(creatingOrderModel.Order.Id, crnt.Id, crnt.Count);

                        }
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

            return true;
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

        private bool CheckAmountsListProducts(List<ProductCountModel> productsCounts)
        {
            if (productsCounts != null)
            {
                productsCounts = AggregateProductCountModels(productsCounts);

                foreach (var crnt in productsCounts)
                {
                    var getAmountProductOnStock = _productsReviewsAndStocksRepository.GetAmountByProductId(crnt.Id);
                    if (crnt.Count > getAmountProductOnStock.Amount)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private bool UpdateAmountProductOnStock(int amount, int productId, string productName)
        {
            int amountOnStock = _productsReviewsAndStocksRepository.GetAmountByProductId(productId).Amount;
            int updateAmount = amountOnStock - amount;
            StocksDtoWithProductName stockProduct = new StocksDtoWithProductName
            {
                Amount = updateAmount,
                ProductId = productId,
                Name = productName
            };
            return _productsReviewsAndStocksRepository.UpdateAmountOfStocks(stockProduct);
        }

        private List<ProductCountModel> AggregateProductCountModels(List<ProductCountModel> productCountModels)
        {
            var distinctProducts = productCountModels
                .GroupBy(p => p.Id)
                .Select(g =>
                {
                    var aggreagatedProductCountModel = new ProductCountModel
                    {
                        Id = g.Key,
                        Count = g.Sum(pr => pr.Count)
                    };

                    return aggreagatedProductCountModel;
                })
                .ToList();

            return distinctProducts;
        }
    }
}