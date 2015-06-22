using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HolidayPlanner.Models
{
    public class RoomModel
    {
        public RoomModel()
        {
            Hotels = new List<SelectListItem>();
        }

        [DisplayName("Hotel")]
        public int HotelId { get; set; }

        public string HotelName { get; set; }

        public string RoomId { get; set; }

        public string RoomType { get; set; }

        public string RoomCapacity { get; set; }

        public string RoomDetails { get; set; }

        public string Rate { get; set; }

        public IEnumerable<SelectListItem> Hotels { get; set; }
    }
}