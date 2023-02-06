using OfferAggregator.Dal.Models;

namespace OfferAggregator.Dal.Repositories
{
    public interface IClientsWishesRepository
    {
        public bool AddClientWishes(ClientWishesDto clientWishes);

        public bool DeleteClientWishes(ClientWishesDto clientWishes);

        public List<ClientWishesDto> GetClientWishesByClientId(ClientWishesDto clientWishes);

        public bool UpdateClientWishes(ClientWishesDto clientWishes);
    }
}