using System.ComponentModel.DataAnnotations;

namespace OfferAggregator.Bll.Models
{
    public class StocksWithProductInputModel
    {
        [Required]
        [Range(1, 2147483647, ErrorMessage = "Введите целое число больше 0.")]
        public int Amount { get; set; }

        public int ProductId { get; set; }

        public string Name { get; set; }
    }
}
