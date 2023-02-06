using OfferAggregator.Dal.Models;

namespace OfferAggregator.Dal.Repositories
{
    public interface IProductsRepository
    {
        public int AddProduct(ProductsDto product);

        public int DeleteProduct(int id);

        public List<ProductsDto> GetAllProducts();

        public List<ProductsDto> GetAllProductsByGroupId(int groupId);

        public int UpdateProduct(ProductsDto product);
    }
}