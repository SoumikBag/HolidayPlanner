using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HolidayPlanner.Models
{
    public class FacilityModel
    {
        public FacilityModel()
        {
            Hotels = new List<SelectListItem>();
        }

        [DisplayName("Hotel")]
        public int HotelId { get; set; }

        public string HotelName { get; set; }


        public string FacilityId { get; set; }

        public string FacilitiesType { get; set; }

        public IEnumerable<SelectListItem> Hotels { get; set; }
    }
}