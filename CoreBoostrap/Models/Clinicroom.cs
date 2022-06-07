using System;
using System.Collections.Generic;

#nullable disable

namespace CoreBoostrap.Models
{
    public partial class Clinicroom
    {
        public Clinicroom()
        {
            Clinicdetials = new HashSet<Clinicdetial>();
        }

        public int RoomId { get; set; }
        public int DepCatId { get; set; }
        public string RoomName { get; set; }
        public int ParkId { get; set; }

        public virtual Departmentcategory DepCat { get; set; }
        public virtual Park Park { get; set; }
        public virtual ICollection<Clinicdetial> Clinicdetials { get; set; }
    }
}
