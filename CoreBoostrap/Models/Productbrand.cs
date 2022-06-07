using System;
using System.Collections.Generic;

#nullable disable

namespace CoreBoostrap.Models
{
    public partial class Productbrand
    {
        public Productbrand()
        {
            Products = new HashSet<Product>();
        }

        public int ProductBrandId { get; set; }
        public string ProductBrandName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
