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
        List<Address_Book_Model> list = new List<Address_Book_Model>();
        Address_Book_Model model = new Address_Book_Model();
        public static string connectingstring = @"Data Source = (localdb)\MSSQLLocalDB;Initial Catalog = Address_Book";       
        public bool AddData(Address_Book_Model model)
        {
            SqlConnection connection = new SqlConnection(connectingstring);
            try
            {                
                using (connection)
                {
                    SqlCommand command = new SqlCommand("ADD_PERSON", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FIRST_NAME", model.first_name);
                    command.Parameters.AddWithValue("@LAST_NAME", model.last_name);
                    command.Parameters.AddWithValue("@ADDRESS", model.address);
                    command.Parameters.AddWithValue("@CITY", model.city);
                    command.Parameters.AddWithValue("@STATE", model.state);
                    command.Parameters.AddWithValue("@PIN", model.pin);
                    command.Parameters.AddWithValue("@PHONE", model.phone);
                    command.Parameters.AddWithValue("@EMAIL", model.email);
                    command.Parameters.AddWithValue("@CONTACT_TYPE", model.group);
                    connection.Open();
                    Console.WriteLine(model.first_name + "Added");
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
        public void display()
        {
            SqlConnection connection = new SqlConnection(connectingstring);
            try
            {
                string query = "SELECT * FROM AddressBook";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        model.first_name = reader.GetString(1);
                        model.last_name = reader.GetString(2);
                        model.address = reader.GetString(3);
                        model.city = reader.GetString(4);
                        model.state = reader.GetString(5);
                        model.pin = reader.GetInt32(6);
                        model.phone = reader.GetDouble(7);
                        model.email = reader.GetString(8);
                        model.group = reader.GetString(9);
                        //Console.WriteLine("First Name \t|\t Last Name \t|\t Address \t|\t City \t|\t State \t|\t Pin \t|\t Phone \t|\t Email \t|\t Group \t|\t"+model.first_name);
                        Console.WriteLine("First Name : " + model.first_name+"\nLast Name : "+ model.last_name+"\nAddress : "+model.address
                            +"\nCity : "+model.city+"\nState : "+model.state+"\nPin : "+model.pin+"\nPhone : "+model.phone+"\nEmail : "+
                            model.email+"\nGroup : "+model.group);
                        Console.WriteLine("=============================");
                    }
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public void UpdateData()
        {
            SqlConnection connection = new SqlConnection(connectingstring);
            try
            {
                string query = "";
                Console.WriteLine("Enter first name to Find");
                string fname = Console.ReadLine();
                Console.WriteLine("1 - FIRST_NAME \n2 - LAST_NAME \n3 - ADDRESS \n4 - CITY \n5 - STATE \n6 - PIN \n7 - PHONE \n8 - EMAIL \n9 - CONTACT_TYPE");
                int select = Convert.ToInt32(Console.ReadLine());
                switch (select)
                {
                    case 1:
                        Console.WriteLine("Enter First Name To Update");
                        string update = Console.ReadLine();
                        query = "UPDATE AddressBook SET FIRST_NAME = '" + update + "' WHERE FIRST_NAME = '" + fname + "'";
                        break;
                    case 2:
                        Console.WriteLine("Enter Last Name To Update");
                        string lname = Console.ReadLine();
                        query = "UPDATE AddressBook SET LAST_NAME = '" + lname + "' WHERE FIRST_NAME = '" + fname + "'";
                        break;
                    case 3:
                        Console.WriteLine("Enter Address To Update");
                        string address = Console.ReadLine();
                        query = "UPDATE AddressBook SET ADDRESS = '" + address + "' WHERE FIRST_NAME = '" + fname + "'";
                        break;
                    case 4:
                        Console.WriteLine("Enter City To Update");
                        string city = Console.ReadLine();
                        query = "UPDATE AddressBook SET CITY = '" + city + "' WHERE FIRST_NAME = '" + fname + "'";
                        break;
                    case 5:
                        Console.WriteLine("Enter Stata To Update");
                        string state = Console.ReadLine();
                        query = "UPDATE AddressBook SET STATE = '" + state + "' WHERE FIRST_NAME = '" + fname + "'";
                        break;
                    case 6:
                        Console.WriteLine("Enter Pin To Update");
                        int pin = Convert.ToInt32(Console.ReadLine());
                        query = "UPDATE AddressBook SET PIN = '" + pin + "' WHERE FIRST_NAME = '" + fname + "'";
                        break;
                    case 7:
                        Console.WriteLine("Enter Phone To Update");
                        double phone = Convert.ToDouble(Console.ReadLine());
                        query = "UPDATE AddressBook SET PHONE = '" + phone + "' WHERE FIRST_NAME = '" + fname + "'";
                        break;
                    case 8:
                        Console.WriteLine("Enter Email To Update");
                        string email = Console.ReadLine();
                        query = "UPDATE AddressBook SET EMAIL = '" + email + "' WHERE FIRST_NAME = '" + fname + "'";
                        break;
                    case 9:
                        Console.WriteLine("Enter Group To Update");
                        string group = Console.ReadLine();
                        query = "UPDATE AddressBook SET CONTACT_TYPE = '" + group + "' WHERE FIRST_NAME = '" + fname + "'";
                        break;

                }
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally { connection.Close(); }
        }
        public void DeleteAddress()
        {
            SqlConnection connection = new SqlConnection(connectingstring);
            try
            {
                Console.WriteLine("Enter First Name To Delete");
                string fname = Console.ReadLine();
                connection.Open();
                SqlCommand command = new SqlCommand("DELETE_PERSON", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@FIRST_NAME", fname);       
                command.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            { connection.Close(); }
        }
        public void AddPersonUsingThread(List<Address_Book_Model> list)
        {
            Console.WriteLine("Enter Number Of Person to Add");
            int totalContact = Convert.ToInt32(Console.ReadLine());
            int count = 0;
            while (totalContact > count)
            {
                Address_Book_Model model = new Address_Book_Model();
                GetSetPersons(model);
                list.Add(model);
                count++;
            }
            DateTime startThreadTime = DateTime.Now;
            list.ForEach(detail =>
            {                
                Thread thread = new Thread(() =>
                 {
                     AddData(detail);
                 });
                thread.Start();
            });
            DateTime endTime = DateTime.Now;
            Console.WriteLine("Elapsed Time : " + (endTime - startThreadTime));
        }
        public void GetSetPersons(Address_Book_Model model)
        {
            Console.WriteLine("Enter first name");
            model.first_name = Console.ReadLine();
            Console.WriteLine("Enter last name");
            model.last_name = Console.ReadLine();
            Console.WriteLine("Enter Address");
            model.address = Console.ReadLine();
            Console.WriteLine("Enter City");
            model.city = Console.ReadLine();
            Console.WriteLine("Enter State");
            model.state = Console.ReadLine();
            Console.WriteLine("Enter PinCode");
            model.pin = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Pnone");
            model.phone = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter Email");
            model.email = Console.ReadLine();
            Console.WriteLine("Enter Group name");
            model.group = Console.ReadLine();
        }
    }
}
