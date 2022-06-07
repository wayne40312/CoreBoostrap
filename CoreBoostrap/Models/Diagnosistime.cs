using System;
using System.Collections.Generic;

#nullable disable

namespace CoreBoostrap.Models
{
    public partial class Diagnosistime
    {
        public Diagnosistime()
        {
            Clinicdetials = new HashSet<Clinicdetial>();
        }

        public int DiaTimeId { get; set; }
        public string DiaTime { get; set; }

        public virtual ICollection<Clinicdetial> Clinicdetials { get; set; }
    }
}
