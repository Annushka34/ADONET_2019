//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _08_DBFirst
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sales
    {
        public int Id { get; set; }
        public int ShopId { get; set; }
        public int BookId { get; set; }
        public System.DateTime DateSale { get; set; }
        public int Amount { get; set; }
        public decimal SalePrice { get; set; }
    
        public virtual Book Book { get; set; }
        public virtual Shop Shop { get; set; }
    }
}
