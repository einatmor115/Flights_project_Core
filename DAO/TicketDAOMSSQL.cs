using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights_project
{
    public class TicketDAOMSSQL : ITicketDAO
    {
        public long Add(Ticket ticket)
        {
            //ALTER PROCEDURE[dbo].[ADD_TICKET] @FLIGHT_ID BIGINT, @CUSTOMER_ID BIGINT
            //AS
            //insert into Tickets(FLIGHT_ID, CUSTOMER_ID)
            //VALUES
            //(@FLIGHT_ID, @CUSTOMER_ID)
            long ticketIdFromDB;
            using (SqlConnection connection = new SqlConnection(flightCenterConfig.CONNECTION_STRING))
            {
                SqlCommand cmd = new SqlCommand("ADD_TICKET", connection);
                cmd.Parameters.Add(new SqlParameter("@FLIGHT_ID", ticket.FlightID));
                cmd.Parameters.Add(new SqlParameter("@CUSTOMER_ID", ticket.CustomerID));
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                //cmd.EndExecuteNonQuery();   -----do i need this also if i use stored procedure?

                ticketIdFromDB = (long)cmd.ExecuteScalar();

            }
            return (long)ticketIdFromDB;
        }

        public Ticket Get(int id)
        {
            //ALTER PROCEDURE[dbo].[GET_TICKET_BY_ID]
            //@ID BIGINT
            //AS
            //SELECT* FROM Tickets WHERE ID = @ID

           Ticket ticket = new Ticket();
            using (SqlConnection connection = new SqlConnection(flightCenterConfig.CONNECTION_STRING))
            {
                SqlCommand cmd = new SqlCommand("GET_TICKET_BY_ID", connection);
                cmd.Parameters.Add(new SqlParameter("@ID", id));
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
                while (reader.Read() == true)
                {
                    ticket.ID = (long)reader["ID"];
                    ticket.FlightID = (long)reader["FLIGHT_ID"];
                    ticket.CustomerID = (long)reader["CUSTOMER_ID"];

                }
                return ticket;
            }
        }

        public IList<Ticket> GetAll()
        {
           //ALTER PROCEDURE[dbo].[GET_ALL_TICKET]
           //AS
           //SELECT* FROM Tickets

           List<Ticket> list = new List<Ticket>();
            using (SqlConnection connection = new SqlConnection(flightCenterConfig.CONNECTION_STRING))
            {
                SqlCommand cmd = new SqlCommand("GET_ALL_TICKET", connection);
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
                while (reader.Read() == true)
                {
                    Ticket ticket = new Ticket();
                    ticket.ID = (long)reader["ID"];
                    ticket.FlightID = (long)reader["FLIGHT_ID"];
                    ticket.CustomerID = (long)reader["CUSTOMER_ID"];
                    list.Add(ticket);
                }
                return list;
            }
        }

        public void Remove(Ticket ticket)
        {
            //ALTER PROCEDURE[dbo].[UPDATE_TICKET] @ID BIGINT, @FLIGHT_ID BIGINT, @CUSTOMER_ID BIGINT
            //AS
            //update Tickets
            //SET
            //FLIGHT_ID = @FLIGHT_ID, CUSTOMER_ID = @CUSTOMER_ID
            //where ID = @ID

            using (SqlConnection connection = new SqlConnection(flightCenterConfig.CONNECTION_STRING))
            {
                SqlCommand cmd = new SqlCommand("REMOVE_TICKET", connection);
                cmd.Parameters.Add(new SqlParameter("@ID", ticket.ID));
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                //cmd.EndExecuteNonQuery();   -----do i need this also if i use stored procedure?

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
            }
        }

        public void Update(Ticket ticket)
        {
            using (SqlConnection connection = new SqlConnection(flightCenterConfig.CONNECTION_STRING))
            {
                SqlCommand cmd = new SqlCommand("UPDATE_TICKET", connection);
                cmd.Parameters.Add(new SqlParameter("@ID", ticket.ID));
                cmd.Parameters.Add(new SqlParameter("@FLIGHT_ID", ticket.FlightID));
                cmd.Parameters.Add(new SqlParameter("@CUSTOMER_ID", ticket.CustomerID));
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                //cmd.EndExecuteNonQuery();   -----do i need this also if i use stored procedure?

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
            }
        }

        public List<Ticket> GetAllTicketsByFlight(Flight id)
        {
            List<Ticket> ticketsByFlight = new List<Ticket>();

            using (SqlConnection connection = new SqlConnection(flightCenterConfig.CONNECTION_STRING))
            {
                //ALTER PROCEDURE[dbo].[GET_TICKETS_BY_FLIGHT] @ID bigint, @FLIGHT_ID BIGINT, @CUSTOMER_ID BIGINT
                //AS
                //select Tickets.ID, Tickets.FLIGHT_ID, Tickets.CUSTOMER_ID
                //from Tickets
                //where
                //FLIGHT_ID = @FLIGHT_ID

                SqlCommand cmd = new SqlCommand("GET_TICKETS_BY_FLIGHT", connection);
                cmd.Parameters.Add(new SqlParameter("@ID", id));
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
                while (reader.Read() == true)
                {
                    Ticket ticket = new Ticket();
                    ticket.ID = (long)reader["ID"];
                    ticket.FlightID = (long)reader["FLIGHT_ID"];
                    ticket.CustomerID = (long)reader["CUSTOMER_ID"];
                    ticketsByFlight.Add(ticket);
                }
                return ticketsByFlight;
            }
        }
    }
}
