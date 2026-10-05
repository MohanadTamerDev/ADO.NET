using System;
using System.Data.SqlClient;

class Program
{
    static string connectionString =
        "Server=.;Database=CompanyDB;Trusted_Connection=True;";

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("===== Employee Menu =====");
            Console.WriteLine("1. Create Employee");
            Console.WriteLine("2. Exit");
            Console.Write("Choose: ");

            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                CreateEmployee();
            }
            else if (choice == 2)
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid Choice");
            }

            Console.WriteLine();
        }
    }


    static void CreateEmployee()
    {
        Console.Write("Enter Employee Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Employee Age: ");
        int age = int.Parse(Console.ReadLine());

        Console.Write("Enter Employee Salary: ");
        decimal salary = decimal.Parse(Console.ReadLine());


        using (SqlConnection connection =
               new SqlConnection(connectionString))
        {
            string query = @"
                INSERT INTO Employee (Name, Age, Salary)
                VALUES (@Name, @Age, @Salary)";


            using (SqlCommand command =
                   new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Age", age);
                command.Parameters.AddWithValue("@Salary", salary);

                connection.Open();

                int rows = command.ExecuteNonQuery();

                if (rows > 0)
                {
                    Console.WriteLine(
                        "Employee Created Successfully!");
                }
            }
        }
    }
}
