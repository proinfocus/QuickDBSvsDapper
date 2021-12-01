using System;

void Init() {
    // Create employee.db and Employee table.
    // This can't be done using Dapper.
    UsingQuickDBS.CreateTable();
}

if (File.Exists("employee.db") == false)
    Init();

Console.Clear();

string test = "";
while(test?.ToLower() != "q") {
    Console.WriteLine("".PadLeft(60, '='));    
    Console.WriteLine("Press 1 - QuickDBS, 2 - Dapper to execute test or Q to exit.");
    test = Console.ReadLine() ?? "";

    if (string.IsNullOrEmpty(test))
        continue;

    if (test == "1")
        TestQuickDBS();
    else if (test == "2")
        TestDapper();    
    else if (test?.ToLower() != "q")
        Console.WriteLine("Invalid key. Try again.\n");
}

void TestQuickDBS() {
    
    var result_2 = TimeTaken(() => UsingQuickDBS.Create100RandomEmployees());
    var result_1 = TimeTaken(() => UsingQuickDBS.ReadFromTableAndDisplay());
    Console.Clear();
    Console.WriteLine($"Time taken by QuickDBS for Create100RandomEmployees: {result_2} ms");
    Console.WriteLine($"Time taken by QuickDBS for ReadFromTableAndDisplay: {result_1} ms");
}

void TestDapper() {
    
    var result_2 = TimeTaken(() => UsingDapper.Create100RandomEmployees());
    var result_1 = TimeTaken(() => UsingDapper.ReadFromTableAndDisplay());
    Console.Clear();
    Console.WriteLine($"Time taken by Dapper for Create100RandomEmployees: {result_2} ms");
    Console.WriteLine($"Time taken by Dapper for ReadFromTableAndDisplay: {result_1} ms");
}

static long TimeTaken(Action action)
{
    long output = 0;
    var watch = System.Diagnostics.Stopwatch.StartNew();
    try
    {
        watch.Start();
        action();
    }
    catch (Exception)
    {
        output = -1;
        throw;
    }
    finally
    {
        watch.Stop();
    }
    output = output == 0 ? watch.ElapsedMilliseconds : output;
    return output;
}