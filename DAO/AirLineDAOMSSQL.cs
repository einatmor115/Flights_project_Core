using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights_project
{
    public class AirLineDAOMSSQL : IAirLineDAO
    {
        public long Add(AirlineCompany airlineCompany)
        {
            //ALTER PROCEDURE[dbo].[ADD_AIRLINE_COMPANY] @AIRLINE_NAME varchar(1000), @USER_NAME varchar(1000), @PASSWORD varchar(1000), @COUNTRY_CODE bigint
            //AS
            //insert into AirlineCompanies(AIRLINE_NAME, USER_NAME, PASSWORD , COUNTRY_CODE)
            //VALUES
            //(@AIRLINE_NAME, @USER_NAME, @PASSWORD, @COUNTRY_CODE);
            //select ID from AirlineCompanies
            long airlineCompanyIdFromDB;
            using (SqlConnection connection = new SqlConnection(flightCenterConfig.CONNECTION_STRING))
            {
                SqlCommand cmd = new SqlCommand("ADD_AIRLINE_COMPANY", connection);
                cmd.Parameters.Add(new SqlParameter("@AIRLINE_NAME", airlineCompany.AirlineName));
                cmd.Parameters.Add(new SqlParameter("@USER_NAME", airlineCompany.UserName));
                cmd.Parameters.Add(new SqlParameter("@PASSWORD", airlineCompany.Password));
                cmd.Parameters.Add(new SqlParameter("@COUNTRY_CODE", airlineCompany.CountryCode));
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;               
                airlineCompanyIdFromDB = (long)cmd.ExecuteScalar();
            }

            return (long)airlineCompanyIdFromDB;
        }

        public AirlineCompany Get(int id)
        {
            //ALTER PROCEDURE[dbo].[GET_AIRLINE_COMPANY_BY_ID]
            //@ID varchar(1000)
            //AS
            //select* from AirlineCompanies where ID = @ID

            AirlineCompany air = new AirlineCompany();
            using (SqlConnection connection = new SqlConnection(flightCenterConfig.CONNECTION_STRING))
            {
                SqlCommand cmd = new SqlCommand("GET_AIRLINE_COMPANY_BY_ID", connection);
                cmd.Parameters.Add(new SqlParameter("@ID", id));

                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
                while (reader.Read() == true)
                {
                    air.ID = (long)reader["ID"];
                    air.AirlineName = (string)reader["AIRLINE_NAME"];
                    air.UserName = (string)reader["USER_NAME"];
                    air.Password = (string)reader["PASSWORD"];
                    air.CountryCode = (long)reader["COUNTRY_CODE"];
                }
                return air;
            }
        }

        public AirlineCompany GetByName(int id)
        {
            //ALTER PROCEDURE[dbo].[GET_AIRLINE_COMPANY_BY_ID]
            //@ID varchar(1000)
            //AS
            //select* from AirlineCompanies where ID = @ID

            AirlineCompany air = new AirlineCompany();
            using (SqlConnection connection = new SqlConnection(flightCenterConfig.CONNECTION_STRING))
            {
                SqlCommand cmd = new SqlCommand("GET_AIRLINE_COMPANY_BY_ID", connection);
                cmd.Parameters.Add(new SqlParameter("@ID", id));

                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
                while (reader.Read() == true)
                {
                    air.ID = (long)reader["ID"];
                    air.AirlineName = (string)reader["AIRLINE_NAME"];
                    air.UserName = (string)reader["USER_NAME"];
                    air.Password = (string)reader["PASSWORD"];
                    air.CountryCode = (long)reader["COUNTRY_CODE"];
                }
                return air;
            }
        }

        public List<AirlineCompany> GetAirLineByCountry(int country_code)
        {
            //ALTER PROCEDURE[dbo].[GET_AIR_LINE_BY_COUNTRY]@COUNTRY_CODE bigint
            //AS
            //select* from AirlineCompanies where COUNTRY_CODE = @COUNTRY_CODE

            List<AirlineCompany> List = new List<AirlineCompany>();
            using (SqlConnection connection = new SqlConnection(flightCenterConfig.CONNECTION_STRING))
            {
                SqlCommand cmd = new SqlCommand("GET_AIR_LINE_BY_COUNTRY", connection);
                cmd.Parameters.Add(new SqlParameter("@COUNTRY_CODE", country_code));

                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
                while (reader.Read() == true)
                {
                    AirlineCompany air = new AirlineCompany();
                    air.ID = (long)reader["ID"];
                    air.AirlineName = (string)reader["AIRLINE_NAME"];
                    air.UserName = (string)reader["USER_NAME"];
                    air.Password = (string)reader["PASSWORD"];
                    air.CountryCode = (long)reader["COUNTRY_CODE"];
                    List.Add(air);
                }
                return List;
            }

        }

        public AirlineCompany GetAirLineByUserName(string user_name)
        {
            //ALTER PROCEDURE[dbo].[GET_AIR_LINE_BY_USER_NAME]
            //@USER_NAME VARCHAR(1000)
            //AS
            //select* from AirlineCompanies where USER_NAME = @USER_NAME

            using (SqlConnection connection = new SqlConnection(flightCenterConfig.CONNECTION_STRING))
            {
                AirlineCompany air = new AirlineCompany();
                SqlCommand cmd = new SqlCommand("GET_AIR_LINE_BY_USER_NAME", connection);
                cmd.Parameters.Add(new SqlParameter("@USER_NAME", user_name));

                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
                while (reader.Read() == true)
                {
                    air.ID = (long)reader["ID"];
                    air.AirlineName = (string)reader["AIRLINE_NAME"];
                    air.UserName = (string)reader["USER_NAME"];
                    air.Password = (string)reader["PASSWORD"];
                    air.CountryCode = (long)reader["COUNTRY_CODE"];                    
                }
                return air;
            }
        }

        public IList<AirlineCompany> GetAll()
        {
            //ALTER PROCEDURE[dbo].[GET_ALL_AIRLINE]
            //AS
            //select* from AirlineCompanies

            List<AirlineCompany> List = new List<AirlineCompany>();
            using (SqlConnection connection = new SqlConnection(flightCenterConfig.CONNECTION_STRING))
            {
                SqlCommand cmd = new SqlCommand("GET_ALL_AIRLINE", connection);
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
                while (reader.Read() == true)
                {
                    AirlineCompany air = new AirlineCompany();
                    air.ID = (long)reader["ID"];
                    air.AirlineName = (string)reader["AIRLINE_NAME"];
                    air.UserName = (string)reader["USER_NAME"];
                    air.Password = (string)reader["PASSWORD"];
                    air.CountryCode = (long)reader["COUNTRY_CODE"];

                    List.Add(air);
                }
                return List;
            }
        }

        public void Remove(AirlineCompany airlineCompany)
        {
            //ALTER PROCEDURE[dbo].[REMOVE_AIRLINE]
            //@ID bigint
            //AS
            //delete from AirlineCompanies where ID = @ID;

            using (SqlConnection connection = new SqlConnection(flightCenterConfig.CONNECTION_STRING))
            {
                SqlCommand cmd = new SqlCommand("REMOVE_AIRLINE", connection);
                cmd.Parameters.Add(new SqlParameter("@ID", airlineCompany.ID));
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                //cmd.EndExecuteNonQuery();   -----do i need this also if i use stored procedure?

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
            }
        }

        public void Update(AirlineCompany airlineCompany)
        {
            //ALTER PROCEDURE[dbo].[UPDATE_AIRLINE] @ID bigint, @AIRLINE_NAME varchar(1000), @USER_NAME varchar(1000), @PASSWORD varchar(1000), @COUNTRY_CODE bigint
            //AS
            //update AirlineCompanies
            //set AIRLINE_NAME = @AIRLINE_NAME, USER_NAME = @USER_NAME, PASSWORD = @PASSWORD, COUNTRY_CODE= @COUNTRY_CODE
            //where ID = @ID

            using (SqlConnection connection = new SqlConnection(flightCenterConfig.CONNECTION_STRING))
            {
                SqlCommand cmd = new SqlCommand("UPDATE_AIRLINE", connection);
                cmd.Parameters.Add(new SqlParameter("@ID", airlineCompany.ID));
                cmd.Parameters.Add(new SqlParameter("@AIRLINE_NAME", airlineCompany.AirlineName));
                cmd.Parameters.Add(new SqlParameter("@USER_NAME", airlineCompany.UserName));
                cmd.Parameters.Add(new SqlParameter("@PASSWORD", airlineCompany.Password));
                cmd.Parameters.Add(new SqlParameter("@COUNTRY_CODE", airlineCompany.CountryCode));
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.EndExecuteNonQuery();   -----do i need this also if i use stored procedure?
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
            }
        }

        public IList<Ticket> GetAllAirLineCompanyTickets(int airlineCompanyID)
        {
            //ALTER PROCEDURE[dbo].[GET_ALL_COMPANY_AIRLIN_TICKETS]
            //@ID bigint
            //AS
            //select Tickets.ID, Tickets.FLIGHT_ID, Tickets.CUSTOMER_ID
            //from Tickets
            //JOIN  Flights
            //on Tickets.FLIGHT_ID = Flights.ID and Flights.AIRLINECOMPANY_ID = @ID

            List<Ticket> List = new List<Ticket>();

            using (SqlConnection connection = new SqlConnection(flightCenterConfig.CONNECTION_STRING))
            {
                SqlCommand cmd = new SqlCommand("GET_ALL_COMPANY_AIRLIN_TICKETS", connection);
                cmd.Parameters.Add(new SqlParameter("@ID", airlineCompanyID));
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
                while (reader.Read() == true)
                {
                    Ticket ticket = new Ticket();
                    ticket.ID = (long)reader["ID"];
                    ticket.FlightID = (long)reader["FLIGHT_ID"];
                    ticket.CustomerID = (long)reader["CUSTOMER_ID"];
                    List.Add(ticket);
                }
                return List;
            }
        }
    }
}
