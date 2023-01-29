using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OfferAggregator.Dal.Options
{
    public class ConnectOptions
    {
        public const string ConnectString = @"Data Source=80.78.240.16;
                            Initial Catalog = MarketDataBase; 
                            Persist Security Info=True;
                            TrustServerCertificate=True;
                            User ID = student;
                            Password=qwe!23;";

    }
}
