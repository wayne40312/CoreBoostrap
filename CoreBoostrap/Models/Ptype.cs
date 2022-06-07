using System;
using System.Collections.Generic;

#nullable disable

namespace CoreBoostrap.Models
{
    public partial class Ptype
    {
        public Ptype()
        {
            Orders = new HashSet<Order>();
        }

        public int PayTypeId { get; set; }
        public string PayType { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
