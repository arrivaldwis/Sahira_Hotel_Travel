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
    
    public partial class Region
    {
        public Region()
        {
            this.TripDestinations = new HashSet<TripDestination>();
        }
    
        public int id_region { get; set; }
        public string name { get; set; }
    
        public virtual ICollection<TripDestination> TripDestinations { get; set; }
    }
}
