using OfferAggregator.Dal.Models;

namespace OfferAggregator.Bll.Models
{
    public class ComboTagGroupCountProductCountOrderOutputModel
    {
        public int AvgPercentOfCountProductsAndOrders { get; set; }

        public GroupOutputModel Group { get; set; }

        public TagOutputModel Tag { get; set; }
    }
}
