using OfferAggregator.Dal.Models;

namespace OfferAggregator.Bll.Models
{
    public class CurrentManager
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public CurrentManager(int id,string login, string password)
        {
            Id = id;
            Login = login;
            Password = password;
        }
        public CurrentManager()
        {
        }

        public override string ToString()
        {
            return $"{Id} {Login} {Password}";
        }

        public override bool Equals(object? obj)
        {
            return obj is CurrentManager cm &&
                Id == cm.Id &&
                Login == cm.Login &&
                Password == cm.Password;
        }
    }
}
