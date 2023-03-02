namespace OfferAggregator.Bll.Models
{
    public class GroupOutput
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is GroupOutput group &&
                Id == group.Id &&
                Name == group.Name;
        }
    }
}
