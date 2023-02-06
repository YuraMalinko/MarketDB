namespace OfferAggregator.Dal.Models
{
    public class ClientWishesDto
    {
        public int? ClientId { get; set; }

        public int? GroupId { get; set; }

        public int? TagId { get; set; }

        public bool? IsLiked { get; set; }
    }
}
