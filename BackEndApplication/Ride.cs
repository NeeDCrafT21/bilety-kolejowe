using System.Collections;

namespace BackEndApplication;

public class Ride
{
    private char destination;
    private TimeOnly hour;
    private TimeSpan duration;

    public Ride(char destination, TimeOnly hour, TimeSpan duration)
    {
        this.destination = destination;
        this.hour = hour;
        this.duration = duration;
    }

    public char getDestination()
    {
        return destination;
    }
    public TimeOnly getHour()
    {
        return hour;
    }

    public TimeSpan getDuration()
    {
        return duration;
    }
}