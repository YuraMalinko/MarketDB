namespace OfferAggregator.Dal.Models
{
    public class CommentForClientDto
    {
        public int Id { get; set; }

        public string? Text { get; set; }

        public int ClientId { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is CommentForClientDto dto &&
                   Id == dto.Id &&
                   Text == dto.Text &&
                   ClientId == dto.ClientId;
        }
    }
}