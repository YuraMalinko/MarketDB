namespace OfferAggregator.Bll.Models
{
    public class ComboTagGroupOutputModel
    {
        public double PointForCombo { get; set; }

        public int? GroupId { get; set; }

        public int? TagId { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is ComboTagGroupOutputModel tg &&
                PointForCombo == tg.PointForCombo &&
                GroupId == tg.GroupId &&
                TagId == tg.TagId;
        }
    }
}
