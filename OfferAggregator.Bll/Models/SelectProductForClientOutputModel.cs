using OfferAggregator.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferAggregator.Bll.Models
{
    public class SelectProductForClientOutputModel: IComparable<SelectProductForClientOutputModel>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Amount { get; set; }

        public double PurchaseProbability { get; set; }

        public int CompareTo(SelectProductForClientOutputModel product)
        {
            if (product.PurchaseProbability > PurchaseProbability)
            {
                return 1;
            }
            else if (product.PurchaseProbability < PurchaseProbability)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        public override bool Equals(object? obj)
        {
            return obj is SelectProductForClientOutputModel p &&
                Id==p.Id &&
                Name==p.Name &&
                Amount==p.Amount &&
                PurchaseProbability==p.PurchaseProbability;
        }
    }
}
