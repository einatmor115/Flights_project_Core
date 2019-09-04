using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights_project
{
    public class CustomerDAOMSSQL : ICustomerDAO
    {
        public long Add(Customer customer)
        {
            long customerIdFromDB;
            using (SqlConnection connection = new SqlConnection(flightCenterConfig.CONNECTION_STRING))
            {
                //ALTER PROCEDURE[dbo].[ADD_CUSTOMER] @FIRST_NAME as VARCHAR(1000), @LAST_NAME as VARCHAR(1000), @USER_NAME as VARCHAR(1000), @PASSWORD as VARCHAR(1000), @ADDRESS as VARCHAR(1000), @PHONE_NO as VARCHAR(1000), @CREDIT_CARD_NUMBER as VARCHAR(1000)
                //AS
                //insert into Customers(FIRST_NAME , LAST_NAME , USER_NAME , PASSWORD, ADDRESS , PHONE_NO , CREDIT_CARD_NUMBER)
                //VALUES
                //(@FIRST_NAME, @LAST_NAME, @USER_NAME, @PASSWORD, @ADDRESS, @PHONE_NO, @CREDIT_CARD_NUMBER)
                //select ID from Customers

                SqlCommand cmd = new SqlCommand("ADD_CUSTOMER", connection);
                cmd.Parameters.Add(new SqlParameter("@FIRST_NAME", customer.FirstName));
                cmd.Parameters.Add(new SqlParameter("@LAST_NAME", customer.LastName));
                cmd.Parameters.Add(new SqlParameter("@USER_NAME", customer.UserName));
                cmd.Parameters.Add(new SqlParameter("@PASSWORD", customer.Password));
                cmd.Parameters.Add(new SqlParameter("@ADDRESS", customer.Address));
                cmd.Parameters.Add(new SqlParameter("@PHONE_NO", customer.PhoneNO));
                cmd.Parameters.Add(new SqlParameter("@CREDIT_CARD_NUMBER", customer.CreditCardNumber));
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.EndExecuteNonQuery();   -----do i need this also if i use stored procedure?

                //SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
                customerIdFromDB = (long)cmd.ExecuteScalar();

            }
            return customerIdFromDB;
        }

        public Customer Get(int id)
        {
            Customer customer = new Customer();
            using (SqlConnection connection = new SqlConnection(flightCenterConfig.CONNECTION_STRING))
            {
                //********  ALTER PROCEDURE[dbo].[GET_CUSTOMER_BY_ID]
                //********  @ID bigint
                //********  AS
                //********  select* from Customers where ID = @ID;

                SqlCommand cmd = new SqlCommand("GET_CUSTOMER_BY_ID", connection);
                cmd.Parameters.Add(new SqlParameter("@ID", id));

                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
                while (reader.Read() == true)
                {
                    customer.ID = (long)reader["ID"];
                    customer.FirstName = (string)reader["FIRST_NAME"];
                    customer.LastName = (string)reader["LAST_NAME"];
                    customer.UserName = (string)reader["USER_NAME"];
                    customer.Password = (string)reader["PASSWORD"];
                    customer.PhoneNO = (string)reader["PHONE_NO"];
                    customer.CreditCardNumber = (string)reader["CREDIT_CARD_NUMBER"];
                }
                return customer;
            }
        }

        public IList<Customer> GetAll()
        {
            //ALTER PROCEDURE[dbo].[GET_ALL_CUSTOMER]
            //AS
            //select* from Customers

            List<Customer> List = new List<Customer>();
            using (SqlConnection connection = new SqlConnection(flightCenterConfig.CONNECTION_STRING))
            {
                SqlCommand cmd = new SqlCommand("GET_ALL_CUSTOMER", connection);
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
                while (reader.Read() == true)
                {
                    Customer customer = new Customer();
                    customer.ID = (long)reader["ID"];
                    customer.FirstName = (string)reader["FIRST_NAME"];
                    customer.LastName = (string)reader["LAST_NAME"];
                    customer.UserName = (string)reader["USER_NAME"];
                    customer.Password = (string)reader["PASSWORD"];
                    customer.PhoneNO = (string)reader["PHONE_NO"];
                    customer.CreditCardNumber = (string)reader["CREDIT_CARD_NUMBER"];
                    List.Add(customer);
                }
                return List;
            }
        }

        public Customer GetCustomerByUserName(string name)
        {
            //ALTER PROCEDURE[dbo].[GET_CUSTOMER_BY_USER_NAME]
            //@NAME VARCHAR(1000)
            //AS
            //select* from Customers WHERE USER_NAME = @NAME

            Customer customer = new Customer() ;
            using (SqlConnection connection = new SqlConnection(flightCenterConfig.CONNECTION_STRING))
            {
                SqlCommand cmd = new SqlCommand("GET_CUSTOMER_BY_USER_NAME", connection);
                cmd.Parameters.Add(new SqlParameter("@NAME", name));

                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
                while (reader.Read() == true)
                {
                    customer.ID = (long)reader["ID"];
                    customer.FirstName = (string)reader["FIRST_NAME"];
                    customer.LastName = (string)reader["LAST_NAME"];
                    customer.UserName = (string)reader["USER_NAME"];
                    customer.Password = (string)reader["PASSWORD"];
                    customer.Address = (string)reader["ADDRESS"];
                    customer.PhoneNO = (string)reader["PHONE_NO"];
                    customer.CreditCardNumber = (string)reader["CREDIT_CARD_NUMBER"];
                }
                return customer;
            }
        }

        public Customer GetCustomerByName(string name)
        {
            //ALTER PROCEDURE[dbo].[GET_CUSTOMER_BY_USER_NAME]
            //@NAME VARCHAR(1000)
            //AS
            //select* from Customers WHERE FIRST_NAME = @NAME

            Customer customer = new Customer();
            using (SqlConnection connection = new SqlConnection(flightCenterConfig.CONNECTION_STRING))
            {
                SqlCommand cmd = new SqlCommand("GET_CUSTOMER_BY_NAME", connection);
                cmd.Parameters.Add(new SqlParameter("@NAME", name));

                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
                while (reader.Read() == true)
                {
                    customer.ID = (long)reader["ID"];
                    customer.FirstName = (string)reader["FIRST_NAME"];
                    customer.LastName = (string)reader["LAST_NAME"];
                    customer.UserName = (string)reader["USER_NAME"];
                    customer.Password = (string)reader["PASSWORD"];
                    customer.Address = (string)reader["ADDRESS"];
                    customer.PhoneNO = (string)reader["PHONE_NO"];
                    customer.CreditCardNumber = (string)reader["CREDIT_CARD_NUMBER"];
                }
                return customer;
            }
        }

        public void Remove(Customer customer)
        {
            //ALTER PROCEDURE[dbo].[REMOVE_CUSTOMER]
            //@ID bigint
            //AS
            //delete from Customers WHERE ID = @ID;

            using (SqlConnection connection = new SqlConnection(flightCenterConfig.CONNECTION_STRING))
            {
                SqlCommand cmd = new SqlCommand("REMOVE_CUSTOMER", connection);
                cmd.Parameters.Add(new SqlParameter("@ID", customer.ID));
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                //cmd.EndExecuteNonQuery();   -----do i need this also if i use stored procedure?

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
            }
        }

        public void Update(Customer customer)
        {
            using (SqlConnection connection = new SqlConnection(flightCenterConfig.CONNECTION_STRING))
            {
                //ALTER PROCEDURE[dbo].[UPDATE_CUSTOMER] @ID bigint, @FIRST_NAME VARCHAR(1000),  @LAST_NAME VARCHAR(1000), @USER_NAME VARCHAR(1000),  @PASSWORD VARCHAR(1000), @ADDRESS VARCHAR(1000), @PHONE_NO VARCHAR(1000), @CREDIT_CARD_NUMBER VARCHAR(1000)
                //AS
                //update Customers
                //set FIRST_NAME = @FIRST_NAME, LAST_NAME = @LAST_NAME, USER_NAME = @USER_NAME, PASSWORD = @PASSWORD, ADDRESS = @ADDRESS, PHONE_NO = @PHONE_NO, CREDIT_CARD_NUMBER = CREDIT_CARD_NUMBER
                //where ID = @ID

                SqlCommand cmd = new SqlCommand("UPDATE_CUSTOMER", connection);
                cmd.Parameters.Add(new SqlParameter("@ID", customer.ID));
                cmd.Parameters.Add(new SqlParameter("@FIRST_NAME", customer.FirstName));
                cmd.Parameters.Add(new SqlParameter("@LAST_NAME", customer.LastName));
                cmd.Parameters.Add(new SqlParameter("@USER_NAME", customer.UserName));
                cmd.Parameters.Add(new SqlParameter("@PASSWORD", customer.Password));
                cmd.Parameters.Add(new SqlParameter("@ADDRESS", customer.Address));
                cmd.Parameters.Add(new SqlParameter("@PHONE_NO", customer.PhoneNO));
                cmd.Parameters.Add(new SqlParameter("@CREDIT_CARD_NUMBER", customer.CreditCardNumber));
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                //cmd.EndExecuteNonQuery();   -----do i need this also if i use stored procedure?

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
            }
        }
    }
}
