using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ADO_Address_Book
{
    public class ManageAddressBook
    {
        public static string connectingstring = @"Data Source = (localdb)\MSSQLLocalDB;Initial Catalog = Address_Book";       
        public bool AddData()
        {
            SqlConnection connection = new SqlConnection(connectingstring);
            try
            {                
                using (connection)
                {
                    SqlCommand command = new SqlCommand("ADD_PERSON", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    Console.WriteLine("Enter first name");
                    string fname = Console.ReadLine();
                    command.Parameters.AddWithValue("@FIRST_NAME", fname);
                    Console.WriteLine("Enter last name");
                    string lname = Console.ReadLine();
                    command.Parameters.AddWithValue("@LAST_NAME", lname);
                    Console.WriteLine("Enter Address");
                    string address = Console.ReadLine();
                    command.Parameters.AddWithValue("@ADDRESS", address);
                    Console.WriteLine("Enter City");
                    string city = Console.ReadLine();
                    command.Parameters.AddWithValue("@CITY", city);
                    Console.WriteLine("Enter State");
                    string state = Console.ReadLine();
                    command.Parameters.AddWithValue("@STATE", state);
                    Console.WriteLine("Enter PinCode");
                    int pin = Convert.ToInt32(Console.ReadLine());
                    command.Parameters.AddWithValue("@PIN", pin);
                    Console.WriteLine("Enter Pnone");
                    double phone = Convert.ToDouble(Console.ReadLine());
                    command.Parameters.AddWithValue("@PHONE", phone);
                    Console.WriteLine("Enter Email");
                    string email = Console.ReadLine();
                    command.Parameters.AddWithValue("@EMAIL", email);
                    Console.WriteLine("Enter Group name");
                    string group = Console.ReadLine();
                    command.Parameters.AddWithValue("@CONTACT_TYPE", group);
                    connection.Open();
                    var result = command.ExecuteNonQuery();
                    connection.Close();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
