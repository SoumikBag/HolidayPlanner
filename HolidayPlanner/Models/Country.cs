namespace HolidayPlanner.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Country")]
    public partial class Country
    {
        [StringLength(10)]
        public string CountryId { get; set; }

        [StringLength(50)]
        public string CountryName { get; set; }
    }
}
