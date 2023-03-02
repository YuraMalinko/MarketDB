using OfferAggregator.Dal.Models;

namespace OfferAggregator.Bll.Models
{
    public class ClientsProductOutputModel
    {
        public List<ClientOutputModel> Clients { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}
