using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;

namespace HolidayPlanner.Models
{
    public class CountryContext
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CountryContext"].ToString());

        public IEnumerable<Country> GetCountryList()
        {

            string query = "SELECT [CountryId],[CountryName]FROM [HolidayPlanner].[dbo].[Country]";
            var result = con.Query<Country>(query);
            return result;
        }
    }
}