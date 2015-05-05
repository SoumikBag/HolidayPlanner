namespace HolidayPlanner.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Booking")]
    public partial class Booking
    {
        public int BookingId { get; set; }

        public int UserId { get; set; }

        public int? ClientMobileNumber { get; set; }

        [StringLength(50)]
        public string ClientEmailId { get; set; }

        public int HotelId { get; set; }

        public DateTime? CheckInDate { get; set; }

        public DateTime? CheckOutDate { get; set; }

        public int? NoOfAdults { get; set; }

        public int? NoOfChildren { get; set; }

        [StringLength(50)]
        public string Message { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TotalAmount { get; set; }

        public virtual Hotel Hotel { get; set; }
    }
}
