//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Surcharge
{
    using System;
    using System.Collections.Generic;
    
    public partial class Citizen
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Citizen()
        {
            this.PaymentDetails = new HashSet<PaymentDetail>();
        }
    
        public int CitizenID { get; set; }
        public string CitizenshipNo { get; set; }
        public string CitizenOccupation { get; set; }
        public string CitizenAdress { get; set; }
        public string CitizenPhoneNo { get; set; }
        public string CitizenMail { get; set; }
        public string CitizenPassword { get; set; }
        public Nullable<decimal> CitizenBalance { get; set; }
        public string NameSurname { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PaymentDetail> PaymentDetails { get; set; }
    }
}
