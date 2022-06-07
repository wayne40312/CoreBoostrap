using System;
using System.Collections.Generic;

#nullable disable

namespace CoreBoostrap.Models
{
    public partial class Doctordepartment
    {
        public int No { get; set; }
        public int DrId { get; set; }
        public int DepId { get; set; }

        public virtual Department Dep { get; set; }
        public virtual Doctor Dr { get; set; }
    }
}
