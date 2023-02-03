using OfferAggregator.Dal.Models;

namespace OfferAggregator.Dal.Repositories
{
    public interface IProductsRepository
    {
        int AddProduct(ProductsDto product);

        int DeleteProduct(int id);

        List<ProductsDto> GetAllProducts();

        List<ProductsDto> GetAllProductsByGroupId(int groupId);

        int UpdateProduct(ProductsDto product);
    }
}