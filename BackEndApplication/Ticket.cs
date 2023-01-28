namespace BackEndApplication;

[Serializable()]
public class Ticket : AbstractTicket
{
    [NonSerialized()] public TimeOnly startTime = new TimeOnly();
    public int startHour { get; set; }
    public int startMinute { get; set; }
    
    public TimeSpan duration { get; set; }
    public Ticket(int startHour, int startMinute, char departurePlace, char arrivalPlace, TimeSpan duration) : base(departurePlace, arrivalPlace)
    {
        this.startHour = startHour;
        this.startMinute = startMinute;
        startTime = new TimeOnly(startHour, startMinute);
        this.duration = duration;
    }
    

    public override void Print()
    {
        Console.WriteLine("\nBilet1");
        Console.WriteLine("Przejazd o godzinie "+startTime+" z "+ departurePlace+" do "+arrivalPlace+", będzie trwał "+duration+".");
        Console.WriteLine("Pociąg dojedzie na miejsce o godzinie "+startTime.Add(duration)+".");
    }
}