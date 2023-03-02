namespace OfferAggregator.Dal.Models
{
    public class GroupDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is GroupDto g &&
                Id == g.Id &&
                Name == g.Name;
        }
    }
}
