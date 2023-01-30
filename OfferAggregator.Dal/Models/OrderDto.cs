﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferAggregator.Dal.Models
{
    public class OrderDto
    {
        public int? Id { get; set; }

        public DateTime? DateCreate { get; set; }

        public DateTime? ComplitionDate { get; set; }

        public int? ManagerId { get; set; }

        public int? ClientId { get; set; }

    }
}
