using System;
using System.Collections.Generic;

#nullable disable

namespace CoreBoostrap.Models
{
    public partial class Administrator
    {
        public Administrator()
        {
            Advertises = new HashSet<Advertise>();
            News = new HashSet<News>();
        }

        public int AdminId { get; set; }
        public string AdminName { get; set; }
        public string AdminAccount { get; set; }
        public string AdminPassword { get; set; }

        public virtual ICollection<Advertise> Advertises { get; set; }
        public virtual ICollection<News> News { get; set; }
    }
}
