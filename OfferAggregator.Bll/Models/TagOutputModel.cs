namespace OfferAggregator.Bll.Models
{
    public class TagOutputModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is TagOutputModel tag &&
                Id == tag.Id &&
                Name == tag.Name;
        }
    }
}
