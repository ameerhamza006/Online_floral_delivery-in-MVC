//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Online_floral_delivery.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class billingg
    {
        public int bill_id { get; set; }
        public Nullable<int> bill_fk_reg { get; set; }
        public string bill_firstname { get; set; }
        public string bill_lastname { get; set; }
        public string bill_number { get; set; }
        public string bill_email { get; set; }
        public string bill_city { get; set; }
        public string bill_country { get; set; }
        public string bill_street { get; set; }
        public string bill_address { get; set; }
        public string bill_postcode { get; set; }
        public string bill_payment { get; set; }
        public Nullable<System.DateTime> bill_date { get; set; }
    
        public virtual registeration registeration { get; set; }
    }
}
