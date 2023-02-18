using OfferAggregator.Bll.Models;
using OfferAggregator.Dal.Models;
using OfferAggregator.Dal;
using OfferAggregator.Dal.Repositories;
using AutoMapper.Configuration.Annotations;

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

        public List<InfoAllClientsOutputModel> GetAllClientsWithoutComment()
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

        public ClientOutput GetClientByName(string name)
        {
            if (name == null || name == "" || name == " ")
            {
                throw new ArgumentNullException("name is null");
            }

            ClientsDto client = _clientRepository.GetClientByName(name);

            if (client == null)
            {
                throw new Exception("Client does not exist or has been deleted");
            }

            return _instanceMapper.MapClientDtoToClientOutput(client);
        }
    }
}
