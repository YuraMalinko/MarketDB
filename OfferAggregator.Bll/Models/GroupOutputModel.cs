namespace OfferAggregator.Bll.Models
{
    public class GroupOutputModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is GroupOutputModel model &&
                Id==model.Id &&
                Name==model.Name;
        }
    }
}
