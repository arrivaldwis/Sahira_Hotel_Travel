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
    
    public partial class Hotel
    {
        public Hotel()
        {
            this.BookingHotels = new HashSet<BookingHotel>();
            this.BookingTrips = new HashSet<BookingTrip>();
            this.RoomTypes = new HashSet<RoomType>();
            this.TripPackages = new HashSet<TripPackage>();
        }
    
        public int id_hotel { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public int phone { get; set; }
        public int star { get; set; }
    
        public virtual ICollection<BookingHotel> BookingHotels { get; set; }
        public virtual ICollection<BookingTrip> BookingTrips { get; set; }
        public virtual ICollection<RoomType> RoomTypes { get; set; }
        public virtual ICollection<TripPackage> TripPackages { get; set; }
    }
}