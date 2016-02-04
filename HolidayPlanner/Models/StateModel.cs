using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HolidayPlanner.Models
{
    public class StateModel
    {
        public StateModel()
        {
            Countries = new List<SelectListItem>();
        }

        [DisplayName("Country")]
        public string CountryId { get; set; }
        public string CountryName { get; set; }

        public string StateId { get; set; }

        public string StateName { get; set; }
        public IEnumerable<SelectListItem> Countries { get; set; }
    }
}