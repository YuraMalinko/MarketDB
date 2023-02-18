namespace OfferAggregator.Dal.Models
{
    public class FullProductDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int GroupId { get; set; }

        public string GroupName { get; set; }

        public int Amount { get; set; }

        public List<TagDto> Tags { get; set; }

        public float? AverageScore { get; set; }
    }
}
