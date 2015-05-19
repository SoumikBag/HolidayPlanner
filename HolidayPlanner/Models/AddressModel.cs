using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using System.Web.WebPages.Html;

namespace HolidayPlanner.Models
{
    public class AddressModel
    {
        public AddressModel()
        {
            AvailableCountries = new List<SelectListItem>();
            AvailableStates = new List<SelectListItem>();
            AvailableCities = new List<SelectListItem>();
        }
        [Display(Name = "Country")]
        public string CountryId { get; set; }
        public IList<SelectListItem> AvailableCountries { get; set; }
        [Display(Name = "State")]
        public string StateId { get; set; }
        public IList<SelectListItem> AvailableStates { get; set; }
        [Display(Name = "City")]
        public string CityId { get; set; }
        public IList<SelectListItem> AvailableCities { get; set; }
    }
}