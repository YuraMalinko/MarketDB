using AutoMapper;
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

        public ProductService(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public int AddProduct(ProductModel product)
        {
            int result = -1;
            try
            {
                var addProduct = _instanceMapper.MapProductModelToProductsDto(product);
                result = _productsRepository.AddProduct(addProduct);
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
    }
}

//public List<ProductsDto> GetAllProducts()
//{
//    using (var sqlCnctn = new SqlConnection(Options.ConnectionString))
//    {
//        sqlCnctn.Open();
//        return sqlCnctn.Query<ProductsDto>(
//            StoredProcedures.GetAllProducts,
//            commandType: CommandType.StoredProcedure).ToList();
//    }
//}