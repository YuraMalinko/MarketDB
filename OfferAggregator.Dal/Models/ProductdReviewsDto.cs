using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferAggregator.Dal.Models
{
    public class ProductdReviewsDto
    {
        public int? Score { get; set; }

        public string Comment { get; set; }

        public int? ClientId { get; set; }

        public int? ProductId { get; set; }
    }
}
