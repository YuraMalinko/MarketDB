using OfferAggregator.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferAggregator.Bll.Models
{
    public class OrderAllInfo
    {
        public int Id { get; set; }

        public DateTime? DateCreate { get; set; }

        public DateTime? ComplitionDate { get; set; }

        public ClientsDto? Client { get; set; }
    }
}