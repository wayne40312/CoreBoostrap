using System;
using System.Collections.Generic;

#nullable disable

namespace CoreBoostrap.Models
{
    public partial class Doctorposition
    {
        public Doctorposition()
        {
            Doctors = new HashSet<Doctor>();
        }

        public int PosId { get; set; }
        public string PosName { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}
