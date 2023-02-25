using OfferAggregator.Bll.Models;
using OfferAggregator.Dal.Models;
using OfferAggregator.Dal.Repositories;

namespace OfferAggregator.Bll
{
    public class ClientService
    {
        private Mapper _instanceMapper = Mapper.GetInstance();

        public IClientRepository _clientRepository { get; set; }

        public ClientService(IClientRepository clientRepository = null)
        {
            if (clientRepository == null)
            {
                _clientRepository = new ClientRepository();
            }
            else
            {
                _clientRepository = clientRepository;
            }
        }

        public List<ClientOutput> GetAllClients()
        {
            List<ClientsDto> clientsAll = _clientRepository.GetAllClients();
            var result = _instanceMapper.MapClientsDtosToClientsOutput(clientsAll);

            return result;
        }

        public List<ClientOutput> GetClientByName(string name)
        {
            if (name == null || name == "" || name == " ")
            {
                throw new ArgumentNullException("name is null");
            }

            List<ClientsDto> clients = _clientRepository.GetClientsByName(name);

            if (clients.Count==0)
            {
                throw new Exception("There are no clients with this name or they were deleted");
            }

            return _instanceMapper.MapClientsDtoToClientsOutput(clients);
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
