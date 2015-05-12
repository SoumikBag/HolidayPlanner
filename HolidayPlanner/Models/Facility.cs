namespace HolidayPlanner.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Facility
    {
        [StringLength(10)]
        public string FacilityId { get; set; }

        [StringLength(100)]
        public string FacilitiesType { get; set; }
    }
}
