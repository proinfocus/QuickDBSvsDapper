using QuickDBS;

internal static class UsingQuickDBS
{
    // Connection string for 'employee.db' SQLite database
    static string connectionString = "Data Source=employee.db;";

    // Creating database if not exists and connecting to
    // it using QuickDBS.SQLite nuget package
    static IQuickDBS qDBS = new SQLite(connectionString);

    internal static void CreateTable()
    {
        // Create Employee table in the database using built-in
        // CreateTable method of QuickDBS library. Note: This can't
        // be done using Dapper.
        qDBS.CreateTable<Employee>();
    }

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

        // Add these records to the database using QuickDBS library.
        var result = qDBS.CreateMany<Employee>(employees);

        // Print result to console.
        Console.WriteLine($"{result} records created.");

        
    }

    internal static void ReadFromTableAndDisplay()
    {
        // Read records from Employee table and display onto screen.
        var employeesFromDB = qDBS.GetAll<Employee>();
        foreach (var emp in employeesFromDB)
        {
            Console.WriteLine($"{emp.Id}\t{emp.FirstName}\t{emp.LastName}\t{emp.Designation}\t{emp.Salary.ToString("N2")}\t{emp.JoiningDate.ToString("dd-MM-yyyy")}");
        }
    }
}