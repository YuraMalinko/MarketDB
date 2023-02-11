﻿namespace OfferAggregator.Dal.Models
{
    public class ProductsStatisticDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int SumOfCountofProduct { get; set; }

        public int CountOfOrders { get; set; }

        public int CountOfClients { get; set; }

        public float? AverageScore { get; set; }
    }
}
