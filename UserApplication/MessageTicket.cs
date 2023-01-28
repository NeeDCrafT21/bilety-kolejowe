namespace UserApplication;

[Message(messageType = "leaving")]
public class MessageTicket : AbstractTicket
{
    public int startHour { get; set; }
    public int startMinute { get; set; }
    public MessageTicket(int startHour, int startMinute, char departurePlace, char arrivalPlace) : base(departurePlace, arrivalPlace)
    {
        this.startHour = startHour;
        this.startMinute = startMinute;
    }
}