namespace HolidayPlanner.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("State")]
    public partial class State
    {
        [StringLength(10)]
        public string StateId { get; set; }

        [StringLength(50)]
        public string StateName { get; set; }

        [Required]
        [StringLength(10)]
        public string CountryId { get; set; }
    }
}
