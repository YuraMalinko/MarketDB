namespace OfferAggregator.Dal.Models
{
    public class ComboTagGroupDto
    {
        public double? AvgScore { get; set; }

        public int CountProducts { get; set; }

        public int CountOrders { get; set; }

        public bool? IsLiked { get; set; }

        public GroupDto? Group { get; set; }

        public TagDto? Tag { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is ComboTagGroupDto tg &&
                AvgScore == tg.AvgScore &&
                CountProducts == tg.CountProducts &&
                CountOrders == tg.CountOrders &&
                IsLiked == tg.IsLiked &&
                Group == tg.Group &&
                Tag == tg.Tag;
        }
    }
}
