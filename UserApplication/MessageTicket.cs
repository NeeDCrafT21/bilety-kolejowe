namespace UserApplication;

public class MessageTicket : AbstractTicket
{
    public MessageTicket(int startHour, int startMinute, char departurePlace, char arrivalPlace) : base(startHour, startMinute, departurePlace, arrivalPlace)
    {
        // this.startTime = startTime;
        // this.departurePlace = departurePlace;
        // this.arrivalPlace = arrivalPlace;
    }

    public override void Print()
    {
        Console.WriteLine("Hello world");
    }
}