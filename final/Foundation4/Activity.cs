class Activity
{
    public DateTime Date { get; set; }
    public int LengthInMinutes { get; set; }

    public virtual double GetDistance()
    {
        return 0;
    }

    public virtual double GetSpeed()
    {
        return 0;
    }

    public virtual double GetPace()
    {
        return 0;
    }

    public virtual string GetSummary()
    {
        return $"No summary available for {GetType().Name}";
    }
}

class Running : Activity
{
    public double Distance { get; set; }

    public override double GetDistance()
    {
        return Distance;
    }

    public override double GetSpeed()
    {
        return Distance / LengthInMinutes * 60;
    }

    public override double GetPace()
    {
        return LengthInMinutes / Distance;
    }

    public override string GetSummary()
    {
        return $"{Date:d MMM yyyy} Running ({LengthInMinutes} min) - Distance: {Distance} miles, Speed: {GetSpeed()} mph, Pace: {GetPace()} min per mile";
    }
}

class Cycling : Activity
{
    public double Speed { get; set; }

    public override double GetSpeed()
    {
        return Speed;
    }

    public override double GetPace()
    {
        return 60 / Speed;
    }

    public override string GetSummary()
    {
        return $"{Date:d MMM yyyy} Cycling ({LengthInMinutes} min) - Speed: {Speed} mph, Pace: {GetPace()} min per mile";
    }
}

class Swimming : Activity
{
    public int Laps { get; set; }
    private const int MetersPerLap = 50;

    public override double GetDistance()
    {
        return Laps * MetersPerLap / 1000.0 * 0.62; // Convert meters to miles
    }

    public override double GetSpeed()
    {
        return GetDistance() / LengthInMinutes * 60;
    }

    public override double GetPace()
    {
        return LengthInMinutes / GetDistance();
    }

    public override string GetSummary()
    {
        return $"{Date:d MMM yyyy} Swimming ({LengthInMinutes} min) - Distance: {GetDistance()} miles, Speed: {GetSpeed()} mph, Pace: {GetPace()} min per mile";
    }
}