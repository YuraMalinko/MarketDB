using System.ComponentModel.DataAnnotations;

namespace OfferAggregator.Bll.Models
{
    public class StocksWithProductModel
    {
        [Required]
        [Range(1, 2147483647, ErrorMessage = "Accommodation invalid (1-2147483647).")]
        public int Amount { get; set; }

        public int ProductId { get; set; }

        public string Name { get; set; }
    }
}
