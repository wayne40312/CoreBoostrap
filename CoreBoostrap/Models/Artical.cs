using System;
using System.Collections.Generic;

#nullable disable

namespace CoreBoostrap.Models
{
    public partial class Artical
    {
        public Artical()
        {
            Articalcomments = new HashSet<Articalcomment>();
        }

        public int ArticleId { get; set; }
        public int DrId { get; set; }
        public string ArticleTitle { get; set; }
        public byte[] ArticleImage { get; set; }
        public string ArticleContent { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual Doctor Dr { get; set; }
        public virtual ICollection<Articalcomment> Articalcomments { get; set; }
    }
}
