using OfferAggregator.Dal.Models;

namespace OfferAggregator.Dal.Repositories
{
    public interface IClientsWishesRepository
    {
        public int AddClientWishes(ClientWishesDto clientWishes);

        public bool DeleteClientWishesById(int id);

        public List<ClientWishesDto> GetClientWishesByClientId(int clientId);

        public bool UpdateClientWishesById(ClientWishesDto clientWishes);
    }
}