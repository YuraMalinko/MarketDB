using OfferAggregator.Dal.Models;

namespace OfferAggregator.Dal.Repositories
{
    public interface ITagsRepository
    {
        public int AddTag(TagDto tag);

        public bool AddTagProduct(TagProductDto tagProduct);

        public bool DeleteTag(int id);

        public List<TagDto> GetAllTags();

        public List<TagDto> GetAllTagsByProductId(int productId);

        public bool UpdateTag(TagDto tag);

        public bool DeleteTagProduct(TagProductDto tagProduct);

        public bool DeleteTagProductByProductId(int productId);

        public bool DeleteTagByProductIdAndTagId(int productId, int tagId);

        public TagDto GetTagById(int tagId);
    }
}