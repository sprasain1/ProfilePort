//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DealerPortalCRM
{
    using System;

    public partial class StateAdjustment
    {
        public int ID { get; set; }
        public decimal DiscountAdj { get; set; }
        public decimal LTVAdj { get; set; }
        public decimal MaxStateAPR { get; set; }
        public decimal GapCap { get; set; }
        public int CreatedByID { get; set; }
        public int ModifiedByID { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public Nullable<int> StateCode_ID { get; set; }
        public Nullable<int> Organization_ID { get; set; }
    
        public virtual StateCode StateCode { get; set; }
    }
}
