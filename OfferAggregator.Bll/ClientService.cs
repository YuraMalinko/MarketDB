using OfferAggregator.Bll.Models;
using OfferAggregator.Dal.Models;
using OfferAggregator.Dal;
using OfferAggregator.Dal.Repositories;

namespace OfferAggregator.Bll
{
    public class ClientService
    {
        private Mapper _instanceMapper = Mapper.GetInstance();

        private ClientRepository _clientRepository;
        private ClientsWishesRepository _clientsWishesRepository;
        private CommentForClientRepository _commentForClientRepository;
        private OrderRepository _orderRepository;

        public ClientService(ClientRepository clientRepository, ClientsWishesRepository clientsWishesRepository, 
            CommentForClientRepository commentForClientRepository, OrderRepository orderRepository) 
        {
            _clientRepository = clientRepository;
            _clientsWishesRepository = clientsWishesRepository;
            _commentForClientRepository = commentForClientRepository;
            _orderRepository = orderRepository;
        }

        public List<AllClientsOutputModel> GetAllClientsWithoutComment()
        {
            List<ClientsDto> clientsAll = _clientRepository.GetAllClients();
            var result = _instanceMapper.MapClientsDtosToClientsOutputModels(clientsAll);

            return result;
        }
    }
}
