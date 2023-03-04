using System.ComponentModel.DataAnnotations;

namespace OfferAggregator.Bll.Models
{
    public class ProductOutputModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool? IsDeleted { get; set; }

        public int GroupId { get; set; }
    }
}
