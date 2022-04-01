using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace UserValidation
{
    internal class ValidationCheck
    {
        public static string connectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=userlogin;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlConnection connection = new SqlConnection(connectionString);
        public void userEntryCheck()
        {
            connection.Open();
            using (this.connection)
            {
                User_Details displayModel = new User_Details();
                SqlCommand command = new SqlCommand("SpUserDetails", connection);

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Name", displayModel.Name);
                command.Parameters.AddWithValue("@Email", displayModel.Email);
                command.Parameters.AddWithValue("@PhoneNumber", displayModel.PhoneNumber);
                command.Parameters.AddWithValue("@Designation", displayModel.Designation);
                command.Parameters.AddWithValue("@Course", displayModel.Course);
                command.Parameters.AddWithValue("@Gender", displayModel.Course);
                command.Parameters.AddWithValue("@Username", displayModel.Course);
                command.Parameters.AddWithValue("@Password", displayModel.Course);

                string query = $"Select * from employee_payroll where email is {displayModel.Email};";
                SqlCommand validation_command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader dr = command.ExecuteReader();
                SqlDataReader dr_check = validation_command.ExecuteReader();
                if (dr_check.HasRows)
                {
                    Console.WriteLine("Validation failed");
                }
                else
                {

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            displayModel.Name = dr["Name"].ToString();

                            displayModel.Email = dr["Email"].ToString();

                            displayModel.PhoneNumber = Convert.ToInt32(dr["PhoneNumber"]);

                            displayModel.Designation = dr["Designation"].ToString();

                            displayModel.Course = dr["Course"].ToString();

                            displayModel.Gender = dr["Gender"].ToString();
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found.");
                    }
                }

                string query_LoginCheck = $"Select * from employee_payroll where Username is {displayModel.Email};";
                connection.Close();
            }
        }
    }
}

