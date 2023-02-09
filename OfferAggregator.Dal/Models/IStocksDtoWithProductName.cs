namespace OfferAggregator.Dal.Models
{
    public interface IStocksDtoWithProductName
    {
        int Amount { get; set; }
        string Name { get; set; }
        int ProductId { get; set; }
    }
}