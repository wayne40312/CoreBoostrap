using CoreBoostrap.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBoostrap.ViewModels
{
    public class MemberViewModel
    {
        
        public MemberViewModel() {
            this.MemberOb = new Member();
        }
        
        public Member MemberOb { get; set; }

        [Key]
        public int MemID { get { return this.MemberOb.MemId; } 
                    set { this.MemberOb.MemId = value; } }

        public string MemName { get { return this.MemberOb.MemName; } 
                         set { this.MemberOb.MemName = value; } }

        public string MemPhone { get { return this.MemberOb.MemPhone; } 
                          set { this.MemberOb.MemPhone = value; } }

        public int GenderId { get { return this.MemberOb.GenderId; } 
                     set { this.MemberOb.GenderId = value; } }

        public string MemEmail { get { return this.MemberOb.MemEmail; } 
                          set { this.MemberOb.MemEmail = value; } }

        public int CityId { get { return this.MemberOb.CityId; } 
                     set { this.MemberOb.CityId = value; } }

        public string MemAddress  { get { return this.MemberOb.MemAddress; } 
                             set { this.MemberOb.MemAddress = value; } }

        public DateTime MemBrith {
            get { return this.MemberOb.MemBrith; }
            set { this.MemberOb.MemBrith = value; }
        }

        public string MemIdentifyNo {
            get { return this.MemberOb.MemIdentifyNo; }
            set { this.MemberOb.MemIdentifyNo = value; }
        }

        public string MemPassword {
            get { return this.MemberOb.MemPassword; }
            set { this.MemberOb.MemPassword = value; }
        }
        public string Gender { get; set; }

        public string City { get; set; }
    }
}
