using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace HolidayPlanner.Models
{
    public class InfoViewModel
    {
        public string HotelDetails;
        public string Policies;
        public string FoodDetails;
        public string RoomType;
        public string Rate;
        public string RoomCapacity;
        public string RoomDetails;
        public string FacilityType;
        public string FacilityDetails;
        public string ReviewDetails;
        public double? Rating;
        public string CityId;
        public SelectList CountryList { get; set; }

        public IEnumerable<Hotel> Hotel { get; set; }
        public IEnumerable<Room> Room { get; set; }
        public IEnumerable<Facility> Facility { get; set; }
        public IEnumerable<Review> Review { get; set; }
        public IEnumerable<Country> Country { get; set; }
        

    }
}