namespace UserApplication;

public abstract class AbstractTicket
{
    public char departurePlace { get; set; }
    public char arrivalPlace { get; set; }

    protected AbstractTicket(char departurePlace, char arrivalPlace)
    {
        this.departurePlace = departurePlace;
        this.arrivalPlace = arrivalPlace;
    }
}