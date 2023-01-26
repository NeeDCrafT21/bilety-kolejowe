namespace BackEndApplication;

public class TicketAdvanced : AbstractTicket
{
    public int startHour { get; set; }
    public int startMinute { get; set; }
    private TimeOnly startTime2;
    private char departurePlace2;
    private char arrivalPlace2;
    private TimeSpan partialDuration;
    private TimeSpan duration;
    
    public TicketAdvanced(int startHour, int startMinute, char departurePlace, char arrivalPlace, TimeSpan partialDuration, TimeOnly startTime2,char departurePlace2, char arrivalPlace2, TimeSpan duration ) : base(departurePlace, arrivalPlace)
    {
        this.startHour = startHour;
        this.startMinute = startMinute;
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
        TimeOnly time = new TimeOnly(startHour, startMinute);
        Console.WriteLine("\nBilet2");
        Console.WriteLine("Przejazd o godzinie "+time+" z "+ departurePlace+" do "+arrivalPlace+", będzie trwał "+partialDuration+".");
        Console.WriteLine("Pociąg dojedzie do stacji przesiadkowej o godzinie "+time.Add(partialDuration)+".");
        Console.WriteLine("Przesiadka na pociąg o godzinie "+startTime2+" z "+ departurePlace2+" do "+arrivalPlace2+", przejazd będzie trwał "+duration+".");
        Console.WriteLine("Pociąg dojedzie na miejsce o godzinie "+startTime2.Add(duration)+".");
    }
}