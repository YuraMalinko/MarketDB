using OfferAggregator.Bll.Models;
using OfferAggregator.Dal.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace OfferAggregator.Bll.Tests.TestCaseSource
{
    public class ClientServiceTestCaseSource
    {
        public static IEnumerable GetCLientByNameTestCaseSource()
        {
            string name = "Kevin";

            ClientsDto clientsDto = new ClientsDto()
            {
                Id=13,
                Name="Kevin",
                PhoneNumber= "38286387"
            };

            ClientOutput expected = new ClientOutput()
            {
                Id = 13,
                Name = "Kevin",
                PhoneNumber = "38286387"
            };

            yield return new object[] {name,clientsDto,expected};
        }

    }
}
