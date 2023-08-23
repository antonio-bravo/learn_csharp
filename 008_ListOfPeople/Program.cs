using System;
using System.Collections.Generic;
using System.Linq;

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public CountryEnum Country { get; set; }
}

public enum CountryEnum
{
    PL,
    UK,
    DE
}

class Program
{
    static void Main(string[] args)
    {
        List<Person> people = new List<Person>();
        people.Add(new Person() { Name = "Marcin", Country = CountryEnum.PL, Age = 29 });
        people.Add(new Person() { Name = "Sabine", Country = CountryEnum.DE, Age = 25 });
        people.Add(new Person() { Name = "Ann", Country = CountryEnum.PL, Age = 31 });

        List<Person> results = people.OrderBy(p => p.Name).ToList();

        Console.WriteLine("\nList of People order by Name:\n");
        
        foreach (Person person in results)
        {
            Console.WriteLine($"{person.Name} ({person.Age} years) from {person.Country}.");
        }

        Console.WriteLine("\nFiltering by age <= 30 and selecting names:");

        List<string> names = people.Where(p => p.Age <= 30)
                                   .OrderBy(p => p.Name)
                                   .Select(p => p.Name)
                                   .ToList();

        foreach (string name in names)
        {
            Console.WriteLine(name);
        }
    }
}
