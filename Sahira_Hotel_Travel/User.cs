//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sahira_Hotel_Travel
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public int id_user { get; set; }
        public int id_userType { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string name { get; set; }
    
        public virtual UserType UserType { get; set; }
    }
}
