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


        private IProductsReviewsAndStocksRepository _productsReviewsAndStocksRepository;


        private ITagsRepository _tagsRepository;

        public ProductService(IProductsRepository productsRepository, IProductsReviewsAndStocksRepository productsReviewsAndStocksRepository, ITagsRepository tagsRepository)
        {
            _productsRepository = productsRepository;
            _productsReviewsAndStocksRepository = productsReviewsAndStocksRepository;
            _tagsRepository = tagsRepository;
        }

        public int AddProduct(ProductModel product)
        {
            int result = -1;
            try
            {
                //Добавить проверку по ГроупАйди
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
                result = _productsRepository.UpdateProduct(productDto);
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

        public bool RegistrateProductInStock(StocksWithProductModel stockProduct)
        {
            var stockProductDto = _instanceMapper.MapStocksWithProductModelToStocksDtoWithProductName(stockProduct);
            var getAmountByProductId = _productsReviewsAndStocksRepository.GetAmountByProductId(stockProductDto.ProductId);
            bool result;

            if (getAmountByProductId is null)
            {
                result = _productsReviewsAndStocksRepository.AddAmountToStocks(stockProductDto);
            }
            else
            {
                var sumAmount = getAmountByProductId.Amount + stockProductDto.Amount;
                stockProductDto.Amount = sumAmount;
                result = _productsReviewsAndStocksRepository.UpdateAmountOfStocks(stockProductDto);
            }

            return result;
        }

        public StocksWithProductModel GetAmountByProductId(int productId)
        {
            var amountDto = _productsReviewsAndStocksRepository.GetAmountByProductId(productId);
            var result = _instanceMapper.MapStocksDtoWithProductNameToStocksWithProductModel(amountDto);

            return result;
        }

        public List<StocksWithProductModel> GetAmountsOfAllProducts()
        {
            var amountDto = _productsReviewsAndStocksRepository.GetAmountsOfAllProducts();
            var result = _instanceMapper.MapStocksDtosWithProducrNameToStocksWithProductModels(amountDto);

            return result;
        }

        public bool UpdateAmountOfStocks(StocksWithProductModel stockModel)
        {
            var stockDto = _instanceMapper.MapStocksWithProductModelToStocksDtoWithProductName(stockModel);
            var result = _productsReviewsAndStocksRepository.UpdateAmountOfStocks(stockDto);

            return result;
        }
    }
}

