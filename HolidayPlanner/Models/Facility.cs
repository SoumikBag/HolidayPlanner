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
        public int FId { get; set; }

        [StringLength(50)]
        public string FacilitiesType { get; set; }

        [StringLength(50)]
        public string FacilitiesDetails { get; set; }

        public virtual ICollection<Hotel> Hotels { get; set; }


    }
}
