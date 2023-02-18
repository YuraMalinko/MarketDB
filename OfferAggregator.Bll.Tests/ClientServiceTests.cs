using Moq;
using OfferAggregator.Bll.Models;
using OfferAggregator.Bll.Tests.TestCaseSource;
using OfferAggregator.Dal.Models;
using OfferAggregator.Dal.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

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

        [TestCaseSource(typeof(ClientServiceTestCaseSource),nameof(ClientServiceTestCaseSource.GetCLientByNameTestCaseSource))]
        public void GetCLientByNameTest(string name, ClientsDto clientsDto, ClientOutput expected)
        {
            _mockClientRepo.Setup(c => c.GetClientByName(name)).Returns(clientsDto).Verifiable();
            ClientOutput actual = _clientService.GetClientByName(name);

            _mockClientRepo.VerifyAll();

            Assert.AreEqual(expected, actual);
        }


        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void GetClientByName_WhenNameIsNull_ShouldThrowAddProductTest_ShouldThrowArgumentNullExceptionn(string name)
        {
            Assert.Throws<ArgumentNullException>(() => _clientService.GetClientByName(name));
        }

        [Test]
        public void GetClientByName_WhenClientNotExistOrDeleted_ShouldThrowExeption()
        {
            string name = "Pashka";
            ClientsDto clientsDto = null;
            _mockClientRepo.Setup(c=>c.GetClientByName(name)).Returns(clientsDto);

            Assert.Throws<Exception>(()=> _clientService.GetClientByName(name));
        }


    }
}
