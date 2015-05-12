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
            Reviews = new HashSet<Review>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int HotelId { get; set; }

        [StringLength(50)]
        public string HotelName { get; set; }

        [StringLength(2000)]
        public string HotelDetails { get; set; }

        [Required]
        [StringLength(10)]
        public string CityId { get; set; }

        [StringLength(500)]
        public string Address { get; set; }

        [Required]
        [StringLength(10)]
        public string HTypeId { get; set; }

        [StringLength(1000)]
        public string HotelPolices { get; set; }

        [StringLength(1000)]
        public string FoodDetails { get; set; }

        [StringLength(200)]
        public string FacilitiesAv { get; set; }

        [StringLength(200)]
        public string RoomsAv { get; set; }

        public virtual HotelType HotelType { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }
}
