using Entity;
using MySql.Data.MySqlClient;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class EmployeeService : IEmployee
    {

        private string connectionString = "server=localhost;port=3306;user=root;password=password;database=mysqltutorial";
        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();

            string query = @"select * from employee";

            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand command = new MySqlCommand(query, connection);

            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int id = int.Parse(reader["id"].ToString());
                    string fName = reader["fname"].ToString();
                    string lName = reader["lname"].ToString();
                    string email = reader["email"].ToString();
                    string contact = reader["contactno"].ToString();

                    Employee emp = new Employee();
                    emp.Id = id;
                    emp.FirstName = fName;
                    emp.LastName = lName;
                    emp.Email = email;
                    emp.ContactNumber = contact;

                    employees.Add(emp);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }

            return employees;
        }

       
    }
}
