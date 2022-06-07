using System;
using System.Collections.Generic;

#nullable disable

namespace CoreBoostrap.Models
{
    public partial class Advertise
    {
        public int No { get; set; }
        public int AdminId { get; set; }
        public string AdTitle { get; set; }
        public string AdContent { get; set; }
        public string AdPicturePath { get; set; }
        public string AdUrl { get; set; }
        public int AdStatueId { get; set; }
        public int? AdSotrNo { get; set; }

        public virtual Advertisestatue AdStatue { get; set; }
        public virtual Administrator Admin { get; set; }
    }
}
