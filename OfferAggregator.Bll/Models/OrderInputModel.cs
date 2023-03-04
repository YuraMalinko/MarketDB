using OfferAggregator.Dal.Models;
using System.ComponentModel.DataAnnotations;

namespace OfferAggregator.Bll.Models
{
    public class OrderInputModel
    {
        public DateTime? DateCreate { get; set; }

        public DateTime? ComplitionDate { get; set; }

        public int ManagerId { get; set; }

        public int ClientId { get; set; }

        public CurrentManager Manager { get; set; }

        public ClientOutputModel Client { get; set; }
    }
}
