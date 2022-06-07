using System;
using System.Collections.Generic;

#nullable disable

namespace CoreBoostrap.Models
{
    public partial class Departmentcategory
    {
        public Departmentcategory()
        {
            Clinicrooms = new HashSet<Clinicroom>();
            Departments = new HashSet<Department>();
        }

        public int DepCatId { get; set; }
        public string DepCatName { get; set; }

        public virtual ICollection<Clinicroom> Clinicrooms { get; set; }
        public virtual ICollection<Department> Departments { get; set; }
    }
}
