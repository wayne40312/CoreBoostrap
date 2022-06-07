using System;
using System.Collections.Generic;

#nullable disable

namespace CoreBoostrap.Models
{
    public partial class Appointmentdetial
    {
        public int No { get; set; }
        public int ClinicId { get; set; }
        public int AppointmentNo { get; set; }
        public int SeqNo { get; set; }
        public DateTime CreateDatm { get; set; }
        public int MemId { get; set; }
        public int StatueId { get; set; }
        public string TreatmentNote { get; set; }

        public virtual Clinicdetial Clinic { get; set; }
        public virtual Member Mem { get; set; }
        public virtual Statue Statue { get; set; }
    }
}
