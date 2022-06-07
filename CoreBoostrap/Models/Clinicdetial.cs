using System;
using System.Collections.Generic;

#nullable disable

namespace CoreBoostrap.Models
{
    public partial class Clinicdetial
    {
        public Clinicdetial()
        {
            Appointmentdetials = new HashSet<Appointmentdetial>();
        }

        public int ClinicId { get; set; }
        public int DrId { get; set; }
        public int DepId { get; set; }
        public int DiaTimeId { get; set; }
        public int? Online { get; set; }
        public int RoomId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int? LimitNum { get; set; }
        public string ClinicNote { get; set; }

        public virtual Department Dep { get; set; }
        public virtual Diagnosistime DiaTime { get; set; }
        public virtual Doctor Dr { get; set; }
        public virtual Clinicroom Room { get; set; }
        public virtual ICollection<Appointmentdetial> Appointmentdetials { get; set; }
    }
}
