using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferAggregator.Dal.Models
{
    public class TagDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is TagDto tag &&
                Id==tag.Id &&
                Name==tag.Name;
        }

    }
}
