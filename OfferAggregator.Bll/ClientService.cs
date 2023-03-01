using OfferAggregator.Bll.Models;
using OfferAggregator.Dal.Models;
using OfferAggregator.Dal.Repositories;
using OfferAggregator.Dal;
using System.Net;

namespace OfferAggregator.Bll
{
    public class ClientService
    {
        private Mapper _instanceMapper = Mapper.GetInstance();

        public IClientRepository _clientRepository { get; set; }
        public IClientsWishesRepository _clientsWishesRepository = new ClientsWishesRepository();
        public ICommentForClientRepository _commentForClientRepository = new CommentForClientRepository();
        public IOrderRepository _orderRepository = new OrderRepository();
        public IProductsRepository _productsRepository = new ProductsRepository();

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

        public List<ClientOutputModel> GetAllClients()
        {
            List<ClientsDto> clientsAll = _clientRepository.GetAllClients();
            var result = _instanceMapper.MapClientsDtoToClientsOutputModel(clientsAll);

            return result;
        }

        public ClientsProductOutputModel GetClientsWhoOrderedProductByProductId(int productId)
        {
            var getProduct = _productsRepository.GetProductById(productId);

            if (getProduct == null)
            {
                throw new ArgumentException($"Product with productId {productId} is not exist");
            }
                var getClientsDto = _clientRepository.GetClientsWhoOrderedProductByProductId(productId);
                var getClientsModel = _instanceMapper.MapClientsProductDtoToClientsProductOutpetModel(getClientsDto);

                return getClientsModel;
        }

        public List<ClientOutputModel> GetClientByName(string name)
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

            return _instanceMapper.MapClientsDtoToClientsOutputModel(clients);
        }

        public ClientOutputModel GetClientById(int id)
        {
            ClientsDto clients = _clientRepository.GetClientById(id);

            return _instanceMapper.MapClientDtoToClientOutputModel(clients);
        }

        public int AddClient (ClientInputModel client)
        {
            var newClient = _instanceMapper.MapClientsInputModelModelToClientsDto(client);

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

                result = true;
            }

            return result;
        }

        public bool UpdateCLient(ClientInputModel client)
        {
            bool result = false;

            if (client.Name == null || client.PhoneNumber == null)
            {
                throw new ArgumentException("Поля 'Имя' и 'Номер телефона' не могут быть пустыми!");
            }
            else
            {
                var newClient = _instanceMapper.MapClientsInputModelModelToClientsDto(client);
                _clientRepository.UpdateClient(newClient);
            }

            return result;
        }

        public List<CommentForClientOutputModel> GetAllCommentsForClientById(int id) 
        { 
            List<CommentForClientDto> comment = _commentForClientRepository.GetClientCommentsByClientId(id);
            var result = _instanceMapper.MapCommentForClientDtoToCommentForClientOutputModel(comment);

            return result;
        }

        public int AddComment(CommentForClientInputModel comment, int clientId)
        {
            comment.ClientId = clientId;
            var newComment = _instanceMapper.MapCommentForClientInputModelToCommentForClientDto(comment);
            
            if(newComment.Text != null && newComment.ClientId != null) 
            {
                _commentForClientRepository.AddComment(newComment);
            }
            else
            {
                throw new ArgumentException("Текст комментария не может быть пустым!");
            }

            return newComment.Id;
        }

        public bool DeleteComment(int commentId) 
        {
            _commentForClientRepository.DeleteComment(commentId);

            return true;
        }
    }
}
