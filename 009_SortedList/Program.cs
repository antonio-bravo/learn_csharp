using System;
using System.Collections.Generic;

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
        SortedList<string, Person> people =
            new SortedList<string, Person>();

        people.Add("Marcin", new Person() { Name = "Marcin",
            Country = CountryEnum.PL, Age = 29 });
        people.Add("Sabine", new Person() { Name = "Sabine",
            Country = CountryEnum.DE, Age = 25 });
        people.Add("Ann", new Person() { Name = "Ann",  
            Country = CountryEnum.PL, Age = 31 }); 

        foreach (KeyValuePair<string, Person> person in people)
        {
            Console.WriteLine($"{person.Value.Name} ({person.Value.Age} years) from {person.Value.Country}.");
        }
    }
}
