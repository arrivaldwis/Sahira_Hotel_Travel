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
    
    public partial class TripPackage
    {
        public TripPackage()
        {
            this.BookingTrips = new HashSet<BookingTrip>();
            this.TripPackageDetails = new HashSet<TripPackageDetail>();
            this.TripSchedules = new HashSet<TripSchedule>();
        }
    
        public int id_package { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string id_hotel { get; set; }
        public int id_roomType { get; set; }
        public double totalPrice { get; set; }
        public int dayOfTrip { get; set; }
    
        public virtual ICollection<BookingTrip> BookingTrips { get; set; }
        public virtual Hotel Hotel { get; set; }
        public virtual RoomType RoomType { get; set; }
        public virtual ICollection<TripPackageDetail> TripPackageDetails { get; set; }
        public virtual ICollection<TripSchedule> TripSchedules { get; set; }
    }
}
