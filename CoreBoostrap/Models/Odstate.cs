using System;
using System.Collections.Generic;

#nullable disable

namespace CoreBoostrap.Models
{
    public partial class Odstate
    {
        public Odstate()
        {
            Orders = new HashSet<Order>();
        }

        public int OrderStateId { get; set; }
        public string OrderState { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
