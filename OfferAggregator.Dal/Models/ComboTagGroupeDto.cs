namespace OfferAggregator.Dal.Models
{
    public class ComboTagGroupDto
    {
        public double? AvgScore { get; set; }

        public double CountProducts { get; set; }

        public double CountOrders { get; set; }

        public bool? IsLiked { get; set; }

        public int? GroupId { get; set; }

        public int? TagId { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is ComboTagGroupDto tg &&
                AvgScore == tg.AvgScore &&
                CountProducts == tg.CountProducts &&
                CountOrders == tg.CountOrders &&
                IsLiked == tg.IsLiked &&
                GroupId == tg.GroupId &&
                TagId == tg.TagId;
        }
    }
}
