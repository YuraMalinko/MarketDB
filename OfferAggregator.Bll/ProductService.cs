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

        private IGroupRepository _groupRepository;

        public ProductService(IProductsRepository productsRepository, IProductsReviewsAndStocksRepository productsReviewsAndStocksRepository,
                              ITagsRepository tagsRepository, IGroupRepository groupRepository)
        {
            _productsRepository = productsRepository;
            _productsReviewsAndStocksRepository = productsReviewsAndStocksRepository;
            _tagsRepository = tagsRepository;
            _groupRepository = groupRepository;
        }

        public int AddProduct(ProductInputModel product)
        {
            var addProduct = _instanceMapper.MapProductModelToProductsDto(product);
            var groupId = addProduct.GroupId;
            var getGroup = _groupRepository.GetGroupById(groupId);
            if (getGroup == null)
            {
                throw new ArgumentException($"GroupId {groupId} is not exist");
            }

            return _productsRepository.AddProduct(addProduct);
        }

        public List<ProductOutputModel> GetAllProducts()
        {
            List<ProductsDto> allProducts = _productsRepository.GetAllProducts();
            var result = _instanceMapper.MapProductsDtosToProductOutputModels(allProducts);

            return result;
        }

        public List<ProductOutputModel> GetAllProductsByGroupId(int groupId)
        {
            List<ProductsDto> allProducts = _productsRepository.GetAllProductsByGroupId(groupId);
            var result = _instanceMapper.MapProductsDtosToProductOutputModels(allProducts);

            return result;
        }

        public bool UpdateProduct(ProductInputModel product)
        {
            bool result;
            try
            {
                var productDto = _instanceMapper.MapProductModelToProductsDto(product);
                var getGroup = _groupRepository.GetGroupById(productDto.GroupId);
                var getProductDto = _productsRepository.GetProductById(productDto.Id);
                if (getProductDto != null && !getProductDto.IsDeleted && getGroup != null)
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
                _productsReviewsAndStocksRepository.DeleteProductReviewsByProductId(productId);
                _tagsRepository.DeleteTagProductByProductId(productId);
            }

            return result;
        }

        public bool RegistrateProductInStock(StocksWithProductInputModel stockProduct)
        {
            var stockProductDto = _instanceMapper.MapStocksWithProductModelToStocksWithProductModel(stockProduct);
            var getProductDto = _productsRepository.GetProductById(stockProductDto.ProductId);
            bool result = false;
            if (getProductDto != null && stockProductDto.Amount > 0 && !getProductDto.IsDeleted)
            {
                var getAmountByProductId = _productsReviewsAndStocksRepository.GetAmountByProductId(stockProductDto.ProductId);

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
            }
            return result;
        }

        public FullProductModel GetFullProductById(int productId)
        {
            var fullProductDto = _productsRepository.GetFullProductById(productId);
            var fullProductModel = _instanceMapper.MapFullProductDtoToFullProductModel(fullProductDto);

            return fullProductModel;
        }

        public List<FullProductModel> GetFullProducts()
        {
            var fullProductDtos = _productsRepository.GetFullProducts();
            var fullProductModels = _instanceMapper.MapFullProductDtosToFullProductModels(fullProductDtos);

            return fullProductModels;
        }

        public List<ProductsStatisticModel> GetProductsStatistic()
        {
            var getProductsStatisticDtos = _productsRepository.GetProductsStatistic();
            var getProductsStatisticModels = _instanceMapper.MapProductsStatisticDtosToProductsStatisticModels(getProductsStatisticDtos);

            return getProductsStatisticModels;
        }

        public List<GroupModel> GetAllGroups()
        {
            var getAllGroupsDtos = _groupRepository.GetAllGroups();
            var result = _instanceMapper.MapGroupDtosToGroupModels(getAllGroupsDtos);

            return result;
        }

        public ProductOutputModel GetProductById(int productId)
        {
            var productDto = _productsRepository.GetProductById(productId);
            var productModel = _instanceMapper.MapProductDtoToProductOutputModel(productDto);

            return productModel;
        }
    }
}

