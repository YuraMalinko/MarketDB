using System.ComponentModel.DataAnnotations;

namespace OfferAggregator.Bll.Models
{
    public class ProductReviewInputModel
    {
        //[Required]
        //[Range(1, 5, ErrorMessage = "Необходимо ввести оценку от 1 до 5")]
        public int? Score { get; set; }

        public string? Comment { get; set; }

        public int ClientId { get; set; }

        public int ProductId { get; set; }
    }
}
