using OfferAggregator.Dal.Models;

namespace OfferAggregator.Dal.Repositories
{
    public interface IClientRepository
    {
        public int AddClient(ClientsDto client);

        public bool UpdateClient(ClientsDto client);

        public bool DeleteClient(int id);

        public List<ClientsDto> GetAllClients();

        public List<PurchasedProductDto> GetAllPurchasedProductsByClientId(int id);

        public ClientsDto GetClientById(int id);

        public ClientsProductDto GetClientsWhoOrderedProductByProductId(int productId);

    }
}