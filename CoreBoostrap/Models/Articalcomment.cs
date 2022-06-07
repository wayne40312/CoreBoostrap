using System;
using System.Collections.Generic;

#nullable disable

namespace CoreBoostrap.Models
{
    public partial class Articalcomment
    {
        public int No { get; set; }
        public int ArticleId { get; set; }
        public int? MemId { get; set; }
        public int? DrId { get; set; }
        public string Comment { get; set; }
        public DateTime CreateDate { get; set; }
        public byte? Reported { get; set; }
        public int? ReportId { get; set; }

        public virtual Artical Article { get; set; }
        public virtual Doctor Dr { get; set; }
        public virtual Member Mem { get; set; }
        public virtual Reportdescription Report { get; set; }
    }
}
