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

            if (!CheckGroupIsExist(groupId))
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

        public bool UpdateProduct(ProductInputModel product)
        {
            var productDto = _instanceMapper.MapProductModelToProductsDto(product);
            var getProductDto = _productsRepository.GetProductById(productDto.Id);
            if (!CheckProductIsExist(productDto.Id))
            {
                throw new ArgumentException("ProductId is not exist");
            }

            else if (getProductDto.IsDeleted)
            {
                throw new ArgumentException("Product is deleted");
            }

            else if (!CheckGroupIsExist(productDto.GroupId))
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

                var sumAmount = getAmountByProductId.Amount + stockProductDto.Amount;
                stockProductDto.Amount = sumAmount;
                result = _productsReviewsAndStocksRepository.UpdateAmountOfStocks(stockProductDto);
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

        public List<ProductsStatisticOutputModel> GetProductsStatistic()
        {
            var getProductsStatisticDtos = _productsRepository.GetProductsStatistic();
            var getProductsStatisticModels = _instanceMapper.MapProductsStatisticDtosToProductsStatisticOutputModels(getProductsStatisticDtos);

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

        //public bool AddScoreOrCommentToProductReview(ProductReviewInputModel productReviewModel)
        //{
        //    if (productReviewModel.Score != null && (productReviewModel.Score < 1 || productReviewModel.Score > 5))
        //    {
        //        throw new ArgumentException("This score not included in the range from 1 to 5");
        //    }

        //    if (!CheckClientOrderedProduct(productReviewModel.ProductId, productReviewModel.ClientId))
        //    {
        //        throw new ArgumentException("Client did not order product with this product");
        //    }

        //    var productReviewDto = _instanceMapper.MapProductReviewInputModelToProductReviewsDto(productReviewModel);
        //    var result = _productsReviewsAndStocksRepository.AddScoreOrCommentToProductReview(productReviewDto);

        //    return result;
        //}

        public void AddScoreOrCommentToProductReview(ProductReviewInputModel productReviewModel)
        {
            if (productReviewModel.Score != null && (productReviewModel.Score < 1 || productReviewModel.Score > 5))
            {
                throw new ArgumentException("This score not included in the range from 1 to 5");
            }

            if (!CheckClientOrderedProduct(productReviewModel.ProductId, productReviewModel.ClientId))
            {
                throw new ArgumentException("Client did not order product with this product");
            }

            var productReviewDto = _instanceMapper.MapProductReviewInputModelToProductReviewsDto(productReviewModel);
            var getProductWithScoresAndComments = _productsReviewsAndStocksRepository.GetAllScoresAndCommentsForProductByProductIDAndClientId(productReviewModel.ProductId, productReviewModel.ClientId);

            //if (productReviewModel.Score != null && CheckProductDoesNotHaveScoreByProductIdAndClientId(getProductWithScoresAndComments))
            //{
            //    _productsReviewsAndStocksRepository.AddScoreToProductReview(productReviewDto);
            //}
            //else if (productReviewModel.Score != null && !CheckProductDoesNotHaveScoreByProductIdAndClientId(getProductWithScoresAndComments))
            //{
            //    _productsReviewsAndStocksRepository.UpdateScoreOfProductReview(productReviewDto);
            //}

            //if (productReviewModel.Comment!=null && CheckProductDoesNotHaveCommentByProductIdAndClientId(getProductWithScoresAndComments))
            //{
            //    _productsReviewsAndStocksRepository.AddCommentToProductReview(productReviewDto);
            //}
            //else if(productReviewModel.Comment != null && !CheckProductDoesNotHaveCommentByProductIdAndClientId(getProductWithScoresAndComments))
            //{
            //    _productsReviewsAndStocksRepository.UpdateCommentOfProductReview(productReviewDto);
            //}

            if (CheckProductDoesNotHaveScoreByProductIdAndClientId(getProductWithScoresAndComments))
            {
                if (productReviewModel.Score == null && productReviewModel.Comment != null)
                {
                    if (CheckProductDoesNotHaveCommentByProductIdAndClientId(getProductWithScoresAndComments))
                    {
                        _productsReviewsAndStocksRepository.AddCommentToProductReview(productReviewDto);
                    }
                    else
                    {
                        _productsReviewsAndStocksRepository.UpdateCommentOfProductReview(productReviewDto);
                    }
                }
                else if (productReviewModel.Score != null && productReviewModel.Comment != null)
                {
                    if (CheckProductDoesNotHaveCommentByProductIdAndClientId(getProductWithScoresAndComments))
                    {
                        //_productsReviewsAndStocksRepository.AddScoreToProductReview(productReviewDto);
                        //_productsReviewsAndStocksRepository.AddCommentToProductReview(productReviewDto);
                        _productsReviewsAndStocksRepository.AddScoreOrCommentToProductReview(productReviewDto);
                    }
                    else
                    {
                        _productsReviewsAndStocksRepository.AddScoreToProductReview(productReviewDto);
                        _productsReviewsAndStocksRepository.UpdateCommentOfProductReview(productReviewDto);
                    }
                }
                //else if (productReviewModel.Score == null && productReviewModel.Comment == null)
                //{
                //    if (CheckProductDoesNotHaveCommentByProductIdAndClientId(getProductWithScoresAndComments))
                //    {
                //        _productsReviewsAndStocksRepository.AddCommentToProductReview(productReviewDto);
                //    }
                //    else
                //    {
                //        _productsReviewsAndStocksRepository.UpdateCommentOfProductReview(productReviewDto);
                //    }
                //}
                else if (productReviewModel.Score != null && productReviewModel.Comment == null)
                {
                    _productsReviewsAndStocksRepository.AddScoreToProductReview(productReviewDto);
                }
            }
            else if (!CheckProductDoesNotHaveScoreByProductIdAndClientId(getProductWithScoresAndComments))
            //if (!CheckProductDoesNotHaveScoreByProductIdAndClientId(getProductWithScoresAndComments) && productReviewModel.Score != null && productReviewModel.Comment != null)
            {
                if (productReviewModel.Score == null && productReviewModel.Comment != null)
                {
                    if (CheckProductDoesNotHaveCommentByProductIdAndClientId(getProductWithScoresAndComments))
                    {
                        //_productsReviewsAndStocksRepository.AddCommentToProductReview(productReviewDto);
                        _productsReviewsAndStocksRepository.UpdateCommentOfProductReview(productReviewDto);

                    }
                    else
                    {
                        _productsReviewsAndStocksRepository.UpdateCommentOfProductReview(productReviewDto);
                    }
                }
                else if (productReviewModel.Score != null && productReviewModel.Comment != null)
                {
                    if (CheckProductDoesNotHaveCommentByProductIdAndClientId(getProductWithScoresAndComments))
                    {
                        _productsReviewsAndStocksRepository.UpdateScoreOfProductReview(productReviewDto);
                        _productsReviewsAndStocksRepository.AddCommentToProductReview(productReviewDto);
                    }
                    else
                    {
                        _productsReviewsAndStocksRepository.UpdateScoreOfProductReview(productReviewDto);
                        _productsReviewsAndStocksRepository.UpdateCommentOfProductReview(productReviewDto);
                    }
                }
                else if (productReviewModel.Score != null && productReviewModel.Comment == null)
                {
                    _productsReviewsAndStocksRepository.UpdateScoreOfProductReview(productReviewDto);
                }
            }

            else if (CheckProductDoesNotHaveCommentByProductIdAndClientId(getProductWithScoresAndComments))
            {
                if (productReviewModel.Comment == null && productReviewModel.Score != null)
                {
                    if (CheckProductDoesNotHaveScoreByProductIdAndClientId(getProductWithScoresAndComments))
                    {
                        _productsReviewsAndStocksRepository.AddScoreToProductReview(productReviewDto);
                    }
                    else
                    {
                        _productsReviewsAndStocksRepository.UpdateScoreOfProductReview(productReviewDto);
                    }
                }
                else if (productReviewModel.Comment != null && productReviewModel.Score != null)
                {
                    if (CheckProductDoesNotHaveScoreByProductIdAndClientId(getProductWithScoresAndComments))
                    {
                        _productsReviewsAndStocksRepository.AddCommentToProductReview(productReviewDto);
                        _productsReviewsAndStocksRepository.AddScoreToProductReview(productReviewDto);
                    }
                    else
                    {
                        _productsReviewsAndStocksRepository.AddCommentToProductReview(productReviewDto);
                        _productsReviewsAndStocksRepository.UpdateScoreOfProductReview(productReviewDto);
                    }
                }
                else if (productReviewModel.Comment != null && productReviewModel.Score == null)
                {
                    _productsReviewsAndStocksRepository.AddCommentToProductReview(productReviewDto);
                }
            }

            else if (!CheckProductDoesNotHaveCommentByProductIdAndClientId(getProductWithScoresAndComments))
            {
                if (productReviewModel.Comment == null && productReviewModel.Score != null)
                {
                    if (CheckProductDoesNotHaveScoreByProductIdAndClientId(getProductWithScoresAndComments))
                    {
                        _productsReviewsAndStocksRepository.AddScoreToProductReview(productReviewDto);
                    }
                    else
                    {
                        _productsReviewsAndStocksRepository.UpdateScoreOfProductReview(productReviewDto);
                    }
                }
                else if (productReviewModel.Comment != null && productReviewModel.Score != null)
                {
                    if (CheckProductDoesNotHaveScoreByProductIdAndClientId(getProductWithScoresAndComments))
                    {
                        _productsReviewsAndStocksRepository.UpdateCommentOfProductReview(productReviewDto);
                        _productsReviewsAndStocksRepository.AddScoreToProductReview(productReviewDto);
                    }
                    else
                    {
                        _productsReviewsAndStocksRepository.UpdateCommentOfProductReview(productReviewDto);
                        _productsReviewsAndStocksRepository.UpdateScoreOfProductReview(productReviewDto);
                    }
                }
                else if (productReviewModel.Comment != null && productReviewModel.Score == null)
                {
                    _productsReviewsAndStocksRepository.UpdateCommentOfProductReview(productReviewDto);
                }
            }
        }

                public ProductsStatisticOutputModel GetProductStatisticById(int productId)
        {
            if (!CheckProductIsExist(productId))
            {
                throw new ArgumentException($"Product with productId {productId} is not exist");
            }

            var getProductStatisticDto = _productsRepository.GetProductStatisticById(productId);
            var getProductStatisticModel = _instanceMapper.MapProductStatisticDtoToProductStatisticOutputModel(getProductStatisticDto);

            return getProductStatisticModel;
        }

        public ProductWithScoresAndCommentsOutputModel GetAllScoresAndCommentsForProductByProductId(int productId)
        {
            if (!CheckProductIsExist(productId))
            {
                throw new ArgumentException($"Product with productId {productId} is not exist");
            }

            var productScoresCommentsDto = _productsReviewsAndStocksRepository.GetAllScoresAndCommentsForProductByProductId(productId);
            var productScoresCommentsOutputModel = _instanceMapper.MapProductWithScoresAndCommentsDtoToProductWithScoresAndCommentsOutputModel(productScoresCommentsDto);

            return productScoresCommentsOutputModel;
        }

        public ProductWithScoresAndCommentsOutputModel GetAllScoresAndCommentsForProductByProductIdAndClientId(int productId, int clientId)
        {
            if (!CheckProductIsExist(productId))
            {
                throw new ArgumentException("Product is not exist");
            }

            if (!CheckClientIsExist(clientId))
            {
                throw new ArgumentException("Client is not exist");
            }

            if (!CheckClientOrderedProduct(productId, clientId))
            {
                throw new ArgumentException("Client not ordered this product");
            }

            var productScoresCommentsDto = _productsReviewsAndStocksRepository.GetAllScoresAndCommentsForProductByProductIDAndClientId(productId, clientId);
            var productScoresCommentsOutputModel = _instanceMapper.MapProductWithScoresAndCommentsDtoToProductWithScoresAndCommentsOutputModel(productScoresCommentsDto);

            return productScoresCommentsOutputModel;
        }

        public bool UpdateScoreAndCommentOfProductReview(ProductReviewInputModel productReviewModel)
        {
            if (!CheckProductIsExist(productReviewModel.ProductId))
            {
                throw new ArgumentException("Product is not exist");
            }

            if (!CheckClientIsExist(productReviewModel.ClientId))
            {
                throw new ArgumentException("Client is not exist");
            }

            if (!CheckClientOrderedProduct(productReviewModel.ProductId, productReviewModel.ClientId))
            {
                throw new ArgumentException("Client not ordered this product");
            }

            if (productReviewModel.Score != null
                && (productReviewModel.Score < 1 || productReviewModel.Score > 5))
            {
                throw new ArgumentException("This score not included in the range from 1 to 5");
            }

            var productReviewDto = _instanceMapper.MapProductReviewInputModelToProductReviewsDto(productReviewModel);
            var result = _productsReviewsAndStocksRepository.UpdateScoreAndCommentOfProductsReviews(productReviewDto);

            return result;
        }

        private bool CheckClientOrderedProduct(int productId, int clientId)
        {
            if (!CheckProductIsExist(productId))
            {
                throw new Exception();
            }

            var clientsList = _clientRepository.GetClientsWhoOrderedProductByProductId(productId).Clients;

            return clientsList.Any(c => c.Id == clientId);
        }

        private bool CheckProductIsExist(int productId)
        {
            var getProduct = _productsRepository.GetProductById(productId);

            if (getProduct != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool CheckGroupIsExist(int groupId)
        {
            var getGroup = _groupRepository.GetGroupById(groupId);

            if (getGroup != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool CheckClientIsExist(int clientId)
        {
            var getClient = _clientRepository.GetClientById(clientId);

            if (getClient != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool CheckProductDoesNotHaveScoreByProductIdAndClientId(ProductWithScoresAndCommentsDto getProductWithScoresAndComments)
        {
            //var getProductWithScoresAndComments = _productsReviewsAndStocksRepository.GetAllScoresAndCommentsForProductByProductIDAndClientId(productId, clientId);
            if (getProductWithScoresAndComments != null && getProductWithScoresAndComments.ProductReviews != null)
            {
                var scoresAndComments = getProductWithScoresAndComments.ProductReviews;
                if (!scoresAndComments.Any() || scoresAndComments.Any(s => s.Score is null))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private bool CheckProductDoesNotHaveCommentByProductIdAndClientId(ProductWithScoresAndCommentsDto getProductWithScoresAndComments)
        {
            //var getProductWithScoresAndComments = _productsReviewsAndStocksRepository.GetAllScoresAndCommentsForProductByProductIDAndClientId(productId, clientId);
            if (getProductWithScoresAndComments != null && getProductWithScoresAndComments.ProductReviews != null)
            {
                var scoresAndComments = getProductWithScoresAndComments.ProductReviews;
                if (!scoresAndComments.Any() || scoresAndComments.Any(c => c.Comment is null))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}

