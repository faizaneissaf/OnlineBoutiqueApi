﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Boutique.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class OnlineBoutiqueEntities2 : DbContext
    {
        public OnlineBoutiqueEntities2()
            : base("name=OnlineBoutiqueEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Designer> Designers { get; set; }
        public virtual DbSet<Group_Members> Group_Members { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Product_Orders> Product_Orders { get; set; }
        public virtual DbSet<Recomended_Products> Recomended_Products { get; set; }
        public virtual DbSet<Stich_Product_Orders> Stich_Product_Orders { get; set; }
        public virtual DbSet<Stich_Products> Stich_Products { get; set; }
        public virtual DbSet<Unstich_Product_Orders> Unstich_Product_Orders { get; set; }
        public virtual DbSet<Unstich_Products> Unstich_Products { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}