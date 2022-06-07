using System;
using System.Collections.Generic;

#nullable disable

namespace CoreBoostrap.Models
{
    public partial class Park
    {
        public Park()
        {
            Clinicrooms = new HashSet<Clinicroom>();
        }

        public int ParkId { get; set; }
        public string ParkName { get; set; }

        public virtual ICollection<Clinicroom> Clinicrooms { get; set; }
    }
}
