using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HolidayPlanner.Models
{
    public class HotelModel
    {
        public HotelModel()
        {
            HotelTypes = new List<SelectListItem>();
            Cities = new List<SelectListItem>();
            
            //Facilities = new List<SelectListItem>();
        }

        [DisplayName("City")]
        public string CityId { get; set; }

        public string CityName { get; set; }

        [DisplayName("HotelType")]
        public string HTypeId { get; set; }

        public string HotelType { get; set; }

        [DisplayName("Hotel")]
        public int HotelId { get; set; }

        public string HotelName { get; set; }

        public string HotelDetails { get; set; }

        public string Address { get; set; }

        public string HotelPolices { get; set; }

        public string FoodDetails { get; set; }

        public int Distance { get; set; }

        public string Budget { get; set; }


      

        
        public IEnumerable<SelectListItem> HotelTypes { get; set; }
        public IEnumerable<SelectListItem> Cities { get; set; }

        public IEnumerable<SelectListItem> Hotels { get; set; }

    }
}