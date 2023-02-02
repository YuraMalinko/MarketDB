using OfferAggregator.Dal.Models;

namespace OfferAggregator.Dal.Repositories
{
    public interface ITagsRepository
    {
        int AddTag(string name);
        bool AddTagProduct(TagProductDto tagProduct);
        bool DeleteTag(int id);
        List<TagDto> GetAllTags();
        List<TagDto> GetAllTagsByProductId(int productId);
        bool UpdateTagName(TagDto tag);
    }
}