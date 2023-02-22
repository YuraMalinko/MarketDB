using AutoMapper;
using Microsoft.Data.SqlClient;
using OfferAggregator.Bll;
using OfferAggregator.Bll.Models;
using OfferAggregator.Dal.Models;
using OfferAggregator.Dal;
using System.Data;
using OfferAggregator.Dal.Repositories;
using Dapper;
using System.Text.RegularExpressions;
using System.Linq;

namespace OfferAggregator.Bll
{
    public class ProductService
    {
        private Mapper _instanceMapper = Mapper.GetInstance();

        private IProductsRepository _productsRepository;

        private IProductsReviewsAndStocksRepository _productsReviewsAndStocksRepository;

        private ITagsRepository _tagsRepository;

        private IGroupRepository _groupRepository;

        private IClientRepository _clientRepository;

        public ProductService(IProductsRepository productsRepository, IProductsReviewsAndStocksRepository productsReviewsAndStocksRepository,
                              ITagsRepository tagsRepository, IGroupRepository groupRepository, IClientRepository clientRepository)
        {
            _productsRepository = productsRepository;
            _productsReviewsAndStocksRepository = productsReviewsAndStocksRepository;
            _tagsRepository = tagsRepository;
            _groupRepository = groupRepository;
            _clientRepository = clientRepository;
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

            var productId = _productsRepository.AddProduct(addProduct);
            _productsReviewsAndStocksRepository.AddAmountToStocks(
                new()
                {
                    Amount = 0,
                    ProductId = productId
                });

            return productId;
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

        //public bool UpdateProduct(ProductInputModel product)
        //{
        //    bool result;
        //    try
        //    {
        //        var productDto = _instanceMapper.MapProductModelToProductsDto(product);
        //        var getGroup = _groupRepository.GetGroupById(productDto.GroupId);
        //        var getProductDto = _productsRepository.GetProductById(productDto.Id);
        //        if (getProductDto != null && !getProductDto.IsDeleted && getGroup != null)
        //        {
        //            result = _productsRepository.UpdateProduct(productDto);
        //        }
        //        else
        //        {
        //            return false;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }

        //    return result;
        //}

        public bool UpdateProduct(ProductInputModel product)
        {
            var productDto = _instanceMapper.MapProductModelToProductsDto(product);
            var getGroup = _groupRepository.GetGroupById(productDto.GroupId);
            var getProductDto = _productsRepository.GetProductById(productDto.Id);
            if (getProductDto == null)
            {
                throw new ArgumentException("ProductId is not exist");
            }

            else if (getProductDto.IsDeleted)
            {
                throw new ArgumentException("Product is deleted");
            }

            else if (getGroup == null)
            {
                throw new ArgumentException("GroupId is not exist");
            }

            else
            {
                return _productsRepository.UpdateProduct(productDto);
            }
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
            var stockProductDto = _instanceMapper.MapStocksWithProductInputModelToStocksDtoWithProductName(stockProduct);
            var getProductDto = _productsRepository.GetProductById(stockProductDto.ProductId);
            bool result = false;
            if (getProductDto != null && stockProductDto.Amount > 0 && !getProductDto.IsDeleted)
            {
                var getAmountByProductId = _productsReviewsAndStocksRepository.GetAmountByProductId(stockProductDto.ProductId);

                //if (getAmountByProductId is null)
                //{
                //    result = _productsReviewsAndStocksRepository.AddAmountToStocks(stockProductDto);
                //}
                //else
                //{
                    var sumAmount = getAmountByProductId.Amount + stockProductDto.Amount;
                    stockProductDto.Amount = sumAmount;
                    result = _productsReviewsAndStocksRepository.UpdateAmountOfStocks(stockProductDto);
                //}
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

        public bool UpdateAmountInStock(StocksWithProductInputModel stockProductInModel)
        {
            var stockProductDto = _instanceMapper.MapStocksWithProductInputModelToStocksDtoWithProductName(stockProductInModel);
            var result = _productsReviewsAndStocksRepository.UpdateAmountOfStocks(stockProductDto);

            return result;
        }

        public StocksWithProductOutputModel GetAmountByProductId(int productId)
        {
            var getAmountDto = _productsReviewsAndStocksRepository.GetAmountByProductId(productId);
            var getAmountModel = _instanceMapper.MapStocksDtoWithProductNameToStocksWithProductOutputModel(getAmountDto);

            return getAmountModel;
        }

        public bool AddScoreOrCommentToProductReview(ProductReviewInputModel productReviewModel)
        {
            if (productReviewModel.Score !=null && (productReviewModel.Score<1 || productReviewModel.Score>5))
            {
                throw new ArgumentException("This score not included in the range from 1 to 5");
            }

            if (!CheckClientOrderedProduct(productReviewModel.ProductId, productReviewModel.ClientId))
            {
                throw new ArgumentException("Client did not order product with this product");
            }

            var productReviewDto = _instanceMapper.MapProductReviewInputModelToProductReviewsDto(productReviewModel);
            var result = _productsReviewsAndStocksRepository.AddScoreOrCommentToProductReview(productReviewDto);

            return result;
        }

        private bool CheckClientOrderedProduct(int productId, int clientId)
        {
            var getProductDto = _productsRepository.GetProductById(productId);

            if (getProductDto == null)
            {
                throw new Exception();
            }

            var clientsList = _clientRepository.GetClientsWhoOrderedProductByProductId(productId).Clients;
            
            return clientsList.Any(c => c.Id == clientId);
        }
    }
}

