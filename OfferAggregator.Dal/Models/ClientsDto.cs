namespace OfferAggregator.Dal.Models
{
    public class ClientsDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public List<CommentForClientDto>? CommentsForClient { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is ClientsDto dto &&
                   Id == dto.Id &&
                   Name == dto.Name &&
                   PhoneNumber == dto.PhoneNumber &&
                   EqualityComparer<List<CommentForClientDto>?>.Default.Equals(CommentsForClient, dto.CommentsForClient);
        }
    }
}