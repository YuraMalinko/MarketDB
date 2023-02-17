namespace OfferAggregator.Dal.Models
{
    public class OrdersProductsDto
    {
        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int CountProduct { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is OrdersProductsDto dto &&
                   OrderId == dto.OrderId &&
                   ProductId == dto.ProductId &&
                   CountProduct == dto.CountProduct;
        }
    }
}
