namespace OfferAggregator.Bll.Models
{
    public class ClientOutput
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is ClientOutput other &&
                Id == other.Id &&
                Name == other.Name &&
                PhoneNumber == other.PhoneNumber;
        }
    }
}