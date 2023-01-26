namespace BackEndApplication;

public class TicketAdvanced : AbstractTicket
{
    private TimeOnly startTime2;
    private char departurePlace2;
    private char arrivalPlace2;
    private TimeSpan partialDuration;
    private TimeSpan duration;
    
    public TicketAdvanced(TimeOnly startTime, char departurePlace, char arrivalPlace, TimeSpan partialDuration, TimeOnly startTime2,char departurePlace2, char arrivalPlace2, TimeSpan duration ) : base(startTime, departurePlace, arrivalPlace)
    {
        //this.startTime = startTime;
        //this.departurePlace = departurePlace;
        //this.arrivalPlace = arrivalPlace;
        this.partialDuration = partialDuration;
        
        this.startTime2 = startTime2;
        this.departurePlace2 = departurePlace2;
        this.arrivalPlace2 = arrivalPlace2;
        
        this.duration = duration;
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
    
    public TimeSpan GetDuration2()
    {
        return duration;
    }

    public TimeSpan GetDuration()
    {
        return partialDuration;
    }
    
    public override void Print()
    {
        Console.WriteLine("\nBilet2");
        Console.WriteLine("Przejazd o godzinie "+startTime+" z "+ departurePlace+" do "+arrivalPlace+", będzie trwał "+partialDuration+".");
        Console.WriteLine("Pociąg dojedzie do stacji przesiadkowej o godzinie "+startTime.Add(partialDuration)+".");
        Console.WriteLine("Przesiadka na pociąg o godzinie "+startTime2+" z "+ departurePlace2+" do "+arrivalPlace2+", przejazd będzie trwał "+duration+".");
        Console.WriteLine("Pociąg dojedzie na miejsce o godzinie "+startTime2.Add(duration)+".");
    }
}