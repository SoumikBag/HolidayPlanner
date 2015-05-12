namespace HolidayPlanner.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Facility
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string FacilityId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int HotelId { get; set; }

        [StringLength(100)]
        public string FacilitiesType { get; set; }

        public virtual Hotel Hotel { get; set; }
    }
}
