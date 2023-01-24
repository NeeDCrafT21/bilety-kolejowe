namespace BackEndApplication;

public class TicketAdvanced : AbstractTicket
{
    private TimeOnly startTime2;
    private char departurePlace2;
    private char arrivalPlace2;
    private TimeSpan partialDuration;
    private TimeSpan duration;
    
    public TicketAdvanced(TimeOnly startTime, char departurePlace, char arrivalPlace, TimeSpan partialDuration, TimeOnly startTime2,char departurePlace2, char arrivalPlace2, TimeSpan duration )
    {
        this.startTime = startTime;
        this.departurePlace = departurePlace;
        this.arrivalPlace = arrivalPlace;
        this.partialDuration = partialDuration;
        
        this.startTime2 = startTime;
        this.departurePlace2 = departurePlace2;
        this.arrivalPlace2 = arrivalPlace2;
        
        this.duration = (this.startTime2 - this.startTime) + duration;
    }

    public TimeOnly GetTime2()
    {
        return startTime2;
    }
    public char GetArrivalPlace2()
    {
        return arrivalPlace2;
    }
    
    public char GetDeparturePlace2()
    {
        return departurePlace2;
    }
    
    public TimeSpan GetDuration()
    {
        return duration;
    }
    
    public override void Print()
    {
        Console.WriteLine("\nBilet2");
        Console.WriteLine("Przed przesiadką: "+startTime+" "+ departurePlace+" "+arrivalPlace+" "+partialDuration+".");
        Console.WriteLine("Po przesiadce: "+startTime2+" "+ departurePlace2+" "+arrivalPlace2+" "+duration+".");
    }
}