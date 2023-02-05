namespace OfferAggregator.Dal.Models
{
    public class ClientsDto
    {
        public int? Id { get; set; }

        public string? Name { get; set; }

        public string? PhoneNumber { get; set; }

        public List<CommentForClientDto>? CommetsForClient { get; set; }
    }
}