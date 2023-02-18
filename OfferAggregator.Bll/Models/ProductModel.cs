using System.ComponentModel.DataAnnotations;

namespace OfferAggregator.Bll.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public bool IsDeleted { get; set; }

        [Required]
        public int GroupId { get; set; }
    }
}
