namespace BackEndApplication;

public abstract class AbstractTicket
{
    protected TimeOnly startTime;
    protected char departurePlace;
    protected char arrivalPlace;

    public char GetArrivalPlace()
    {
        return arrivalPlace;
    }
    
    public char GetDeparturePlace()
    {
        return departurePlace;
    }

    public TimeOnly GetTime()
    {
        return startTime;
    }

    public abstract void Print();
}