using FluentAssertions;
using Moq;
using OfferAggregator.Bll.Models;
using OfferAggregator.Bll.Tests.TestCaseSource;
using OfferAggregator.Dal.Models;
using OfferAggregator.Dal.Repositories;
using System.Text.RegularExpressions;
using Microsoft.Data.SqlClient;

namespace OfferAggregator.Bll.Tests
{
    public class ProductServiceTests
    {
        private ProductService _productService;

        private Mock<IProductsRepository> _mockProductRepo;

        private Mock<IProductsReviewsAndStocksRepository> _mockProductReviewsAndStocksRepo;

        private Mock<ITagsRepository> _mockTagRepo;

        private Mock<IGroupRepository> _mockGroupRepo;

        private Mock<IClientRepository> _mockClientRepo;


        [SetUp]

        public void Setup()
        {
            _mockProductRepo = new Mock<IProductsRepository>();
            _mockProductReviewsAndStocksRepo = new Mock<IProductsReviewsAndStocksRepository>();
            _mockTagRepo = new Mock<ITagsRepository>();
            _mockGroupRepo = new Mock<IGroupRepository>();
            _mockClientRepo = new Mock<IClientRepository>();
            _productService = new ProductService(
                _mockProductRepo.Object,
                _mockProductReviewsAndStocksRepo.Object,
                _mockTagRepo.Object,
                _mockGroupRepo.Object,
                _mockClientRepo.Object);
        }

        [TestCaseSource(typeof(ProductServiceTestCaseSource), nameof(ProductServiceTestCaseSource.AddProductTestCaseSource))]
        public void AddProductTest(int groupId, GroupDto getGroup, ProductsDto addProduct, int result, ProductInputModel product, int expectedProductId)
        {
            _mockGroupRepo.Setup(g => g.GetGroupById(groupId)).Returns(getGroup).Verifiable();
            _mockProductRepo.Setup(p => p.AddProduct(It.Is<ProductsDto>(pr => pr.Equals(addProduct)))).Returns(result).Verifiable();

            int actualProductId = _productService.AddProduct(product);

            _mockGroupRepo.VerifyAll();
            _mockProductRepo.VerifyAll();

            Assert.AreEqual(expectedProductId, actualProductId);
        }

        [Test]
        public void AddProductTest_WhenGroupIsNotExist_ShouldArgumentException()
        {
            GroupDto getGroup = null;
            ProductsDto addProduct = new ProductsDto
            {
                Name = "one2",
                GroupId = 11,
                IsDeleted = false
            };
            ProductInputModel product = new ProductInputModel
            {
                Name = "one2",
                GroupId = 11,
                IsDeleted = false
            };

            _mockGroupRepo.Setup(g => g.GetGroupById(11)).Returns(getGroup).Verifiable();

            Assert.Throws<ArgumentException>(() => _productService.AddProduct(product));

            _mockGroupRepo.VerifyAll();
            _mockProductRepo.Verify(p => p.AddProduct(It.IsAny<ProductsDto>()), Times.Never);
        }

        [Test]
        public void AddProductTest_WhenProductNameIsNotUnique_ShouldException()
        {
            GroupDto getGroup = new GroupDto
            {
                Id = 102,
                Name = "group for two"
            };
            ProductsDto addProduct = new ProductsDto
            {
                Name = "two",
                GroupId = 102,
                IsDeleted = false
            };
            ProductInputModel product = new ProductInputModel
            {
                Name = "two",
                GroupId = 102,
                IsDeleted = false
            };

            _mockGroupRepo.Setup(g => g.GetGroupById(102)).Returns(getGroup).Verifiable();
            _mockProductRepo.Setup(p => p.AddProduct(It.Is<ProductsDto>(pr => pr.Name == addProduct.Name))).Throws<Exception>();

            Assert.Throws<Exception>(() => _productService.AddProduct(product));

            _mockGroupRepo.VerifyAll();
            _mockProductRepo.VerifyAll();

        }

        [TestCaseSource(typeof(ProductServiceTestCaseSource), nameof(ProductServiceTestCaseSource.GetAllProductsTestCaseSource))]
        public void GetAllProductsTest(List<ProductsDto> allProducts, List<ProductOutputModel> expectedProductModels)
        {
            _mockProductRepo.Setup(p => p.GetAllProducts()).Returns(allProducts).Verifiable();

            List<ProductOutputModel> actualProductModels = _productService.GetAllProducts();

            _mockProductRepo.VerifyAll();

            actualProductModels.Should().BeEquivalentTo(expectedProductModels);
        }

        [TestCaseSource(typeof(ProductServiceTestCaseSource), nameof(ProductServiceTestCaseSource.GetAllProductsByGroupIdTestCaseSource))]
        public void GetAllProductsByGroupIdTest(List<ProductsDto> allProducts, List<ProductOutputModel> expectedProductModels, int groupId)
        {
            _mockProductRepo.Setup(p => p.GetAllProductsByGroupId(groupId)).Returns(allProducts).Verifiable();

            List<ProductOutputModel> actualProductModels = _productService.GetAllProductsByGroupId(groupId);

            _mockProductRepo.VerifyAll();

            actualProductModels.Should().BeEquivalentTo(expectedProductModels);
        }


        [TestCaseSource(typeof(ProductServiceTestCaseSource), nameof(ProductServiceTestCaseSource.UpdateProductTestCaseSource))]
        public void UpdateProductTest(GroupDto getGroup, ProductsDto getProductDto, ProductsDto productDto, ProductInputModel product, bool expected, bool result)
        {
            _mockGroupRepo.Setup(g => g.GetGroupById(productDto.GroupId)).Returns(getGroup).Verifiable();
            _mockProductRepo.Setup(p => p.GetProductById(productDto.Id)).Returns(getProductDto).Verifiable();
            _mockProductRepo.Setup(p => p.UpdateProduct(It.Is<ProductsDto>(pr => pr.Equals(productDto)))).Returns(result).Verifiable();

            bool actual = _productService.UpdateProduct(product);

            _mockGroupRepo.VerifyAll();
            _mockProductRepo.VerifyAll();

            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(ProductServiceTestCaseSource), nameof(ProductServiceTestCaseSource.UpdateProductTest_WhenProductIsNotExistTestCaseSource))]
        public void UpdateProductTest_WhenProductIsNotExist(GroupDto getGroup, ProductsDto getProductDto, ProductsDto productDto, ProductInputModel product, bool expected)
        {
            _mockProductRepo.Setup(p => p.GetProductById(productDto.Id)).Returns(getProductDto).Verifiable();

            Assert.Throws<ArgumentException>(() => _productService.UpdateProduct(product));

            _mockGroupRepo.Verify(g => g.GetGroupById(It.IsAny<int>()), Times.Never);
            _mockProductRepo.VerifyAll();
            _mockProductRepo.Verify(p => p.UpdateProduct(It.IsAny<ProductsDto>()), Times.Never);
        }

        [TestCaseSource(typeof(ProductServiceTestCaseSource), nameof(ProductServiceTestCaseSource.UpdateProductTest_WhenProductIsDeletedTestCaseSource))]
        public void UpdateProductTest_WhenProductIsDeleted(GroupDto getGroup, ProductsDto getProductDto, ProductsDto productDto, ProductInputModel product, bool expected)
        {
            _mockProductRepo.Setup(p => p.GetProductById(productDto.Id)).Returns(getProductDto).Verifiable();

            Assert.Throws<ArgumentException>(() => _productService.UpdateProduct(product));

            _mockGroupRepo.Verify(g => g.GetGroupById(It.IsAny<int>()), Times.Never);
            _mockProductRepo.VerifyAll();
            _mockProductRepo.Verify(p => p.UpdateProduct(It.IsAny<ProductsDto>()), Times.Never);
        }

        [TestCaseSource(typeof(ProductServiceTestCaseSource), nameof(ProductServiceTestCaseSource.UpdateProductTest_WhenGroupIsNotExistTestCaseSource))]
        public void UpdateProductTest_WhenGroupIsNotExist(GroupDto getGroup, ProductsDto getProductDto, ProductsDto productDto, ProductInputModel product, bool expected)
        {
            _mockGroupRepo.Setup(g => g.GetGroupById(productDto.GroupId)).Returns(getGroup).Verifiable();
            _mockProductRepo.Setup(p => p.GetProductById(productDto.Id)).Returns(getProductDto).Verifiable();

            Assert.Throws<ArgumentException>(() => _productService.UpdateProduct(product));

            _mockGroupRepo.VerifyAll();
            _mockProductRepo.VerifyAll();
            _mockProductRepo.Verify(p => p.UpdateProduct(It.IsAny<ProductsDto>()), Times.Never);
        }

        [TestCaseSource(typeof(ProductServiceTestCaseSource), nameof(ProductServiceTestCaseSource.UpdateProductTest_WhenNameNotUnigue_ShouldExceptionTestCaseSource))]
        public void UpdateProductTest_WhenNameNotUnigue_ShouldException(GroupDto getGroup, ProductsDto getProductDto, ProductsDto productDto, ProductInputModel product, bool expected)
        {
            _mockGroupRepo.Setup(g => g.GetGroupById(productDto.GroupId)).Returns(getGroup).Verifiable();
            _mockProductRepo.Setup(p => p.GetProductById(productDto.Id)).Returns(getProductDto).Verifiable();
            _mockProductRepo.Setup(p => p.UpdateProduct(It.Is<ProductsDto>(pr => pr.Name == productDto.Name))).Throws<Exception>();

            Assert.Throws<Exception>(() => _productService.UpdateProduct(product));
            
            _mockGroupRepo.VerifyAll();
            _mockProductRepo.VerifyAll();
        }

        [TestCaseSource(typeof(ProductServiceTestCaseSource), nameof(ProductServiceTestCaseSource.DeleteProductTestCaseSource))]
        public void DeleteProductTest(int productId, bool boolProduct, bool boolReviewAndStock, bool boolTag, bool expected)
        {
            _mockProductRepo.Setup(p => p.DeleteProduct(productId)).Returns(boolProduct).Verifiable();
            _mockProductReviewsAndStocksRepo.Setup(rs => rs.DeleteProductReviewsByProductId(productId)).Returns(boolReviewAndStock).Verifiable();
            _mockTagRepo.Setup(t => t.DeleteTagProductByProductId(productId)).Returns(boolTag).Verifiable();

            bool actual = _productService.DeleteProduct(productId);

            _mockProductRepo.VerifyAll();
            _mockProductReviewsAndStocksRepo.VerifyAll();
            _mockTagRepo.VerifyAll();

            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(ProductServiceTestCaseSource), nameof(ProductServiceTestCaseSource.DeleteProductTest_WhenProductIdIsNotExistTestCaseSource))]
        public void DeleteProductTest_WhenProductIdIsNotExist(int productId, bool boolProduct, bool expected)
        {
            _mockProductRepo.Setup(p => p.DeleteProduct(productId)).Returns(boolProduct).Verifiable();

            bool actual = _productService.DeleteProduct(productId);

            _mockProductRepo.VerifyAll();
            _mockProductReviewsAndStocksRepo.Verify(rs => rs.DeleteProductReviewsByProductId(It.IsAny<int>()), Times.Never);
            _mockTagRepo.Verify(t => t.DeleteTagProductByProductId(It.IsAny<int>()), Times.Never);

            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(ProductServiceTestCaseSource), nameof(ProductServiceTestCaseSource.RegistrateProductInStockTest_WhenAddNewProductTestCaseSource))]
        public void RegistrateProductInStockTest_WhenAddNewProduct(StocksDtoWithProductName stockProductDto, ProductsDto getProductDto, StocksDtoWithProductName getAmountByProductId,
                                                  bool resultOfUpdate, bool expected, StocksWithProductInputModel stockProductModel)
        {
            _mockProductRepo.Setup(p => p.GetProductById(stockProductDto.ProductId)).Returns(getProductDto).Verifiable();
            _mockProductReviewsAndStocksRepo.Setup(rs => rs.GetAmountByProductId(stockProductDto.ProductId)).Returns(getAmountByProductId).Verifiable();
            _mockProductReviewsAndStocksRepo.Setup(rs => rs.UpdateAmountOfStocks(
                                                   It.Is<StocksDtoWithProductName>(sp => sp.Equals(stockProductDto))))
                                                   .Returns(resultOfUpdate).Verifiable();
            bool actual = _productService.RegistrateProductInStock(stockProductModel);

            _mockProductRepo.VerifyAll();
            _mockProductReviewsAndStocksRepo.VerifyAll();

            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(ProductServiceTestCaseSource), nameof(ProductServiceTestCaseSource.RegistrateProductInStockTest_WhenUpdateExistProductTestCaseSource))]
        public void RegistrateProductInStockTest_WhenUpdateExistProduct(StocksDtoWithProductName stockProductDto, ProductsDto getProductDto, StocksDtoWithProductName getAmountByProductId,
                                                  bool resultUpdate, bool expected, StocksWithProductInputModel stockProductModel, StocksDtoWithProductName stockUpdateProductDto)
        {
            _mockProductRepo.Setup(p => p.GetProductById(stockProductDto.ProductId)).Returns(getProductDto).Verifiable();
            _mockProductReviewsAndStocksRepo.Setup(rs => rs.GetAmountByProductId(stockProductDto.ProductId)).Returns(getAmountByProductId).Verifiable();
            _mockProductReviewsAndStocksRepo.Setup(rs => rs.UpdateAmountOfStocks(
                                                    It.Is<StocksDtoWithProductName>(sp => sp.Equals(stockUpdateProductDto))))
                                                   .Returns(resultUpdate).Verifiable();
            bool actual = _productService.RegistrateProductInStock(stockProductModel);

            _mockProductRepo.VerifyAll();
            _mockProductReviewsAndStocksRepo.VerifyAll();

            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(ProductServiceTestCaseSource), nameof(ProductServiceTestCaseSource.RegistrateProductInStockTest_WhenProductIsNotExistTestCaseSource))]
        public void RegistrateProductInStockTest_WhenProductIsNotExist(StocksDtoWithProductName stockProductDto, ProductsDto getProductDto,
                                                                       StocksWithProductInputModel stockProductModel, bool expected)
        {
            _mockProductRepo.Setup(p => p.GetProductById(stockProductDto.ProductId)).Returns(getProductDto).Verifiable();

            bool actual = _productService.RegistrateProductInStock(stockProductModel);

            _mockProductRepo.VerifyAll();
            _mockProductReviewsAndStocksRepo.Verify(rs => rs.GetAmountByProductId(It.IsAny<int>()), Times.Never);
            _mockProductReviewsAndStocksRepo.Verify(rs => rs.AddAmountToStocks(It.IsAny<StocksDtoWithProductName>()), Times.Never);
            _mockProductReviewsAndStocksRepo.Verify(rs => rs.UpdateAmountOfStocks(It.IsAny<StocksDtoWithProductName>()), Times.Never);
        }

        [TestCaseSource(typeof(ProductServiceTestCaseSource), nameof(ProductServiceTestCaseSource.RegistrateProductInStockTest_WhenAmountLessZeroTestCaseSource))]
        public void RegistrateProductInStockTest_WhenAmountLessZero(StocksDtoWithProductName stockProductDto, ProductsDto getProductDto,
                                                                       StocksWithProductInputModel stockProductModel, bool expected)
        {
            _mockProductRepo.Setup(p => p.GetProductById(stockProductDto.ProductId)).Returns(getProductDto).Verifiable();

            bool actual = _productService.RegistrateProductInStock(stockProductModel);

            _mockProductRepo.VerifyAll();
            _mockProductReviewsAndStocksRepo.Verify(rs => rs.GetAmountByProductId(It.IsAny<int>()), Times.Never);
            _mockProductReviewsAndStocksRepo.Verify(rs => rs.AddAmountToStocks(It.IsAny<StocksDtoWithProductName>()), Times.Never);
            _mockProductReviewsAndStocksRepo.Verify(rs => rs.UpdateAmountOfStocks(It.IsAny<StocksDtoWithProductName>()), Times.Never);
        }

        [TestCaseSource(typeof(ProductServiceTestCaseSource), nameof(ProductServiceTestCaseSource.RegistrateProductInStockTest_WhenProductIsDeletedTestCaseSource))]
        public void RegistrateProductInStockTest_WhenProductIsDeleted(
            StocksDtoWithProductName stockProductDto,
            ProductsDto getProductDto,
            StocksWithProductInputModel stockProductModel,
            bool expected)
        {
            _mockProductRepo.Setup(p => p.GetProductById(stockProductDto.ProductId)).Returns(getProductDto).Verifiable();

            bool actual = _productService.RegistrateProductInStock(stockProductModel);

            _mockProductRepo.VerifyAll();
            _mockProductReviewsAndStocksRepo.Verify(rs => rs.GetAmountByProductId(It.IsAny<int>()), Times.Never);
            _mockProductReviewsAndStocksRepo.Verify(rs => rs.AddAmountToStocks(It.IsAny<StocksDtoWithProductName>()), Times.Never);
            _mockProductReviewsAndStocksRepo.Verify(rs => rs.UpdateAmountOfStocks(It.IsAny<StocksDtoWithProductName>()), Times.Never);
        }

        [TestCaseSource(typeof(ProductServiceTestCaseSource), nameof(ProductServiceTestCaseSource.GetFullProductByIdTestCaseSource))]
        public void GetFullProductByIdTest(int productId, FullProductDto fullProductDto, FullProductOutputModel expectedFullProductModel)
        {
            _mockProductRepo.Setup(p => p.GetFullProductById(productId)).Returns(fullProductDto).Verifiable();

            FullProductOutputModel actualFullProductModel = _productService.GetFullProductById(productId);

            _mockProductRepo.VerifyAll();

            actualFullProductModel.Should().BeEquivalentTo(expectedFullProductModel);
        }

        [TestCaseSource(typeof(ProductServiceTestCaseSource), nameof(ProductServiceTestCaseSource.GetFullProducsTestCaseSource))]
        public void GetFullProducsTest(List<FullProductDto> fullProductDtos, List<FullProductOutputModel> expectedFullProductModels)
        {
            _mockProductRepo.Setup(p => p.GetFullProducts()).Returns(fullProductDtos).Verifiable();

            List<FullProductOutputModel> actualFullProductModels = _productService.GetFullProducts();

            _mockProductRepo.VerifyAll();

            actualFullProductModels.Should().BeEquivalentTo(expectedFullProductModels);
        }

        [TestCaseSource(typeof(ProductServiceTestCaseSource), nameof(ProductServiceTestCaseSource.GetProductsStatisticTestCaseSource))]
        public void GetProductsStatisticTest(List<ProductsStatisticDto> productsStatisticDtos, List<ProductsStatisticOutputModel> expectedProductsStaticModels)
        {
            _mockProductRepo.Setup(p => p.GetProductsStatistic()).Returns(productsStatisticDtos).Verifiable();

            List<ProductsStatisticOutputModel> actualProductsStaticModels = _productService.GetProductsStatistic();

            _mockProductRepo.VerifyAll();

            actualProductsStaticModels.Should().BeEquivalentTo(expectedProductsStaticModels);
        }
    }
}