using System;

class Program
{
    static void Main()
    {
        Address address1 = new Address("123 Main St", "Cityville", "Stateville", "Countryland");
        Address address2 = new Address("456 Elm St", "Townsville", "Stateville", "Countryland");
        Address address3 = new Address("789 Oak St", "Villageland", "Stateville", "Countryland");

        Lecture lecture = new Lecture("Interesting Lecture", "An informative lecture about a fascinating topic.", new DateTime(2023, 7, 20), new TimeSpan(18, 30, 0), address1, "John Doe", 100);
        Reception reception = new Reception("Networking Reception", "Join us for a networking event.", new DateTime(2023, 7, 22), new TimeSpan(19, 0, 0), address2, "rsvp@example.com");
        OutdoorGathering outdoorGathering = new OutdoorGathering("Summer Picnic", "Enjoy a fun-filled picnic in the park.", new DateTime(2023, 7, 25), new TimeSpan(12, 0, 0), address3, "Sunny skies expected!");

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

class Event
{
    private string title;
    private string description;
    private DateTime date;
    private TimeSpan time;
    private Address address;

    public Event(string title, string description, DateTime date, TimeSpan time, Address address)
    {
        this.title = title;
        this.description = description;
        this.date = date;
        this.time = time;
        this.address = address;
    }

    public string GenerateStandardDetails()
    {
        return $"Title: {title}\nDescription: {description}\nDate: {date.ToShortDateString()}\nTime: {time.ToString()}\nAddress: {address.ToString()}";
    }

    public virtual string GenerateFullDetails()
    {
        return GenerateStandardDetails();
    }

    public virtual string GenerateShortDescription()
    {
        return $"Type: Event\nTitle: {title}\nDate: {date.ToShortDateString()}";
    }
}

class Lecture : Event
{
    private string speaker;
    private int capacity;

    public Lecture(string title, string description, DateTime date, TimeSpan time, Address address, string speaker, int capacity)
        : base(title, description, date, time, address)
    {
        this.speaker = speaker;
        this.capacity = capacity;
    }

    public override string GenerateFullDetails()
    {
        return $"{base.GenerateFullDetails()}\nType: Lecture\nSpeaker: {speaker}\nCapacity: {capacity}";
    }
}

class Reception : Event
{
    private string rsvpEmail;

    public Reception(string title, string description, DateTime date, TimeSpan time, Address address, string rsvpEmail)
        : base(title, description, date, time, address)
    {
        this.rsvpEmail = rsvpEmail;
    }

    public override string GenerateFullDetails()
    {
        return $"{base.GenerateFullDetails()}\nType: Reception\nRSVP Email: {rsvpEmail}";
    }
}

class OutdoorGathering : Event
{
    private string weatherStatement;

    public OutdoorGathering(string title, string description, DateTime date, TimeSpan time, Address address, string weatherStatement)
        : base(title, description, date, time, address)
    {
        this.weatherStatement = weatherStatement;
    }

    public override string GenerateFullDetails()
    {
        return $"{base.GenerateFullDetails()}\nType: Outdoor Gathering\nWeather: {weatherStatement}";
    }
}