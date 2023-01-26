namespace BackEndApplication;

public class Ticket : AbstractTicket
{
    private TimeSpan duration;
    public Ticket(TimeOnly startTime, char departurePlace, char arrivalPlace, TimeSpan duration) : base(startTime, departurePlace, arrivalPlace)
    {
        this.duration = duration;
    }
    
    public TimeSpan GetDuration()
    {
        return duration;
    }

    public override void Print()
    {
        Console.WriteLine("\nBilet1");
        Console.WriteLine("Przejazd o godzinie "+startTime+" z "+ departurePlace+" do "+arrivalPlace+", będzie trwał "+duration+"."); 
        Console.WriteLine("Pociąg dojedzie na miejsce o godzinie "+startTime.Add(duration)+".");
    }
}