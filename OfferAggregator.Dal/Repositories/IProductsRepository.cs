using OfferAggregator.Dal.Models;

namespace OfferAggregator.Dal.Repositories
{
    public interface IProductsRepository
    {
        int AddProduct(ProductsDto product);
        bool DeleteProduct(int id);
        List<ProductsDto> GetAllProducts();
        List<ProductsDto> GetAllProductsByGroupId(int groupId);
        bool UpdateProduct(ProductsDto product);
    }
}