using OfferAggregator.Dal.Models;

namespace OfferAggregator.Dal.Repositories
{
    public interface IProductsRepository
    {
        public int AddProduct(ProductsDto product);

        public bool DeleteProduct(int id);

        public List<ProductsDto> GetAllProducts();

        public List<ProductsDto> GetAllProductsByGroupId(int groupId);

        public bool UpdateProduct(ProductsDto product);

        public ProductsDto GetProductById(int id);

        public FullProductDto GetFullProductById(int id);

        public List<FullProductDto> GetFullProducts();

        public List<ProductsStatisticDto> GetProductsStatistic();
    }
}