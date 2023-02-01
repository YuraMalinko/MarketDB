namespace OfferAggregator.Dal.Models
{
    public class FullOrderDto
    {
        public int OrderId { get; set; }

        public DateTime DateCreate { get; set; }

        public DateTime ComplitionDate { get; set; }

        public int ManagerId { get; set; }

        public string Login { get; set; }

        public string Text { get; set; }

        public int ClientId { get; set; }

        public string ClientName { get; set; }

        public string PhoneNumber { get; set; }

        public List<ProductWithCountDto> ProductWithCount { get; set; }
    }
}
