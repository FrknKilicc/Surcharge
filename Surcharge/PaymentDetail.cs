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
    
    public partial class PaymentDetail
    {
        public int PaymentDetailID { get; set; }
        public Nullable<decimal> TaxAmount { get; set; }
        public Nullable<decimal> Interest { get; set; }
        public Nullable<decimal> TotalPayment { get; set; }
        public Nullable<int> CitizenID { get; set; }
        public Nullable<int> TaxID { get; set; }
        public Nullable<System.DateTime> PaymentDate { get; set; }
    
        public virtual Citizen Citizen { get; set; }
        public virtual Tax Tax { get; set; }
    }
}
