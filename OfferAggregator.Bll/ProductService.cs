﻿using AutoMapper;
using Microsoft.Data.SqlClient;
using OfferAggregator.Bll;
using OfferAggregator.Bll.Models;
using OfferAggregator.Dal.Models;
using OfferAggregator.Dal;
using System.Data;
using OfferAggregator.Dal.Repositories;
using Dapper;

namespace OfferAggregator.Bll
{
    public class ProductService
    {
        private Mapper _instanceMapper = Mapper.GetInstance();


        private IProductsRepository _productsRepository;


        private IProductsReviewsAndStocksRepository _productsReviewsAndStocksRepository;


        private ITagsRepository _tagsRepository;


        private IGroupRepository _groupRepository;

        public ProductService(IProductsRepository productsRepository, IProductsReviewsAndStocksRepository productsReviewsAndStocksRepository, ITagsRepository tagsRepository, IGroupRepository groupRepository)
        {
            _productsRepository = productsRepository;
            _productsReviewsAndStocksRepository = productsReviewsAndStocksRepository;
            _tagsRepository = tagsRepository;
            _groupRepository = groupRepository;
        }

        public int AddProduct(ProductModel product)
        {
            int result = -1;
            try
            {
                var addProduct = _instanceMapper.MapProductModelToProductsDto(product);
                var groupId = addProduct.GroupId;
                var getGroup = _groupRepository.GetGroupById(groupId);
                if (getGroup != null)
                {
                    result = _productsRepository.AddProduct(addProduct);
                }
            }
            catch (Exception ex)
            {
                return result;
            }
            return result;
        }

        public List<ProductModel> GetAllProducts()
        {
            List<ProductsDto> allProducts = _productsRepository.GetAllProducts();
            var result = _instanceMapper.MapProductsDtosToProductModels(allProducts);

            return result;
        }

        public List<ProductModel> GetAllProductsByGroupId(int groupId)
        {
            List<ProductsDto> allProducts = _productsRepository.GetAllProductsByGroupId(groupId);
            var result = _instanceMapper.MapProductsDtosToProductModels(allProducts);

            return result;
        }

        public bool UpdateProduct(ProductModel product)
        {
            bool result;
            try
            {
                var productDto = _instanceMapper.MapProductModelToProductsDto(product);
                var getGroup = _groupRepository.GetGroupById(productDto.GroupId);
                var getProductDto = _productsRepository.GetProductById(productDto.Id);
                if (getProductDto != null && getProductDto.IsDeleted == false && getGroup != null)
                {
                    result = _productsRepository.UpdateProduct(productDto);
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                return false;
            }

            return result;
        }

        public bool DeleteProduct(int productId)
        {
            var result = _productsRepository.DeleteProduct(productId);

            if (result)
            {
                _productsReviewsAndStocksRepository.DeleteProductReviewByProductId(productId);
                _tagsRepository.DeleteTagProductByProductId(productId);
            }

            return result;
        }
    }
}
