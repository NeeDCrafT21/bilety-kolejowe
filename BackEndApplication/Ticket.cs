namespace BackEndApplication;

[Serializable()]
public class Ticket : AbstractTicket
{
    [NonSerialized()] public TimeOnly startTime;
    public int startHour { get; set; }
    public int startMinute { get; set; }
    public TimeSpan duration { get; set; }
    public Ticket(TimeOnly startTime, char departurePlace, char arrivalPlace, TimeSpan duration) : base(departurePlace, arrivalPlace)
    {
        this.startTime = startTime;
        startHour = startTime.Hour;
        startMinute = startTime.Minute;
        this.duration = duration;
    }
    

    public override void Print()
    {
        Console.WriteLine("\nBilet1");
        Console.WriteLine("Przejazd o godzinie "+startTime+" z "+ departurePlace+" do "+arrivalPlace+", będzie trwał "+duration+".");
        Console.WriteLine("Pociąg dojedzie na miejsce o godzinie "+startTime.Add(duration)+".");
    }
}