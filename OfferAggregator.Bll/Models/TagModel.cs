namespace OfferAggregator.Bll.Models
{
    public class TagModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is TagModel tag &&
                Id == tag.Id &&
                Name == tag.Name;
        }
    }
}
