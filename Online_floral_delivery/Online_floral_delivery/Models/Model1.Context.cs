﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class floral_deliveryEntities8 : DbContext
    {
        public floral_deliveryEntities8()
            : base("name=floral_deliveryEntities8")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<category> categories { get; set; }
        public virtual DbSet<contact> contacts { get; set; }
        public virtual DbSet<product> products { get; set; }
        public virtual DbSet<registeration> registerations { get; set; }
        public virtual DbSet<cart> carts { get; set; }
        public virtual DbSet<billingg> billinggs { get; set; }
    }
}
