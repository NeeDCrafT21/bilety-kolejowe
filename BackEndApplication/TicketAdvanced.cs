namespace BackEndApplication;

public class TicketAdvanced : AbstractTicket
{
    public int startHour { get; set; }
    public int startMinute { get; set; }
    
    public int startHour2 { get; set; }
    public int startMinute2 { get; set; }
    public char departurePlace2{ get; set; }
    public char arrivalPlace2{ get; set; }
    public TimeSpan partialDuration{ get; set; }
    public TimeSpan duration{ get; set; }
    
    public TicketAdvanced(int startHour, int startMinute, char departurePlace, char arrivalPlace, TimeSpan partialDuration, int startHour2, int startMinute2,char departurePlace2, char arrivalPlace2, TimeSpan duration ) : base(departurePlace, arrivalPlace)
    {
        this.startHour = startHour;
        this.startMinute = startMinute;
        this.partialDuration = partialDuration;
        
        this.startHour2 = startHour2;
        this.startMinute2 = startMinute2;
        this.departurePlace2 = departurePlace2;
        this.arrivalPlace2 = arrivalPlace2;
        
        this.duration = duration;
    }
    
    
    public override void Print()
    {
        TimeOnly time = new TimeOnly(startHour, startMinute);
        TimeOnly time2 = new TimeOnly(startHour2, startMinute2);
        Console.WriteLine("\nBilet2");
        Console.WriteLine("Przejazd o godzinie "+time+" z "+ departurePlace+" do "+arrivalPlace+", będzie trwał "+partialDuration+".");
        Console.WriteLine("Pociąg dojedzie do stacji przesiadkowej o godzinie "+time.Add(partialDuration)+".");
        Console.WriteLine("Przesiadka na pociąg o godzinie "+time2+" z "+ departurePlace2+" do "+arrivalPlace2+", przejazd będzie trwał "+duration+".");
        Console.WriteLine("Pociąg dojedzie na miejsce o godzinie "+time2.Add(duration)+".");
    }
}