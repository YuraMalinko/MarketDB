using OfferAggregator.Bll.Models;
using OfferAggregator.Dal.Models;
using System.Collections;

namespace OfferAggregator.Bll.Tests.TestCaseSource
{
    public class ClientServiceTestCaseSource
    {
        public static IEnumerable GetCLientsByNameTestCaseSource()
        {
            string name = "Kevin";

            List<ClientsDto> clientsDto = new List<ClientsDto>()
            {
                new ClientsDto()
                {
                Id = 13,
                Name = "Kevin",
                PhoneNumber = "38286387"
                },
                new ClientsDto()
                {
                Id = 13,
                Name = "Kevin",
                PhoneNumber = "8800"
                }
            };

            List<ClientOutput> expected = new List<ClientOutput>()
            {
                new ClientOutput()
                {
                Id = 13,
                Name = "Kevin",
                PhoneNumber = "38286387"
                },
                new ClientOutput()
                {
                Id = 13,
                Name = "Kevin",
                PhoneNumber = "8800"
                }
            };

            yield return new object[] { name, clientsDto, expected };
        }
    }
}
