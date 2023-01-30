namespace UserApplication;

public class TicketAdvanced : AbstractTicket
{
    public int startHour { get; }
    public int startMinute { get; }
    
    public int startHour2 { get; }
    public int startMinute2 { get; }
    public char departurePlace2{ get; }
    public char arrivalPlace2{ get; }
    public TimeSpan partialDuration{ get; }
    public TimeSpan duration{ get; }
    
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
}