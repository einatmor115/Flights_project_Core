using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights_project
{
    public class FlightDAOMSSQL : IFlightDAO
    {
        public long Add(Flight flight)
        {
            //ALTER PROCEDURE[dbo].[ADD_FLIGHT] @AIRLINECOMPANY_ID bigint, @ORIGIN_COUNTRY_CODE bigint, @DESTINATION_COUNTRY_CODE bigint, @DEPARTURE_TIME DATETIME, @LANDING_TIME DATETIME, @REMAINING_TICKETS INT
            //AS
            //INSERT into Flights(AIRLINECOMPANY_ID, ORIGIN_COUNTRY_CODE, DESTINATION_COUNTRY_CODE, DEPARTURE_TIME, LANDING_TIME, REMAINING_TICKETS)
            //VALUES(@AIRLINECOMPANY_ID , @ORIGIN_COUNTRY_CODE , @DESTINATION_COUNTRY_CODE , @DEPARTURE_TIME , @LANDING_TIME , @REMAINING_TICKETS )
            long fligthIdFromDB;
            using (SqlConnection connection = new SqlConnection(flightCenterConfig.CONNECTION_STRING))
            {
                SqlCommand cmd = new SqlCommand("ADD_FLIGHT", connection);
                cmd.Parameters.Add(new SqlParameter("@AIRLINECOMPANY_ID", flight.AirLineCompanyID));
                cmd.Parameters.Add(new SqlParameter("@ORIGIN_COUNTRY_CODE", flight.OriginCountryCode));
                cmd.Parameters.Add(new SqlParameter("@DESTINATION_COUNTRY_CODE", flight.DestinationCountryCode));
                cmd.Parameters.Add(new SqlParameter("@DEPARTURE_TIME", flight.DepartureTime));
                cmd.Parameters.Add(new SqlParameter("@LANDING_TIME", flight.LandingTime));
                cmd.Parameters.Add(new SqlParameter("@REMAINING_TICKETS", flight.RemainingTickets));
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                fligthIdFromDB = (long)cmd.ExecuteScalar();
            }
            flight.ID = fligthIdFromDB;
            return fligthIdFromDB;
        }

        public Flight Get(int id)
        {
            //ALTER PROCEDURE[dbo].[GET_FLIGHT_BY_ID]
            //@ID BIGINT
            //AS
            //select* from  Flights where ID = @ID;

            Flight flight = new Flight();
            using (SqlConnection connection = new SqlConnection(flightCenterConfig.CONNECTION_STRING))
            {
                SqlCommand cmd = new SqlCommand("GET_FLIGHT_BY_ID", connection);
                cmd.Parameters.Add(new SqlParameter("@ID", id));
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
                while (reader.Read() == true)
                {
                    flight.ID = (long)reader["ID"];
                    flight.AirLineCompanyID = (long)reader["AIRLINECOMPANY_ID"];
                    flight.OriginCountryCode = (long)reader["ORIGIN_COUNTRY_CODE"];
                    flight.DestinationCountryCode = (long)reader["DESTINATION_COUNTRY_CODE"];
                    flight.DepartureTime = (DateTime)reader["DEPARTURE_TIME"];
                    flight.LandingTime = (DateTime)reader["LANDING_TIME"];
                    flight.RemainingTickets = (int)reader["REMAINING_TICKETS"];
                }
                return flight;
            }
        }

        public IList<Flight> GetAll()
        {
            //ALTER PROCEDURE[dbo].[GET_ALL_FLIGHT]
            //AS
            //select* from  Flights

           List<Flight> List = new List<Flight>();
            using (SqlConnection connection = new SqlConnection(flightCenterConfig.CONNECTION_STRING))
            {
                SqlCommand cmd = new SqlCommand("GET_ALL_FLIGHT", connection);
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
                while (reader.Read() == true)
                {
                    Flight flight = new Flight();
                    flight.ID = (long)reader["ID"];
                    flight.AirLineCompanyID = (long)reader["AIRLINECOMPANY_ID"];
                    flight.OriginCountryCode = (long)reader["ORIGIN_COUNTRY_CODE"];
                    flight.DestinationCountryCode = (long)reader["DESTINATION_COUNTRY_CODE"];
                    flight.DepartureTime = (DateTime)reader["DEPARTURE_TIME"];
                    flight.LandingTime = (DateTime)reader["LANDING_TIME"];
                    flight.RemainingTickets = (int)reader["REMAINING_TICKETS"];
                    List.Add(flight);
                }
                return List;
            }
        }

        public Dictionary<Flight, int> GetAllFlightsVacancy()
        {
            //ALTER PROCEDURE[dbo].[GET_ALL_FLIGHT_VACANCY]
            //AS
            //select* from Flights WHERE REMAINING_TICKETS > 0

            Dictionary<Flight, int> flights = new Dictionary<Flight, int>();

            using (SqlConnection connection = new SqlConnection(flightCenterConfig.CONNECTION_STRING))
            {
                SqlCommand cmd = new SqlCommand("GET_ALL_FLIGHT_VACANCY", connection);
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
                while (reader.Read() == true)
                {
                    Flight flight = new Flight();
                    flight.ID = (long)reader["ID"];
                    flight.AirLineCompanyID = (long)reader["AIRLINECOMPANY_ID"];
                    flight.OriginCountryCode = (long)reader["ORIGIN_COUNTRY_CODE"];
                    flight.DestinationCountryCode = (long)reader["DESTINATION_COUNTRY_CODE"];
                    flight.DepartureTime = (DateTime)reader["DEPARTURE_TIME"];
                    flight.LandingTime = (DateTime)reader["LANDING_TIME"];
                    flight.RemainingTickets = (int)reader["REMAINING_TICKETS"];

                    flights.Add(flight, flight.RemainingTickets);
                }
                return flights;
            }
        }

        public Flight GetFlightById(int Id)
        {
            //ALTER PROCEDURE[dbo].[GET_FLIGHT_BY_ID]
            //@ID BIGINT
            //AS
            //select* from  Flights where ID = @ID;

            Flight flight = new Flight();
            using (SqlConnection connection = new SqlConnection(flightCenterConfig.CONNECTION_STRING))
            {
                SqlCommand cmd = new SqlCommand("GET_FLIGHT_BY_ID", connection);
                cmd.Parameters.Add(new SqlParameter("@ID", Id));
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
                while (reader.Read() == true)
                {
                    flight.ID = (long)reader["ID"];
                    flight.AirLineCompanyID = (long)reader["AIRLINECOMPANY_ID"];
                    flight.OriginCountryCode = (long)reader["ORIGIN_COUNTRY_CODE"];
                    flight.DestinationCountryCode = (long)reader["DESTINATION_COUNTRY_CODE"];
                    flight.DepartureTime = (DateTime)reader["DEPARTURE_TIME"];
                    flight.LandingTime = (DateTime)reader["LANDING_TIME"];
                    flight.RemainingTickets = (int)reader["REMAINING_TICKETS"];
                }
                return flight;
            }
        }

        public List<Flight> GetFlightsByCustomer(Customer customer)
        {
            //ALTER PROCEDURE[dbo].[GET_ALL_FLIGHT_BY_CUSTOMER]
            //@CUSTOMER_ID BIGINT
            //AS
            //select Flights.ID ,AIRLINECOMPANY_ID, ORIGIN_COUNTRY_CODE, DESTINATION_COUNTRY_CODE, DEPARTURE_TIME, LANDING_TIME, REMAINING_TICKETS
            //from  Flights
            //INNER JOIN Tickets
            //ON Tickets.FLIGHT_ID = Flights.ID AND Tickets.CUSTOMER_ID = @CUSTOMER_ID

            List<Flight> list = new List<Flight>();
            using (SqlConnection connection = new SqlConnection(flightCenterConfig.CONNECTION_STRING))
            {
                SqlCommand cmd = new SqlCommand("GET_ALL_FLIGHT_BY_CUSTOMER", connection);
                cmd.Parameters.Add(new SqlParameter("@CUSTOMER_ID", customer.ID));
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
                while (reader.Read() == true)
                {
                    Flight flight = new Flight();
                    flight.ID = (long)reader["ID"];
                    flight.AirLineCompanyID = (long)reader["AIRLINECOMPANY_ID"];
                    flight.OriginCountryCode = (long)reader["ORIGIN_COUNTRY_CODE"];
                    flight.DestinationCountryCode = (long)reader["DESTINATION_COUNTRY_CODE"];
                    flight.DepartureTime = (DateTime)reader["DEPARTURE_TIME"];
                    flight.LandingTime = (DateTime)reader["LANDING_TIME"];
                    flight.RemainingTickets = (int)reader["REMAINING_TICKETS"];
                    list.Add(flight);
                }
                return list;
            }
        }

        public List<Flight> GetFlightsByDepatureDate(DateTime departureDate)
        {

            //ALTER PROCEDURE[dbo].[GET_ALL_FLIGHT_BY_DEPARTURE_DATE]
            //@DATE_TIME DATETIME
            //AS
            //select Flights.ID, AIRLINECOMPANY_ID, ORIGIN_COUNTRY_CODE, DESTINATION_COUNTRY_CODE, DEPARTURE_TIME, LANDING_TIME, REMAINING_TICKETS
            //from  Flights
            //WHERE Flights.DEPARTURE_TIME = @DATE_TIME

            List<Flight> list = new List<Flight>();
            using (SqlConnection connection = new SqlConnection(flightCenterConfig.CONNECTION_STRING))
            {
                SqlCommand cmd = new SqlCommand("GET_ALL_FLIGHT_BY_DEPARTURE_DATE", connection);
                cmd.Parameters.Add(new SqlParameter("@DATE_TIME", departureDate));
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
                while (reader.Read() == true)
                {
                    Flight flight = new Flight();
                    flight.ID = (long)reader["ID"];
                    flight.AirLineCompanyID = (long)reader["AIRLINECOMPANY_ID"];
                    flight.OriginCountryCode = (long)reader["ORIGIN_COUNTRY_CODE"];
                    flight.DestinationCountryCode = (long)reader["DESTINATION_COUNTRY_CODE"];
                    flight.DepartureTime = (DateTime)reader["DEPARTURE_TIME"];
                    flight.LandingTime = (DateTime)reader["LANDING_TIME"];
                    flight.RemainingTickets = (int)reader["REMAINING_TICKETS"];
                    list.Add(flight);
                }
                return list;
            }
        }

        public List<Flight> GetFlightsByDestinationCountry(int country_code)
        {
            //ALTER PROCEDURE[dbo].[GET_ALL_FLIGHT_BY_DESTINATION_COUNTRY]
            //@DESTINATION_COUNTRY BIGINT
            //AS
            //select Flights.ID, AIRLINECOMPANY_ID, ORIGIN_COUNTRY_CODE, DESTINATION_COUNTRY_CODE, DEPARTURE_TIME, LANDING_TIME, REMAINING_TICKETS
            //from  Flights
            //WHERE Flights.DESTINATION_COUNTRY_CODE = @DESTINATION_COUNTRY

            List<Flight> list = new List<Flight>();
            using (SqlConnection connection = new SqlConnection(flightCenterConfig.CONNECTION_STRING))
            {
                SqlCommand cmd = new SqlCommand("GET_ALL_FLIGHT_BY_DESTINATION_COUNTRY", connection);
                cmd.Parameters.Add(new SqlParameter("@DESTINATION_COUNTRY", country_code));
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
                while (reader.Read() == true)
                {
                    Flight flight = new Flight();
                    flight.ID = (long)reader["ID"];
                    flight.AirLineCompanyID = (long)reader["AIRLINECOMPANY_ID"];
                    flight.OriginCountryCode = (long)reader["ORIGIN_COUNTRY_CODE"];
                    flight.DestinationCountryCode = (long)reader["DESTINATION_COUNTRY_CODE"];
                    flight.DepartureTime = (DateTime)reader["DEPARTURE_TIME"];
                    flight.LandingTime = (DateTime)reader["LANDING_TIME"];
                    flight.RemainingTickets = (int)reader["REMAINING_TICKETS"];
                    list.Add(flight);
                }
                return list;
            }
        }

        public List<Flight> GetFlightsByLandingDate(DateTime landingDate)
        {
            //ALTER PROCEDURE[dbo].[GET_ALL_FLIGHT_BY_LANDING_DATE]
            //@DATE_TIME BIGINT
            //AS
            //select Flights.ID, AIRLINECOMPANY_ID, ORIGIN_COUNTRY_CODE, DESTINATION_COUNTRY_CODE, DEPARTURE_TIME, LANDING_TIME, REMAINING_TICKETS
            //from  Flights
            //WHERE Flights.LANDING_TIME = @DATE_TIME

            List<Flight> list = new List<Flight>();
            using (SqlConnection connection = new SqlConnection(flightCenterConfig.CONNECTION_STRING))
            {
                SqlCommand cmd = new SqlCommand("GET_ALL_FLIGHT_BY_DEPARTURE_DATE", connection);
                cmd.Parameters.Add(new SqlParameter("@DATE_TIME", landingDate));
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
                while (reader.Read() == true)
                {
                    Flight flight = new Flight();
                    flight.ID = (long)reader["ID"];
                    flight.AirLineCompanyID = (long)reader["AIRLINECOMPANY_ID"];
                    flight.OriginCountryCode = (long)reader["ORIGIN_COUNTRY_CODE"];
                    flight.DestinationCountryCode = (long)reader["DESTINATION_COUNTRY_CODE"];
                    flight.DepartureTime = (DateTime)reader["DEPARTURE_TIME"];
                    flight.LandingTime = (DateTime)reader["LANDING_TIME"];
                    flight.RemainingTickets = (int)reader["REMAINING_TICKETS"];
                    list.Add(flight);
                }
                return list;
            }
        }

        public List<Flight> GetFlightsByOriginCountry(int country_code)
        {
            //ALTER PROCEDURE[dbo].[GET_ALL_FLIGHT_BY_ORIGION_COUNTRY]
            //@ORIGION_COUNTRY BIGINT
            //AS
            //select Flights.ID, AIRLINECOMPANY_ID, ORIGIN_COUNTRY_CODE, DESTINATION_COUNTRY_CODE, DEPARTURE_TIME, LANDING_TIME, REMAINING_TICKETS
            //from  Flights
            //WHERE Flights.ORIGIN_COUNTRY_CODE = @ORIGION_COUNTRY

            List<Flight> list = new List<Flight>();
            using (SqlConnection connection = new SqlConnection(flightCenterConfig.CONNECTION_STRING))
            {
                SqlCommand cmd = new SqlCommand("GET_ALL_FLIGHT_BY_ORIGION_COUNTRY", connection);
                cmd.Parameters.Add(new SqlParameter("@ORIGION_COUNTRY", country_code));
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
                while (reader.Read() == true)
                {
                    Flight flight = new Flight();
                    flight.ID = (long)reader["ID"];
                    flight.AirLineCompanyID = (long)reader["AIRLINECOMPANY_ID"];
                    flight.OriginCountryCode = (long)reader["ORIGIN_COUNTRY_CODE"];
                    flight.OriginCountryCode = (long)reader["DESTINATION_COUNTRY_CODE"];
                    flight.DepartureTime = (DateTime)reader["DEPARTURE_TIME"];
                    flight.LandingTime = (DateTime)reader["LANDING_TIME"];
                    flight.RemainingTickets = (int)reader["REMAINING_TICKETS"];
                    list.Add(flight);
                }
                return list;
            }
        }
        
        public void Remove(Flight flight)
        {
            // I USED THE **********CASCADING DELETES******** OPTION ON TICKETS TABLE where FK coneected to FLIGHTS TABLE! 
            //ALTER PROCEDURE[dbo].[REMOVE_FLIGHT]
            //@ID BIGINT
            //AS
            //delete FROM Flights
            // where ID = @ID;
            using (SqlConnection connection = new SqlConnection(flightCenterConfig.CONNECTION_STRING))
            {
                SqlCommand cmd = new SqlCommand("REMOVE_FLIGHT", connection);
                cmd.Parameters.Add(new SqlParameter("@ID", flight.ID));
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                //cmd.EndExecuteNonQuery();   -----do i need this also if i use stored procedure?

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
            }
        }

        public void Update(Flight flight)
        {
            //ALTER PROCEDURE[dbo].[UPDATE_FLIGHT] @ID BIGINT, @AIRLINECOMPANY_ID BIGINT, @ORIGIN_COUNTRY_CODE BIGINT, @DESTINATION_COUNTRY_CODE BIGINT, @DEPARTURE_TIME Datetime, @LANDING_TIME Datetime, @REMAINING_TICKETS INT
            //AS
            //update Flights
            //SET AIRLINECOMPANY_ID = @AIRLINECOMPANY_ID , ORIGIN_COUNTRY_CODE = @ORIGIN_COUNTRY_CODE, DESTINATION_COUNTRY_CODE= @DESTINATION_COUNTRY_CODE ,DEPARTURE_TIME = @DEPARTURE_TIME ,LANDING_TIME = @LANDING_TIME ,REMAINING_TICKETS = @REMAINING_TICKETS
            //where ID = @ID

            using (SqlConnection connection = new SqlConnection(flightCenterConfig.CONNECTION_STRING))
            {
                SqlCommand cmd = new SqlCommand("UPDATE_FLIGHT", connection);
                cmd.Parameters.Add(new SqlParameter("@ID", flight.ID));
                cmd.Parameters.Add(new SqlParameter("@AIRLINECOMPANY_ID", flight.AirLineCompanyID));
                cmd.Parameters.Add(new SqlParameter("@ORIGIN_COUNTRY_CODE", flight.OriginCountryCode));
                cmd.Parameters.Add(new SqlParameter("@DESTINATION_COUNTRY_CODE", flight.DestinationCountryCode));
                cmd.Parameters.Add(new SqlParameter("@DEPARTURE_TIME", flight.DepartureTime));
                cmd.Parameters.Add(new SqlParameter("@LANDING_TIME", flight.LandingTime));
                cmd.Parameters.Add(new SqlParameter("@REMAINING_TICKETS", flight.RemainingTickets));
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                //cmd.EndExecuteNonQuery();   -----do i need this also if i use stored procedure?

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
            }
        }
    }
}
