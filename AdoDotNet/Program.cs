using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoDotNet
{
    public  class Program
    {


     public  static void Main(string[] args)
        {
            int choice;
            string connectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
            ADO_CRUD aDO_CRUD = new ADO_CRUD(connectionString);
            do
            {
                Console.WriteLine("EmployeeList--");
                aDO_CRUD.ShowEmployeeList();
            
                Console.WriteLine("Enter your choice:");
                Console.WriteLine("Press 1 to add a department");
                Console.WriteLine("Press 2 to show departments");
                Console.WriteLine("Press 3 to delete a department");
                Console.WriteLine("Press 0 to exit");

                string userInput = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(userInput))
                {
                    Console.WriteLine("Invalid choice! Please try again.");
                    continue;
                }

                if (!int.TryParse(userInput,  out choice))
                {
                    Console.WriteLine("Invalid choice! Please enter a valid integer.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        aDO_CRUD.AddDepartment();
                        break;
                    case 2:
                        aDO_CRUD.ShowDepartment();
                        break;
                    case 3:
                        aDO_CRUD.DeleteDepartment();
                        break;
                    case 0:
                        Console.WriteLine("Exiting the program...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice! Please try again.");
                        break;
                }

                Console.WriteLine("Do you want to continue? (y/n)");
            } while (Console.ReadLine().ToLower() == "y");

            Console.WriteLine("Program execution completed.");
            Console.ReadLine();

        }
            }
        }
    

