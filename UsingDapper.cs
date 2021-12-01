using Dapper;
using Microsoft.Data.Sqlite;

internal static class UsingDapper
{
    // Connection string for 'employee.db' SQLite database
    static string connectionString = "Data Source=employee.db;";

    internal static void Create100RandomEmployees()
    {
        // Create 100 random employees with fake data.
        var employees = new List<Employee>();
        for (int i = 0; i < 100; i++)
        {
            employees.Add(new Employee
            {
                FirstName = "First name " + (i + 1),
                LastName = "Last name " + (i + 1),
                Designation = "Designation " + (i + 1),
                Salary = 100 * (i + 1),
                JoiningDate = DateTime.Now.AddYears(-5).AddDays(i)
            });
        }        

        // Add these records to the database using Dapper.
        using(var con = new SqliteConnection(connectionString))
        {        
            string qry = "INSERT INTO Employee (FirstName,LastName,Designation,Salary,JoiningDate) VALUES (@FirstName,@LastName,@Designation,@Salary,@JoiningDate)";
            foreach(var employee in employees)
            {
                con.Query(qry, employee);
            }
        }

        // // Print result to console.
        // Console.WriteLine($"{result} records created.");
    }

    internal static void ReadFromTableAndDisplay() 
    {
        // Read records from Employee table and display onto screen.
        IEnumerable<Employee> employeesFromDB;
        using(var con = new SqliteConnection(connectionString))
        {
            string qry = "SELECT * FROM Employee";
            employeesFromDB = con.Query<Employee>(qry);            
        }
        foreach (var emp in employeesFromDB)
        {
            Console.WriteLine($"{emp.Id}\t{emp.FirstName}\t{emp.LastName}\t{emp.Designation}\t{emp.Salary.ToString("N2")}\t{emp.JoiningDate.ToString("dd-MM-yyyy")}");
        }
    }
}