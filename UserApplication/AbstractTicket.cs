namespace UserApplication;

public abstract class AbstractTicket
{
    //public TimeOnly startTime { get; set; }
    public int startHour { get; set; }
    public int startMinute { get; set; }
    public char departurePlace { get; set; }
    public char arrivalPlace { get; set; }

    protected AbstractTicket(int startHour, int startMinute, char departurePlace, char arrivalPlace)
    {
        this.startHour = startHour;
        this.startMinute = startMinute;
        this.departurePlace = departurePlace;
        this.arrivalPlace = arrivalPlace;
    }

    // public char GetArrivalPlace()
    // {
    //     return arrivalPlace;
    // }
    //
    // public char GetDeparturePlace()
    // {
    //     return departurePlace;
    // }
    //
    // public TimeOnly GetTime()
    // {
    //     return startTime;
    // }

    public abstract void Print();
}