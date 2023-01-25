namespace BackEndApplication;

[Message(messageType = "entering")]
public class MessageTicket : AbstractTicket
{
    public MessageTicket(TimeOnly startTime, char departurePlace, char arrivalPlace)
    {
        this.startTime = startTime;
        this.departurePlace = departurePlace;
        this.arrivalPlace = arrivalPlace;
    }

    public override void Print()
    {
        Console.WriteLine("\n\nSzukam przejazdu z "+departurePlace+" do "+arrivalPlace+" od godziny "+startTime+".\n");
    }
}