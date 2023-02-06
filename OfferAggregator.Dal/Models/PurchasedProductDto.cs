namespace OfferAggregator.Dal.Models
{
    public class PurchasedProductDto
    {
        public int? Id { get; set; }

        public string? Name { get; set; }

        public int? AmountOrderedByCustomer { get; set; }

        public GroupDto? Group { get; set; }

        public List<TagDto>? Tags { get; set; }
    }
}
