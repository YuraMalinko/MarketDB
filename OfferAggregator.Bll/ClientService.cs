using OfferAggregator.Bll.Models;
using OfferAggregator.Dal.Models;
using OfferAggregator.Dal.Repositories;
using System.Net;

namespace OfferAggregator.Bll
{
    public class ClientService
    {
        private Mapper _instanceMapper = Mapper.GetInstance();

        public IClientRepository _clientRepository { get; set; }
        public IClientsWishesRepository _clientsWishesRepository { get; set; }
        public ICommentForClientRepository _commentForClientRepository { get; set; }

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
            var result = _instanceMapper.MapClientsDtoToClientsOutput(clientsAll);

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

        public int AddClient (ClientOutput client)
        {
            var newClient = _instanceMapper.MapClientsOutputModelToClientsDto(client);

            if (client.Name == null || client.PhoneNumber == null)
            {
                throw new ArgumentException("Заполните все поля!");
            }
            else
            {
                var phoneNewClient = newClient.PhoneNumber;
                ClientsDto searchClietnt = _clientRepository.GetClientByPhoneNumber(phoneNewClient);
                if (searchClietnt == null)
                {
                    _clientRepository.AddClient(newClient);
                }
                else
                {
                    throw new ArgumentException("");
                }
            }

            return newClient.Id;
        }

        public bool DeleteClient(int id)
        {
            var client = _clientRepository.GetClientById(id);
            bool result;

            if (client == null)
            {
                throw new ArgumentException("Клиента, карточку которого вы пытаетесь удалить, не существует.");
                result = false;
            }
            else
            {
                _clientRepository.DeleteClient(id);
                _clientsWishesRepository.DeleteClientWishesById(id);
                _commentForClientRepository.DeleteComment(id);
                result = false;
            }

            return result;
        }

        public bool UpdateCLient(ClientOutput client)
        {
            bool result = false;

            if (client.Name == null || client.PhoneNumber == null)
            {
                throw new ArgumentException("Поля 'Имя' и 'Номер телефона' не могут быть пустыми!");
            }
            else
            {
                var newClient = _instanceMapper.MapClientsOutputModelToClientsDto(client);
                _clientRepository.UpdateClient(newClient);
            }

            return result;
        }
    }
}
