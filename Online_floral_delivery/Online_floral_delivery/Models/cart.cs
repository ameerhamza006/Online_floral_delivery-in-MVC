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
    
    public partial class cart
    {
        public int cart_id { get; set; }
        public Nullable<int> cart_qty { get; set; }
        public Nullable<int> cart_fk_reg { get; set; }
        public Nullable<int> cart_fk_pro { get; set; }
    
        public virtual product product { get; set; }
        public virtual registeration registeration { get; set; }
    }
}
