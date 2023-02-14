namespace OfferAggregator.Dal.Models
{
    public class StocksDtoWithProductName
    {
        public int Amount { get; set; }

        public int ProductId { get; set; }

        public string Name { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is StocksDtoWithProductName name &&
                   Amount == name.Amount &&
                   ProductId == name.ProductId &&
                   Name == name.Name;
        }
    }
}
