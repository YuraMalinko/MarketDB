using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferAggregator.Dal.Models
{
    public class StocksDto
    {
        public int Amount { get; set; }

        public int? ProductId { get; set; }
    }
}
