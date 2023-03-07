using System.ComponentModel.DataAnnotations;

namespace OfferAggregator.Bll.Models
{
    public class ClientInputModel
    {
        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Длина строки с именем должна быть не менее 2х")]
        public string Name { get; set; }

        [Required]
        [Range(11, 11, ErrorMessage = "Телефон должен содержать 11 цифр")]
        public string PhoneNumber { get; set; }
    }
}
