namespace BackEndApplication;

public class Ticket : AbstractTicket
{
    private TimeSpan duration;
    public Ticket(TimeOnly startTime, char departurePlace, char arrivalPlace, TimeSpan duration)
    {
        this.startTime = startTime;
        this.departurePlace = departurePlace;
        this.arrivalPlace = arrivalPlace;
        this.duration = duration;
    }
    
    public TimeSpan GetDuration()
    {
        return duration;
    }

    public override void Print()
    {
        Console.WriteLine("\nBilet1\n"+startTime+" "+ departurePlace+" "+arrivalPlace+" "+duration+".");
    }
}