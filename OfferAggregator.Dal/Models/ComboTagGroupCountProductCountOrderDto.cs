namespace OfferAggregator.Dal.Models
{
    public class ComboTagGroupCountProductCountOrderDto
    {
        public int CountProducts { get; set; }

        public int CountOrders { get; set; } 
        
        public GroupDto Group { get; set; }

        public TagDto Tag { get; set; }

    }
}
