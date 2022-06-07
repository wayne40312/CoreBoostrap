using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace CoreBoostrap.Models
{
    public partial class Member
    {
        public Member()
        {
            Appointmentdetials = new HashSet<Appointmentdetial>();
            Articalcomments = new HashSet<Articalcomment>();
            Orders = new HashSet<Order>();
            Reviews = new HashSet<Review>();
            Wishlists = new HashSet<Wishlist>();
        }

        public int MemId { get; set; }
        public string MemIdentifyNo { get; set; }
        public string MemName { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy年MM月dd日}")]
        public DateTime MemBrith { get; set; }
        public int GenderId { get; set; }
        public string MemPhone { get; set; }
        public string MemEmail { get; set; }
        public string MemPassword { get; set; }
        public int CityId { get; set; }
        public string MemAddress { get; set; }

        public virtual City City { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual ICollection<Appointmentdetial> Appointmentdetials { get; set; }
        public virtual ICollection<Articalcomment> Articalcomments { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Wishlist> Wishlists { get; set; }
    }
}
