namespace UserApplication;

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
}