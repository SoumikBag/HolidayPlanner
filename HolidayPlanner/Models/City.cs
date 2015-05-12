namespace HolidayPlanner.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("City")]
    public partial class City
    {
        [StringLength(10)]
        public string CityId { get; set; }

        [StringLength(50)]
        public string CityName { get; set; }

        [Required]
        [StringLength(10)]
        public string StateId { get; set; }
    }
}
