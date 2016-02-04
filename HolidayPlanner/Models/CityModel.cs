using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HolidayPlanner.Models
{
    public class CityModel
    {
        public CityModel()
        {
            States = new List<SelectListItem>();
        }

        [DisplayName("State")]
        public string StateId { get; set; }
        public string StateName { get; set; }

        public string CityId { get; set; }
        public string CityName { get; set; }
        public IEnumerable<SelectListItem> States { get; set; }
    }

}