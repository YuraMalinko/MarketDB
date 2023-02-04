namespace OfferAggregator.Dal.Models
{
    public class ProductsDto
    {
        public int? Id { get; set; }

        public string? Name { get; set; }

        public bool? IsDeleted { get; set; }

        public int? GroupId { get; set; }

        public int? AmountOrderedByCustomer { get; set; }

        public GroupDto? Group { get; set; }

        public List<TagDto>? Tags { get; set; }
    }
}
