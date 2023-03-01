using OfferAggregator.Dal.Models;

namespace OfferAggregator.Bll.Models
{
    public class OrderModel
    {
        public int Id { get; set; }

        public DateTime? DateCreate { get; set; }

        public DateTime? ComplitionDate { get; set; }

        public int ManagerId { get; set; }

        public int ClientId { get; set; }

        public CurrentManager Manager { get; set; }

        public ClientInputModel Client { get; set; }
    }
}
