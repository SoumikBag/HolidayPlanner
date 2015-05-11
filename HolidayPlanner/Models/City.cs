namespace HolidayPlanner.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("City")]
    public partial class City
    {
        public int CityId { get; set; }

        [StringLength(50)]
        public string CityName { get; set; }

        public int StateId { get; set; }

        public SelectList CityList { get; set; } 
    }
}
