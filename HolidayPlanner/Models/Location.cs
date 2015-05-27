namespace HolidayPlanner.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Location")]
    public partial class Location
    {
        public int LocationId { get; set; }

        [Required]
        [StringLength(50)]
        public string LocationName { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public int HotelId { get; set; }

        public virtual Hotel Hotel { get; set; }
    }
}
