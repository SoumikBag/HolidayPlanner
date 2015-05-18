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
        [StringLength(50)]
        public string BookingId { get; set; }

        public int UserId { get; set; }

        public string ClientMobileNumber { get; set; }

        [StringLength(100)]
        public string ClientEmailId { get; set; }

        public int HotelId { get; set; }

        [DataType(DataType.Date)]
        public DateTime? CheckInDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? CheckOutDate { get; set; }

        public int? NoOfAdults { get; set; }

        public int? NoOfChildren { get; set; }

        [StringLength(500)]
        public string Message { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TotalAmount { get; set; }

        public virtual Hotel Hotel { get; set; }
    }
}
