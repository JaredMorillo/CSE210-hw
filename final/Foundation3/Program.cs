using System;

class Program
{
    static void Main()
    {
        Address address1 = new Address("123 Main St", "Cityville", "Stateville", "Countryland");
        Address address2 = new Address("456 Elm St", "Townsville", "Stateville", "Countryland");
        Address address3 = new Address("789 Oak St", "Villageland", "Stateville", "Countryland");

        Event lecture = new Lecture("Interesting Lecture", "An informative lecture about a fascinating topic.", new DateTime(2023, 7, 20), new TimeSpan(18, 30, 0), address1, "Jared Morillo", 100);
        Event reception = new Reception("Networking Reception", "Join us for a networking event.", new DateTime(2023, 7, 22), new TimeSpan(19, 0, 0), address2, "jm45@gmail.com");
        Event outdoorGathering = new OutdoorGathering("Summer Picnic", "Enjoy a fun-filled picnic in the park.", new DateTime(2023, 7, 25), new TimeSpan(12, 0, 0), address3, "Sunny skies expected!");

        Console.WriteLine("=== Standard Details ===");
        Console.WriteLine(lecture.GenerateStandardDetails());
        Console.WriteLine();
        Console.WriteLine(reception.GenerateStandardDetails());
        Console.WriteLine();
        Console.WriteLine(outdoorGathering.GenerateStandardDetails());
        Console.WriteLine();

        Console.WriteLine("=== Full Details ===");
        Console.WriteLine(lecture.GenerateFullDetails());
        Console.WriteLine();
        Console.WriteLine(reception.GenerateFullDetails());
        Console.WriteLine();
        Console.WriteLine(outdoorGathering.GenerateFullDetails());
        Console.WriteLine();

        Console.WriteLine("=== Short Description ===");
        Console.WriteLine(lecture.GenerateShortDescription());
        Console.WriteLine();
        Console.WriteLine(reception.GenerateShortDescription());
        Console.WriteLine();
        Console.WriteLine(outdoorGathering.GenerateShortDescription());
    }
}
class Address
{
    private string street;
    private string city;
    private string state;
    private string country;

    public Address(string street, string city, string state, string country)
    {
        this.street = street;
        this.city = city;
        this.state = state;
        this.country = country;
    }

    public override string ToString()
    {
        return $"{street}, {city}, {state}, {country}";
    }
}