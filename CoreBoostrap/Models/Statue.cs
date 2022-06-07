using System;
using System.Collections.Generic;

#nullable disable

namespace CoreBoostrap.Models
{
    public partial class Statue
    {
        public Statue()
        {
            Appointmentdetials = new HashSet<Appointmentdetial>();
        }

        public int StatueId { get; set; }
        public string Statue1 { get; set; }

        public virtual ICollection<Appointmentdetial> Appointmentdetials { get; set; }
    }
}
