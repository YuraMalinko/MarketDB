using OfferAggregator.Dal.Models;

namespace OfferAggregator.Bll.Models
{
    public class FullProductModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int GroupId { get; set; }

        public string GroupName { get; set; }

        public int Amount { get; set; }

        public float? AverageScore { get; set; }

        public List<TagModel> Tags { get; set; }
    }
}