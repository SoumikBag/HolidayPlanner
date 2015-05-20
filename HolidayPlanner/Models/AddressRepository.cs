using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HolidayPlanner.Models
{
    public class AddressRepository
    {
        private DataClasses1DataContext _dataContext;

        public AddressRepository()
        {
            _dataContext = new DataClasses1DataContext();
        }

        public IList<Country> GetAllCountries()
        {
            var query = from countries in _dataContext.Countries
                        select countries;
            var content = query.ToList<Country>();
            return content;
        }
        public IList<State> GetAllStatesByCountryId(string countryId)
        {
            
            var query = from states in _dataContext.States
                        where states.CountryId == countryId
                        select states;
            var content = query.ToList<State>();
            return content;
        }

        public IList<City> GetAllCitysByStateId(string stateId)
        {

            var query = from citys in _dataContext.Cities
                        where citys.StateId == stateId
                        select citys;
            var content = query.ToList<City>();
            return content;
        }
    }
}