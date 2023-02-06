using OfferAggregator.Dal.Models;

namespace OfferAggregator.Dal.Repositories
{
    public interface IClientsWishesRepository
    {
        public int AddClientWishes(ClientWishesDto clientWishes);

        public bool DeleteClientWishesById(ClientWishesDto clientWishes);

        public List<ClientWishesDto> GetClientWishesByClientId(ClientWishesDto clientWishes);

        public bool UpdateClientWishesById(ClientWishesDto clientWishes);
    }
}