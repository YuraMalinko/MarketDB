using System.ComponentModel.DataAnnotations;

namespace OfferAggregator.Bll.Models
{
    public class GroupInputModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

    }
}
