using System;
using System.Collections.Generic;

#nullable disable

namespace CoreBoostrap.Models
{
    public partial class Department
    {
        public Department()
        {
            Clinicdetials = new HashSet<Clinicdetial>();
            Doctordepartments = new HashSet<Doctordepartment>();
        }

        public int DepId { get; set; }
        public string DepName { get; set; }
        public int DepCatId { get; set; }

        public virtual Departmentcategory DepCat { get; set; }
        public virtual ICollection<Clinicdetial> Clinicdetials { get; set; }
        public virtual ICollection<Doctordepartment> Doctordepartments { get; set; }
    }
}
