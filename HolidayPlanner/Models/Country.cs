namespace HolidayPlanner.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("Country")]
    public partial class Country
    {
        public int CountryId { get; set; }

        [StringLength(50)]
        public string CountryName { get; set; }

        public SelectList CountryList { get; set; } 
    }
}
