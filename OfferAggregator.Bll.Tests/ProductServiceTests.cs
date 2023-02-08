using OfferAggregator.Bll.Models;
using OfferAggregator.Bll.Tests.TestCaseSource;
using OfferAggregator.Dal.Models;
using FluentAssertions;
using Moq;
using OfferAggregator.Dal.Repositories;
using System.Text.RegularExpressions;

namespace OfferAggregator.Bll.Tests
{
    public class ProductServiceTests
    {
        private ProductService _productService;

        private Mock<IProductsRepository> _mockProductRepo;

        private Mock<IProductsReviewsAndStocksRepository> _mockProductReviewsAndStocksRepo;

        private Mock<ITagsRepository> _mockTagRepo;

        private Mock<IGroupRepository> _mockGroupRepo;


        [SetUp]

        public void Setup()
        {
            _mockProductRepo = new Mock<IProductsRepository>();
            _mockProductReviewsAndStocksRepo = new Mock<IProductsReviewsAndStocksRepository>();
            _mockTagRepo = new Mock<ITagsRepository>();
            _mockGroupRepo = new Mock<IGroupRepository>();
            _productService = new ProductService(
                _mockProductRepo.Object,
                _mockProductReviewsAndStocksRepo.Object,
                _mockTagRepo.Object,
                _mockGroupRepo.Object);
        }

        [TestCaseSource(typeof(ProductServiceTestCaseSource), nameof(ProductServiceTestCaseSource.AddProductTestCaseSource))]

        public void AddProductTest(int groupId, GroupDto getGroup, ProductsDto addProduct, int result, ProductModel product, int expectedProductId)
        {
            _mockGroupRepo.Setup(g => g.GetGroupById(groupId)).Returns(getGroup).Verifiable();
            _mockProductRepo.Setup(p => p.AddProduct(It.Is<ProductsDto>(pr => pr.Equals(addProduct)))).Returns(result).Verifiable();

            int actualProductId = _productService.AddProduct(product);

            _mockGroupRepo.VerifyAll();
            _mockProductRepo.VerifyAll();

            Assert.AreEqual(expectedProductId, actualProductId);
        }

        [Test]
        public void AddProductTest_WhenGroupIsNotExist_ShouldException()
        {
            GroupDto getGroup = null;
            ProductsDto addProduct = new ProductsDto
            {
                Name = "one2",
                GroupId = 11,
                IsDeleted = false
            };
            ProductModel product = new ProductModel
            {
                Name = "one2",
                GroupId = 11,
                IsDeleted = false
            };
            int expectedProductId = -1;

            _mockGroupRepo.Setup(g => g.GetGroupById(11)).Returns(getGroup).Verifiable();
            
            int actualProductId = _productService.AddProduct(product);

            _mockGroupRepo.VerifyAll();
            _mockProductRepo.Verify(p => p.AddProduct(It.IsAny<ProductsDto>()), Times.Never);

            Assert.AreEqual(expectedProductId, actualProductId);
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
            ProductModel product = new ProductModel
            {
                Name = "two",
                GroupId = 102,
                IsDeleted = false
            };
            int expectedProductId = -1;

            _mockGroupRepo.Setup(g => g.GetGroupById(102)).Returns(getGroup).Verifiable();
            _mockProductRepo.Setup(p => p.AddProduct(It.Is<ProductsDto>(pr => pr.Name == addProduct.Name))).Throws<Exception>();

            int actualProductId = _productService.AddProduct(product);

            _mockGroupRepo.VerifyAll();
            _mockProductRepo.VerifyAll();

            Assert.AreEqual(expectedProductId, actualProductId);
        }

        [TestCaseSource(typeof(ProductServiceTestCaseSource), nameof(ProductServiceTestCaseSource.GetAllProductsTestCaseSource))]
        public void GetAllProductsTest(List<ProductsDto> allProducts, List<ProductModel> expectedProductModels)
        {
            _mockProductRepo.Setup(p => p.GetAllProducts()).Returns(allProducts).Verifiable();

            List<ProductModel> actualProductModels = _productService.GetAllProducts();

            _mockProductRepo.VerifyAll();

            actualProductModels.Should().BeEquivalentTo(expectedProductModels);
        }

        [TestCaseSource(typeof(ProductServiceTestCaseSource), nameof(ProductServiceTestCaseSource.GetAllProductsByGroupIdTestCaseSource))]
        public void GetAllProductsByGroupIdTest(List<ProductsDto> allProducts, List<ProductModel> expectedProductModels, int groupId)
        {
            _mockProductRepo.Setup(p => p.GetAllProductsByGroupId(groupId)).Returns(allProducts).Verifiable();

            List<ProductModel> actualProductModels = _productService.GetAllProductsByGroupId(groupId);

            _mockProductRepo.VerifyAll();

            actualProductModels.Should().BeEquivalentTo(expectedProductModels);
        }
    }
}

