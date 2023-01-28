namespace BackEndApplication;

[Message(messageType = "entering")]
public class MessageTicket : AbstractTicket
{
    public int startHour { get; set; }
    public int startMinute { get; set; }
    public MessageTicket(int startHour, int startMinute, char departurePlace, char arrivalPlace) : base(departurePlace, arrivalPlace)
    {
        this.startHour = startHour;
        this.startMinute = startMinute;
    }
    
    
    public override void Print()
    {
        Console.WriteLine("Szukam przejazdu z "+departurePlace+" do "+arrivalPlace+" od godziny "+startHour+":"+startMinute+".\n");
    }
}