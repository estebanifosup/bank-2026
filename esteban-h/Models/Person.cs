namespace Bank.Models;

public class Person(string firstName, string lastName, DateTime birthDate)
{

    public string FirstName { get; set; } = firstName;
    public string LastName { get; set; } = lastName;
    public DateTime BirthDate { get; set; } = birthDate;

    public override string ToString() => $"{FirstName} {LastName}";

}