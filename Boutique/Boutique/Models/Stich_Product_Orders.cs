//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Stich_Product_Orders
    {
        public int spo_id { get; set; }
        public Nullable<int> sp_id { get; set; }
        public Nullable<int> user_id { get; set; }
        public string spo_fullname { get; set; }
        public string spo_date { get; set; }
        public string spo_contactno { get; set; }
        public string spo_address { get; set; }
        public string spo_city { get; set; }
        public Nullable<int> spo_zipcode { get; set; }
        public Nullable<int> spo_reqstatus { get; set; }
    }
}
