namespace OfferAggregator.Dal.Models
{
    public class ClientsProductDto
    {
       public List<ClientsDto> Clients { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}
