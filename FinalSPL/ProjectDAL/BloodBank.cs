//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectDAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class BloodBank
    {
        public BloodBank()
        {
            this.BloodGroupStocks = new HashSet<BloodGroupStock>();
            this.Bookings = new HashSet<Booking>();
        }
    
        public string UserName { get; set; }
        public string CompanyName { get; set; }
        public string Password { get; set; }
        public string GovtRegNumber { get; set; }
        public string City { get; set; }
        public string AreaWithinCity { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
    
        public virtual ICollection<BloodGroupStock> BloodGroupStocks { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
