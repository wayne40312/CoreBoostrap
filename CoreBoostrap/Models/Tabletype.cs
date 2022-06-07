using System;
using System.Collections.Generic;

#nullable disable

namespace CoreBoostrap.Models
{
    public partial class Tabletype
    {
        public Tabletype()
        {
            Wishlists = new HashSet<Wishlist>();
        }

        public int TypeId { get; set; }
        public string TypeName { get; set; }

        public virtual ICollection<Wishlist> Wishlists { get; set; }
    }
}
