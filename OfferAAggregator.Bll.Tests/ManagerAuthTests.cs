using Moq;
using OfferAggregator.Bll.Models;
using OfferAggregator.Bll.Tests.TestCaseSource;
using OfferAggregator.Dal.Models;
using OfferAggregator.Dal.Repositories;

namespace OfferAggregator.Bll.Tests
{
    public class ManagerAuthTests
    {
        private ManagerAuth _managerAuth;

        private Mock<IManagerRepository> _mockManagerRepo;

        [SetUp]

        public void Setup()
        {
            _mockManagerRepo = new Mock<IManagerRepository>();
            _managerAuth = new ManagerAuth(_mockManagerRepo.Object);
        }

        [TestCaseSource(typeof(ManagerAuthTestCaseSource), nameof(ManagerAuthTestCaseSource.AddManagerTestCaseSource))]
        public void AddManagerTest(ManagerAuthInput managerAuthInput, ManagerDto managerDtoInput, ManagerDto requestManagerByLogin, int result, int expected)
        {
            _mockManagerRepo.Setup(m => m.GetManagerByLogin(managerDtoInput.Login)).Returns(requestManagerByLogin).Verifiable();
            _mockManagerRepo.Setup(r => r.AddManager(It.Is<ManagerDto>(g => g.Equals(managerDtoInput)))).Returns(result).Verifiable();
            int actual = _managerAuth.AddManager(managerAuthInput);
            _mockManagerRepo.VerifyAll();

            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(ManagerAuthTestCaseSource), nameof(ManagerAuthTestCaseSource.AddManagerNegativeTestCaseSource))]
        public void AddManagerNegativeTest(ManagerAuthInput managerAuthInput, ManagerDto managerDtoInput, ManagerDto requestManagerByLogin, int expected)
        {
            _mockManagerRepo.Setup(m => m.GetManagerByLogin(managerDtoInput.Login)).Returns(requestManagerByLogin).Verifiable();
            _mockManagerRepo.Setup(n => n.AddManager(It.Is<ManagerDto>(md => md.Equals(managerDtoInput)))).Throws<Exception>();
            int actual = _managerAuth.AddManager(managerAuthInput);
            _mockManagerRepo.Verify(q => q.GetManagerByLogin(managerDtoInput.Login), Times.Once);
            _mockManagerRepo.Verify(p => p.AddManager(It.IsAny<ManagerDto>()), Times.AtMost(2));

            Assert.AreEqual(expected, actual);

        }

        [TestCaseSource(typeof(ManagerAuthTestCaseSource), nameof(ManagerAuthTestCaseSource.ManagerAuthenticationTestCaseSourse))]
        public void ManagerAuthenticationTest(ManagerAuthInput managerAuthInput, ManagerDto managerDtoInput, ManagerDto managerDtoOutput, CurrentManager expected)
        {
            _mockManagerRepo.Setup(m => m.GetSingleManager(It.Is<ManagerDto>(g => g.Equals(managerDtoInput)))).Returns(managerDtoOutput).Verifiable();
            CurrentManager actual = _managerAuth.ManagerAuthentication(managerAuthInput);
            _mockManagerRepo.VerifyAll();

            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(ManagerAuthTestCaseSource), nameof(ManagerAuthTestCaseSource.UpdateManagerTestCaseSource))]
        public void UpdateManagerTest(CurrentManager currentManager, ManagerDto managerDtoInput, bool result, bool expected)
        {
            _mockManagerRepo.Setup(m => m.UpdateManager(It.Is<ManagerDto>(g => g.Equals(managerDtoInput)))).Returns(result).Verifiable();
            bool actual = _managerAuth.UpdateManager(currentManager);
            _mockManagerRepo.VerifyAll();

            Assert.AreEqual(expected, actual);
        }
    }
}
