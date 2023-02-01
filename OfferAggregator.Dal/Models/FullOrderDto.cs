namespace OfferAggregator.Dal.Models
{
    public class FullOrderDto
    {
        public int OrderId { get; set; }

        public DateTime DateCreate { get; set; }

        public DateTime ComplitionDate { get; set; }

        public ManagerDto Manager { get; set; }

        public string Comment { get; set; }

        public ClientsDto Client { get; set; }

        public List<ProductWithCountDto> ProductWithCount { get; set; }
    }
}
