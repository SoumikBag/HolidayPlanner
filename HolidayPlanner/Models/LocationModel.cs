using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HolidayPlanner.Models
{
    public class LocationModel
    {
        public LocationModel()
        {
            Hotels = new List<SelectListItem>();
        }

        [DisplayName("Hotel")]
        public int HotelId { get; set; }

        public string HotelName { get; set; }

        public int LocationId { get; set; }

        public string LocationName { get; set; }

        public float Latitude { get; set; }

        public float Longitude { get; set; }

        public IEnumerable<SelectListItem> Hotels { get; set; }
    }
}