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
    
    public partial class BookingHotel
    {
        public int id_booking { get; set; }
        public string id_customer { get; set; }
        public string id_hotel { get; set; }
        public int id_roomType { get; set; }
        public System.DateTime check_in_date { get; set; }
        public System.DateTime check_out_date { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual Hotel Hotel { get; set; }
        public virtual RoomType RoomType { get; set; }
    }
}
