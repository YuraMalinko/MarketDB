using OfferAggregator.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferAggregator.Dal.Repositories
{
    public interface IAggregatorRepository
    {
        public List<ComboTagGroupDto> GetAvgScoreGroupeAndTagOnProductsReviewsByClientId(int id);
    }
}
