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
    
    public partial class BookingTrip
    {
        public int id_booking_trip { get; set; }
        public string id_customer { get; set; }
        public int id_package { get; set; }
        public int id_roomType { get; set; }
        public int id_hotel { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual Hotel Hotel { get; set; }
        public virtual RoomType RoomType { get; set; }
        public virtual TripPackage TripPackage { get; set; }
    }
}
