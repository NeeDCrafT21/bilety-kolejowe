namespace UserApplication;

public abstract class AbstractTicket
{
    public TimeOnly startTime { get; set; }
    public char departurePlace { get; set; }
    public char arrivalPlace { get; set; }

    protected AbstractTicket(TimeOnly startTime, char departurePlace, char arrivalPlace)
    {
        this.startTime = startTime;
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