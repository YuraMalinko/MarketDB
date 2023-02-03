using AutoMapper;
using Microsoft.Data.SqlClient;
using OfferAggregator.Bll;
using OfferAggregator.Bll.Models;
using OfferAggregator.Dal.Models;
using OfferAggregator.Dal;
using System.Data;
using OfferAggregator.Dal.Repositories;

namespace OfferAggregator.Bll
{
    public class ProductMapper
    {
        private Mapper _instanceMapper = Mapper.GetInstance();

        public int AddProduct(ProductModel product)
        {
            ProductsRepository productsRepository = new ProductsRepository();
            var addProduct = _instanceMapper.MapProductModelToProductsDto(product);
            int result = productsRepository.AddProduct(addProduct);

            return result;
        }

    }
}