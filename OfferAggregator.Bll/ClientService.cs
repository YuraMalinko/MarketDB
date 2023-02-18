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

            List<ClientsDto> clientsAll = _clientRepository.GetAllClients();
            var result = _instanceMapper.MapClientsDtoToClientsOutputModel(clientsAll);

            return result;
        }

        public ClientOutput GetClientByName(string name)
        {
            ClientsDto client = _clientRepository.GetClientByName(name);

            return _instanceMapper.MapClientDtoToClientOutput(client);
        }
    }
}
