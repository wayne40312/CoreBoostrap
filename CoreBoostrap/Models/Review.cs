using System;
using System.Collections.Generic;

#nullable disable

namespace CoreBoostrap.Models
{
    public partial class Review
    {
        public int No { get; set; }
        public int MemId { get; set; }
        public int? OrderId { get; set; }
        public int? DrId { get; set; }
        public int? ProductId { get; set; }
        public int Ranking { get; set; }
        public string Comment { get; set; }
        public DateTime CreateDate { get; set; }
        public int? Reported { get; set; }
        public int? ReportId { get; set; }

        public virtual Doctor Dr { get; set; }
        public virtual Member Mem { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
        public virtual Reportdescription Report { get; set; }
    }
}
