using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace HolidayPlanner.Models
{
    public class InfoViewModel 
    {
        public string Policies;
        public string FoodDetails;
        public int? Rate;
        public int? RoomCapacity;
        public string RoomDetails;
        public string FacilityType;
        public string FacilityDetails;
        public string ReviewDetails;
        public int? Rating;

        public IEnumerable<Hotel> Hotel { get; set; }
        public IEnumerable<Room> Room { get; set; }
        public IEnumerable<Facility> Facility { get; set; }
        public IEnumerable<Review> Review { get; set; }
        
    }
}