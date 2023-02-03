namespace OfferAggregator.Bll.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsDeleted { get; set; }

        public int? GroupId { get; set; }
    }
}
