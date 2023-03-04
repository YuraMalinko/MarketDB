using OfferAggregator.Dal.Models;

namespace OfferAggregator.Bll.Models
{
    public class ComboTagGroupOutputModel
    {
        public int PointForCombo { get; set; }

        public GroupOutputModel? Group { get; set; }

        public TagOutputModel? Tag { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is ComboTagGroupOutputModel tg &&
                PointForCombo == tg.PointForCombo &&
                Group == tg.Group &&
                Tag == tg.Tag;
        }
    }
}
