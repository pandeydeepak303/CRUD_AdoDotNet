using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoDotNet
{
    public class ADO_CRUD
    {
       private readonly string con = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;

        public ADO_CRUD(string con)
        {
            this.con = con;
        }
        public void ShowDepartment()
        {     
            try
            {
                using (SqlConnection myConnection = new SqlConnection(con))
                {
                    string query = "Select * from Department where IsDeleted=0";
                    SqlCommand cmd = new SqlCommand(query, myConnection);
                    myConnection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var sno = reader["sno"].ToString();
                            var Department = reader["Department"].ToString();
                            Console.WriteLine(sno + " " + Department);
                        }
                        myConnection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public void ShowEmployeeList()
        {
            try
            {
                using (SqlConnection myConnection = new SqlConnection(con))
                {
                    string query = "SELECT e.Name, d.Department, e.salary, e.age " +
                                   "FROM Employee e " +
                                   "LEFT JOIN Department d ON e.DepartmentId = d.sno " +
                                   "WHERE d.IsDeleted = 0";

                    SqlCommand cmd = new SqlCommand(query, myConnection);
                    myConnection.Open();
                    Console.WriteLine("Employee Name\t" + "age\t\t" + "salary\t\t" + "Department");
                    Console.WriteLine("-----------------------------------------------------------");
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var employeeName = reader["Name"].ToString();
                            var department = reader["Department"].ToString();
                            var age = reader["age"].ToString();
                            var salary = reader["salary"].ToString();

                            Console.WriteLine(employeeName + "\t\t" + age + "\t\t" + salary + "\t" + department);
                        }
                        Console.WriteLine("-----------------------------------------------------------");
                        myConnection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public void AddDepartment()
            {    
                try
                {
                    Console.WriteLine(" Enter your Department Name ");
                    string departmentName = Console.ReadLine();
                              
                  using (SqlConnection myConnection = new SqlConnection(con))
                    {
                        string query = "INSERT INTO Department (Department, IsDeleted) VALUES (@Department, 0)";
                        SqlCommand cmd = new SqlCommand(query, myConnection);
                        cmd.Parameters.AddWithValue("@Department", departmentName);
                        myConnection.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Department added successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Failed to add department.");
                        }
                    }
                               Console.ReadLine();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }


        public void DeleteDepartment( )
        {

            Console.WriteLine("Enter your Id Which You Want To delete  ");
            int sno = int.Parse(Console.ReadLine());        
            try
            {
                using (SqlConnection myConnection = new SqlConnection(con))
                {
                    string query = "UPDATE Department SET IsDeleted = 1 WHERE sno = @sno";
                    SqlCommand cmd = new SqlCommand(query, myConnection);
                   cmd.Parameters.AddWithValue("@sno", sno);
                    myConnection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Department deleted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Failed to delete department.");
                    }
                }
            }

            catch (Exception ex)
            {
                //throw ex;
            }
        }

        public void print()
        {
            Console.WriteLine("Welcome to git");
            Console.WriteLine("Welcome to clone git project   ssss");
        }







    }
}
