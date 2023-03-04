using System.ComponentModel.DataAnnotations;

namespace OfferAggregator.Bll.Models
{
    public class ProductCountInputModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Required]
        [Range(1, 2147483647, ErrorMessage = "Введите целое число больше 0.")]
        public int Count { get; set; }
    }
}
