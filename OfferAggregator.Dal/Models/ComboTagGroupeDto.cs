namespace OfferAggregator.Dal.Models
{
    public class ComboTagGroupDto
    {
        public double AvgScore { get; set; }

        public GroupDto Group { get; set; }

        public TagDto Tag { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is ComboTagGroupDto tg &&
                AvgScore == tg.AvgScore &&
                Group == tg.Group &&
                Tag == tg.Tag;
        }
    }
}
