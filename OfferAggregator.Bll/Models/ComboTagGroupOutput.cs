using OfferAggregator.Dal.Models;

namespace OfferAggregator.Bll.Models
{
    public class ComboTagGroupOutputModel
    {
        public int PointForCombo { get; set; }

        public GroupOutput Group { get; set; }

        public TagDto Tag { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is ComboTagGroupOutputModel tg &&
                PointForCombo == tg.PointForCombo &&
                Group == tg.Group &&
                Tag == tg.Tag;
        }
    }
}
