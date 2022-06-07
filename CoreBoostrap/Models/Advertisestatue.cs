using System;
using System.Collections.Generic;

#nullable disable

namespace CoreBoostrap.Models
{
    public partial class Advertisestatue
    {
        public Advertisestatue()
        {
            Advertises = new HashSet<Advertise>();
        }

        public int AdStatueId { get; set; }
        public string AdStatue { get; set; }

        public virtual ICollection<Advertise> Advertises { get; set; }
    }
}
