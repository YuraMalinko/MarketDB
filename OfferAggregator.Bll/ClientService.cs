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

        public List<ClientsOutputModel> GetAllClientsWithoutComment()
        {
            List<ClientsDto> clientsAll = _clientRepository.GetAllClients();
            var result = _instanceMapper.MapClientsDtosToClientsOutputModels(clientsAll);

            return result;
        }

        public int AddClient (ClientsOutputModel client)
        {
            int result = -1;
            
            var newClient = _instanceMapper.MapClientsOutputModelToClientsDto(client);
            var phoneNewClient = newClient.PhoneNumber;
            ClientsDto searchClietnt = _clientRepository.GetClientByPhoneNumber(phoneNewClient);
            if (searchClietnt == null) 
            {
                result = _clientRepository.AddClient(newClient);
            }

            return result;
        }

        public bool DeleteClient(int id)
        {
            var result = _clientRepository.DeleteClient(id);
            _clientsWishesRepository.DeleteClientWishesById(id);
            _commentForClientRepository.DeleteComment(id);

            return result;
        }

        public bool UpdateCLient(ClientsOutputModel client)
        {
            var clietnDto = _instanceMapper.MapClientsOutputModelToClientsDto(client);
            var result = _clientRepository.UpdateClient(clietnDto);

            return result;
        }
    }
}
