namespace OfferAggregator.Dal.Models
{
    public class ManagerDto
    {
        public int Id { get; set; }

        public string? Login { get; set; }

        public string? Password { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is ManagerDto dto && 
                Id == dto.Id 
                && Login == dto.Login 
                && Password == dto.Password;
        }
    }
}
