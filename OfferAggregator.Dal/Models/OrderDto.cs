namespace OfferAggregator.Dal.Models
{
    public class OrderDto
    {
        public int Id { get; set; }

        public DateTime? DateCreate { get; set; }

        public DateTime? ComplitionDate { get; set; }

        public int ManagerId { get; set; }

        public int ClientId { get; set; }

        public ManagerDto? Manager { get; set; }

        public ClientsDto? Client { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is OrderDto dto &&
                   Id == dto.Id &&
                   DateCreate == dto.DateCreate &&
                   ComplitionDate == dto.ComplitionDate &&
                   ManagerId == dto.ManagerId &&
                   ClientId == dto.ClientId &&
                   EqualityComparer<ManagerDto?>.Default.Equals(Manager, dto.Manager) &&
                   EqualityComparer<ClientsDto?>.Default.Equals(Client, dto.Client);
        }
    }
}