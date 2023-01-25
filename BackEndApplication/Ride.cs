using System.Collections;

namespace BackEndApplication;

public class Ride<T>
{
    private char destination;
    private T time;
    private TimeSpan duration;

    public Ride(char destination, T time, TimeSpan duration)
    {
        this.destination = destination;
        this.time = time;
        this.duration = duration;
    }

    public void PrintRide()
    {
        Console.WriteLine("Przejazd do "+destination+" o godzinie "+time+" będzie trwał "+duration+".");
    }
    public char getDestination()
    {
        return destination;
    }
    public T getTime()
    {
        return time;
    }
    public TimeSpan getDuration()
    {
        return duration;
    }
    
}