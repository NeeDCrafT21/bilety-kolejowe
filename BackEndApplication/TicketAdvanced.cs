namespace BackEndApplication;

[Serializable()]
public class TicketAdvanced : AbstractTicket
{
    [NonSerialized()] public TimeOnly startTime;
    public int startHour { get; set; }
    public int startMinute { get; set; }

    [NonSerialized()] public TimeOnly startTime2;
    
    public int startHour2 { get; set; }
    public int startMinute2 { get; set; }
    public char departurePlace2{ get; set; }
    public char arrivalPlace2{ get; set; }
    public TimeSpan partialDuration{ get; set; }
    public TimeSpan duration{ get; set; }
    
    public TicketAdvanced(TimeOnly startTime, char departurePlace, char arrivalPlace, TimeSpan partialDuration, TimeOnly startTime2,char departurePlace2, char arrivalPlace2, TimeSpan duration ) : base(departurePlace, arrivalPlace)
    {
        this.startTime = startTime;
        startHour = startTime.Hour;
        startMinute = startTime.Minute;
        this.partialDuration = partialDuration;
        
        this.startTime2 = startTime2;
        startHour2 = startTime2.Hour;
        startMinute2 = startTime2.Minute;
        this.departurePlace2 = departurePlace2;
        this.arrivalPlace2 = arrivalPlace2;
        
        this.duration = duration;
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