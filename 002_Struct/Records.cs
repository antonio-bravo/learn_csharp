public record Person(string FirstName, string LastName);

public record Student(string FirstName, string LastName, int Id) : Person(FirstName, LastName);