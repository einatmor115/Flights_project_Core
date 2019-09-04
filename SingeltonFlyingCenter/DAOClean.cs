using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights_project
{
    public class DAOClean
    {
        public void CleanFlithsAndTickets()
        {
            using (SqlConnection connection = new SqlConnection(flightCenterConfig.CONNECTION_STRING))
            {
                SqlCommand cmd = new SqlCommand("DO_CLEANING_JOB", connection);             
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
                cmd.Connection.Close();
            }
        }
    }
}
