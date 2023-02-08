namespace OfferAggregator.Dal.Models
{
    public class ProductsDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int GroupId { get; set; }

        public bool IsDeleted { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is ProductsDto dto &&
                   Id == dto.Id &&
                   Name == dto.Name &&
                   IsDeleted == dto.IsDeleted &&
                   GroupId == dto.GroupId;
        }
    }
}
