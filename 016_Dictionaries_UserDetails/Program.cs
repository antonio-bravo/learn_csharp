using System;
using System.Collections.Generic;

public class Employee
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        Dictionary<int, Employee> employees = new Dictionary<int, Employee>();
        
        employees.Add(100, new Employee()
        {
            FirstName = "Marcin",
            LastName = "Jamro",
            PhoneNumber = "000-000-000"
        });
        
        employees.Add(210, new Employee()
        {
            FirstName = "Mary",
            LastName = "Fox",
            PhoneNumber = "111-111-111"
        });
        
        employees.Add(303, new Employee()
        {
            FirstName = "John",
            LastName = "Smith",
            PhoneNumber = "222-222-222"
        });
        
        Console.WriteLine("Employee Details:");
        foreach (var employee in employees)
        {
            Console.WriteLine($"ID: {employee.Key} - FirstName:{employee.Value.FirstName} LastName:{employee.Value.LastName} Phone:{employee.Value.PhoneNumber}");
        }
        
        bool isCorrect = true;
        do
        {
            Console.Write("Enter the employee identifier: ");
            string idString = Console.ReadLine();
            isCorrect = int.TryParse(idString, out int id);
            
            if (isCorrect)
            {
                Console.ForegroundColor = ConsoleColor.White;
                
                if (employees.TryGetValue(id, out Employee employee))
                {
                    Console.WriteLine("First name: {1}{0}Last name: {2}{0}Phone number: {3}",
                        Environment.NewLine,
                        employee.FirstName,
                        employee.LastName,
                        employee.PhoneNumber);
                }
                else
                {
                    Console.WriteLine("The employee with the given identifier does not exist.");
                }
                
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
        while (isCorrect);
    }
}
