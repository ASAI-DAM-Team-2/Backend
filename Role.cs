//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AllergyApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class Role
    {
        public int role_id { get; set; }
        public string name { get; set; }
    
        public virtual Role Role1 { get; set; }
        public virtual Role Role2 { get; set; }
    }
}
