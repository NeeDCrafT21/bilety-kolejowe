namespace BackEndApplication;

public class Ticket<T>
{
    private T startTime;
    private char departurePlace;
    private char arrivalPlace;

    public Ticket(T startTime, char departurePlace, char arrivalPlace)
    {
        this.startTime = startTime;
        this.departurePlace = departurePlace;
        this.arrivalPlace = arrivalPlace;
    }
    
    
}