using OfferAggregator.Bll.Models;
using OfferAggregator.Dal.Models;
using OfferAggregator.Dal;
using OfferAggregator.Dal.Repositories;

namespace OfferAggregator.Bll
{
    public class ClientService
    {
        private Mapper _instanceMapper = Mapper.GetInstance();

        private IClientRepository _clientRepository;

        private IProductsRepository _productsRepository;

        public ClientService(IClientRepository clientRepository, IProductsRepository productsRepository)
        {
            _clientRepository = clientRepository;
            _productsRepository = productsRepository;
        }

        public List<InfoAllClientsOutputModel> GetAllClientsWithoutComment()
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
    }
}
