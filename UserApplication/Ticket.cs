namespace UserApplication;

public class Ticket : AbstractTicket
{
    public int startHour { get; }
    public int startMinute { get; }
    public TimeSpan duration { get; }
    public Ticket(int startHour, int startMinute, char departurePlace, char arrivalPlace, TimeSpan duration) : base(departurePlace, arrivalPlace)
    {
        this.startHour = startHour;
        this.startMinute = startMinute;
        this.duration = duration;
    }
}