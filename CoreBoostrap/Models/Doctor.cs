using System;
using System.Collections.Generic;

#nullable disable

namespace CoreBoostrap.Models
{
    public partial class Doctor
    {
        public Doctor()
        {
            Articalcomments = new HashSet<Articalcomment>();
            Articals = new HashSet<Artical>();
            Clinicdetials = new HashSet<Clinicdetial>();
            Doctordepartments = new HashSet<Doctordepartment>();
            Reviews = new HashSet<Review>();
        }

        public int DrId { get; set; }
        public string DrName { get; set; }
        public int PosId { get; set; }
        public string DrEdu { get; set; }
        public string DrExp { get; set; }
        public string DrSkill { get; set; }
        public string DrAccount { get; set; }
        public string DrPassword { get; set; }
        public string DrPhotoPath { get; set; }

        public virtual Doctorposition Pos { get; set; }
        public virtual ICollection<Articalcomment> Articalcomments { get; set; }
        public virtual ICollection<Artical> Articals { get; set; }
        public virtual ICollection<Clinicdetial> Clinicdetials { get; set; }
        public virtual ICollection<Doctordepartment> Doctordepartments { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
