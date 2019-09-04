using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights_project.DAO
{
    public class AdminDAOMSSQL
    {
        public void DeleteAllTablesInfo()
        {
            //create PROCEDURE[dbo].[DELETE_ALL_TABLES]
            //AS
            //delete from AirlineCompanies
            //delete from Countries
            //delete from Customers
            //delete from Flights
            //delete from Tickets

            using (SqlConnection connection = new SqlConnection(flightCenterConfig.CONNECTION_STRING))
            {
                SqlCommand cmd = new SqlCommand("DELETE_ALL_TABLES", connection);
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
            }
        }
    }
}
