using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferAggregator.Bll.Models
{
    public class SelectProductForClientOutputModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Amount { get; set; }

        public int PurchaseProbability { get; set; }
    }
}
