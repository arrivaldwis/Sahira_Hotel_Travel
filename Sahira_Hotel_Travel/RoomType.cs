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
    
    public partial class RoomType
    {
        public RoomType()
        {
            this.BookingHotels = new HashSet<BookingHotel>();
            this.BookingTrips = new HashSet<BookingTrip>();
            this.TripPackages = new HashSet<TripPackage>();
        }
    
        public int id_roomType { get; set; }
        public int id_hotel { get; set; }
        public string name { get; set; }
        public int numOfRoom { get; set; }
        public double normalPrice { get; set; }
        public Nullable<double> packagePrice { get; set; }
    
        public virtual ICollection<BookingHotel> BookingHotels { get; set; }
        public virtual ICollection<BookingTrip> BookingTrips { get; set; }
        public virtual Hotel Hotel { get; set; }
        public virtual ICollection<TripPackage> TripPackages { get; set; }
    }
}