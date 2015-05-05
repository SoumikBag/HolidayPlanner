namespace HolidayPlanner.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Hotel")]
    public partial class Hotel
    {
        public Hotel()
        {
            Bookings = new HashSet<Booking>();
            Reviews = new HashSet<Review>();
        }

        public int HotelId { get; set; }

        [StringLength(50)]
        public string HotelName { get; set; }

        public int CityId { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        public int HTypeId { get; set; }

        [StringLength(50)]
        public string HotelPolices { get; set; }

        [StringLength(50)]
        public string FoodDetails { get; set; }

        public int RoomId { get; set; }

        public int FId { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }

        public virtual Facility Facility { get; set; }

        public virtual HotelType HotelType { get; set; }

        public virtual Room Room { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }
}
