using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights_project
{
    public class CountryDAOMSSQL : ICountryDAO
    {
        public long Add(Country country)
        {
            //ALTER PROCEDURE[dbo].[ADD_COUNTRY]
            //@COUNTRY_NAME nvarchar(1000)
            //AS
            //INSERT into Countries(COUNTRY_NAME) values(@COUNTRY_NAME);
            //select ID from Countries

            long countryIdFromDB;
            using (SqlConnection connection = new SqlConnection(flightCenterConfig.CONNECTION_STRING))
            {
                using(SqlCommand cmd = new SqlCommand("ADD_COUNTRY", connection))
                {
                    cmd.Parameters.Add(new SqlParameter("@COUNTRY_NAME", country.CountryName));
                    connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    countryIdFromDB = (long)cmd.ExecuteScalar();
                }
                return countryIdFromDB;
            }
        }

        public Country Get(int id)
        {
            Country country = new Country();
            using (SqlConnection connection = new SqlConnection(flightCenterConfig.CONNECTION_STRING))
            {
                SqlCommand cmd = new SqlCommand("GET_COUNTRY_BY_ID", connection);
                cmd.Parameters.Add(new SqlParameter("@ID", id));

                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
                while (reader.Read() == true)
                {
                    country.ID = (long)reader["ID"];
                    country.CountryName = (string)reader["COUNTRY_NAME"];
                }
                return country;
            }
        }

        public Country GetCountryByName(string Name)
        {
            //ALTER PROCEDURE[dbo].[GET_COUNTRY_BY_NAME]
            //@NAME varchar
            //AS
            //select* from Countries where COUNTRY_NAME = @NAME;

            Country country = new Country();
            using (SqlConnection connection = new SqlConnection(flightCenterConfig.CONNECTION_STRING))
            {
                SqlCommand cmd = new SqlCommand("GET_COUNTRY_BY_NAME", connection);
                cmd.Parameters.Add(new SqlParameter("@NAME", Name));
                cmd.Connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
                while (reader.Read() == true)
                {
                    country.ID = (long)reader["ID"];
                    country.CountryName = (string)reader["COUNTRY_NAME"];
                    return country;
                }
                return null;
            }
        }

        public IList<Country> GetAll()
        {
            //ALTER PROCEDURE[dbo].[GET_ALL_COUNTRY]
            //AS
            //select* from Countries

           List<Country> List = new List<Country>();
            using (SqlConnection connection = new SqlConnection(flightCenterConfig.CONNECTION_STRING))
            {
                SqlCommand cmd = new SqlCommand("GET_ALL_COUNTRY", connection);
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
                while (reader.Read() == true)
                {
                    Country country = new Country();
                    country.ID = (long)reader["ID"];
                    country.CountryName = (string)reader["COUNTRY_NAME"];        
                    List.Add(country);
                }
                return List;
            }
        }

        public void Remove(Country country)
        {
            //ALTER PROCEDURE[dbo].[REMOVE_COUNTRY]
            //@ID bigint
            //AS
            //delete from Countries where id = @ID

            using (SqlConnection connection = new SqlConnection(flightCenterConfig.CONNECTION_STRING))
            {
                SqlCommand cmd = new SqlCommand("REMOVE_COUNTRY", connection);
                cmd.Parameters.Add(new SqlParameter("@ID", country.ID));
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                //cmd.EndExecuteNonQuery();   -----do i need this also if i use stored procedure?

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
            }
        }

        public void Update(Country country)
        {
            //ALTER PROCEDURE[dbo].[UPDATE_COUNTRY] @ID bigint, @COUNTRY_NAME VARCHAR(1000)
            //AS
            //update Countries
            //set COUNTRY_NAME = @COUNTRY_NAME
            //where ID = @ID

            using (SqlConnection connection = new SqlConnection(flightCenterConfig.CONNECTION_STRING))
            {
                SqlCommand cmd = new SqlCommand("UPDATE_COUNTRY", connection);
                cmd.Parameters.Add(new SqlParameter("@ID", country.ID));
                cmd.Parameters.Add(new SqlParameter("@COUNTRY_NAME", country.CountryName));
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                //cmd.EndExecuteNonQuery();   -----do i need this also if i use stored procedure?

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
            }
        }
    }
}
