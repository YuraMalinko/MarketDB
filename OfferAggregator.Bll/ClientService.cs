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
    }
}
