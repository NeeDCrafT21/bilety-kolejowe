namespace BackEndApplication;

public class Ticket : AbstractTicket
{
    public int startHour { get; set; }
    public int startMinute { get; set; }
    
    private TimeSpan duration;
    public Ticket(int startHour, int startMinute, char departurePlace, char arrivalPlace, TimeSpan duration) : base(departurePlace, arrivalPlace)
    {
        this.startHour = startHour;
        this.startMinute = startMinute;
        this.duration = duration;
    }
    

    public override void Print()
    {
        Console.WriteLine("\nBilet1");
        Console.WriteLine("Przejazd o godzinie "+startHour+":"+startMinute+" z "+ departurePlace+" do "+arrivalPlace+", będzie trwał "+duration+".");
        TimeOnly arrival = new TimeOnly(startHour, startMinute);
        Console.WriteLine("Pociąg dojedzie na miejsce o godzinie "+arrival.Add(duration)+".");
    }
}