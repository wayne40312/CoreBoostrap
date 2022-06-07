using System;
using System.Collections.Generic;

#nullable disable

namespace CoreBoostrap.Models
{
    public partial class Wishlist
    {
        public int No { get; set; }
        public int MemId { get; set; }
        public int ProductId { get; set; }
        public int? ProductAmount { get; set; }
        public int TypeId { get; set; }

        public virtual Member Mem { get; set; }
        public virtual Product Product { get; set; }
        public virtual Tabletype Type { get; set; }
    }
}
