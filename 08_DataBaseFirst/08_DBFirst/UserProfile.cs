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
    
    public partial class UserProfile
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    
        public virtual Author Author { get; set; }
    }
}
