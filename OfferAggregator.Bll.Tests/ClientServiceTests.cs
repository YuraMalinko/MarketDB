using Moq;
using OfferAggregator.Bll.Models;
using OfferAggregator.Bll.Tests.TestCaseSource;
using OfferAggregator.Dal.Models;
using OfferAggregator.Dal.Repositories;

namespace OfferAggregator.Bll.Tests
{
    public class ClientServiceTests
    {
        private ClientService _clientService;

        private Mock<IClientRepository> _mockClientRepo;

        [SetUp]

        public void Setup()
        {
            _mockClientRepo = new Mock<IClientRepository>();
            _clientService = new ClientService(_mockClientRepo.Object);
        }

        [TestCaseSource(typeof(ClientServiceTestCaseSource), nameof(ClientServiceTestCaseSource.GetCLientsByNameTestCaseSource))]
        public void GetCLientsByNameTest(string name, List<ClientsDto> clientsDto, List<ClientOutput> expected)
        {
            _mockClientRepo.Setup(c => c.GetClientsByName(name)).Returns(clientsDto).Verifiable();
            List<ClientOutput> actual = _clientService.GetClientByName(name);

            _mockClientRepo.VerifyAll();

            Assert.AreEqual(expected, actual);
        }


        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void GetClientsByName_WhenNameIsNull_ShouldThrowAddProductTest_ShouldThrowArgumentNullExceptionn(string name)
        {
            Assert.Throws<ArgumentNullException>(() => _clientService.GetClientByName(name));
        }

        [Test]
        public void GetClientsByName_WhenClientsNotExistOrDeleted_ShouldThrowExeption()
        {
            string name = "Pashka";
            List<ClientsDto> clients = new List<ClientsDto>() { };
            _mockClientRepo.Setup(c => c.GetClientsByName(name)).Returns(new List<ClientsDto>()).Verifiable();
            _mockClientRepo.Verify(c => c.GetClientsByName(name), Times.Never);

            Assert.Throws<Exception>(() => _clientService.GetClientByName(name));
        }
    }
}