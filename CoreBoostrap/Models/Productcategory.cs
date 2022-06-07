using System;
using System.Collections.Generic;

#nullable disable

namespace CoreBoostrap.Models
{
    public partial class Productcategory
    {
        public Productcategory()
        {
            Products = new HashSet<Product>();
        }

        public int ProductCatId { get; set; }
        public string ProductCatName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
