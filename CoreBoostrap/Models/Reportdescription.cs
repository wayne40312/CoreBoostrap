using System;
using System.Collections.Generic;

#nullable disable

namespace CoreBoostrap.Models
{
    public partial class Reportdescription
    {
        public Reportdescription()
        {
            Articalcomments = new HashSet<Articalcomment>();
            Reviews = new HashSet<Review>();
        }

        public int ReportId { get; set; }
        public string ReportDescription1 { get; set; }

        public virtual ICollection<Articalcomment> Articalcomments { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
