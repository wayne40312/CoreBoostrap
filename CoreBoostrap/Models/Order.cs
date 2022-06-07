using System;
using System.Collections.Generic;

#nullable disable

namespace CoreBoostrap.Models
{
    public partial class Order
    {
        public Order()
        {
            Orderdetails = new HashSet<Orderdetail>();
            Reviews = new HashSet<Review>();
        }

        public int OrderId { get; set; }
        public int MemId { get; set; }
        public DateTime OrderDate { get; set; }
        public int CityId { get; set; }
        public string ShipAddress { get; set; }
        public int? OrderStateId { get; set; }
        public int? PayTypeId { get; set; }

        public virtual City City { get; set; }
        public virtual Member Mem { get; set; }
        public virtual Odstate OrderState { get; set; }
        public virtual Ptype PayType { get; set; }
        public virtual ICollection<Orderdetail> Orderdetails { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
