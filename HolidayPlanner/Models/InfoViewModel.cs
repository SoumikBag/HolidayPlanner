using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace HolidayPlanner.Models
{
    public class InfoViewModel 
    {
        public int? Rate;
        public int? RoomCapacity;
        public string RoomDetails;
        public string FacilityType;
        public string FacilityDetails;

        public IEnumerable<Hotel> Hotel { get; set; }
        public IEnumerable<Room> Room { get; set; }
        public IEnumerable<Facility> Facility { get; set; }

    }
}