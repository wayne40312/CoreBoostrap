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
        int MemID { get { return this.MemberOb.MemId; } 
                    set { this.MemberOb.MemId = value; } }

        string MemName { get { return this.MemberOb.MemName; } 
                         set { this.MemberOb.MemName = value; } }

        string MemPhone { get { return this.MemberOb.MemPhone; } 
                          set { this.MemberOb.MemPhone = value; } }

        int GenderId { get { return this.MemberOb.GenderId; } 
                     set { this.MemberOb.GenderId = value; } }

        string MemEmail { get { return this.MemberOb.MemEmail; } 
                          set { this.MemberOb.MemEmail = value; } }

        int CityId { get { return this.MemberOb.CityId; } 
                     set { this.MemberOb.CityId = value; } }

        string MemAddress  { get { return this.MemberOb.MemAddress; } 
                             set { this.MemberOb.MemAddress = value; } } 

        public string Gender { get; set; }

        public string City { get; set; }
    }
}
