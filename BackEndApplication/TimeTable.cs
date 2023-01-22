namespace BackEndApplication;

public class TimeTable
{
    private char city;
    private List<Ride> rides;

    public TimeTable()
    {
        
    }
    public void fillTable(char c)
    {
        switch (c)
        {
            case 'A':
            {
                List<Ride> ridesA = new List<Ride>();

                TimeOnly a = new TimeOnly(9,30);
                TimeSpan b = new TimeSpan(1, 30, 0);
                ridesA.Add(new Ride('B', a, b));
                a = new TimeOnly(15, 45);
                b = new TimeSpan(1, 30, 0);
                ridesA.Add(new Ride('B', a, b));
                a = new TimeOnly(10, 45);
                b = new TimeSpan(1, 0, 0);
                ridesA.Add(new Ride('C', a, b));
                a = new TimeOnly(19, 20);
                b = new TimeSpan(1, 0, 0);
                ridesA.Add(new Ride('C', a, b));
                city = c;
                rides = ridesA;
                break;
            }
            case 'B':
            {
                List<Ride> ridesB = new List<Ride>();

                TimeOnly a = new TimeOnly(8, 0);
                TimeSpan b = new TimeSpan(1, 30, 0);
                ridesB.Add(new Ride('A', a,b));
                a = new TimeOnly(16, 50);
                b = new TimeSpan(1, 30, 0);
                ridesB.Add(new Ride('A', a, b));
                a = new TimeOnly(5, 0);
                b = new TimeSpan(2, 0, 0);
                ridesB.Add(new Ride('C', a, b));
                a = new TimeOnly(17, 0);
                b = new TimeSpan(2, 0, 0);
                ridesB.Add(new Ride('C', a, b));
                city = c;
                rides = ridesB;
                break;
            }
            case 'C':
            {
                List<Ride> ridesC = new List<Ride>();

                TimeOnly a = new TimeOnly(8, 30);
                TimeSpan b = new TimeSpan(2, 0, 0);
                ridesC.Add(new Ride('B', a,b));
                a = new TimeOnly(17, 35);
                b = new TimeSpan(2, 0, 0);
                ridesC.Add(new Ride('B', a, b));
                a = new TimeOnly(8, 15);
                b = new TimeSpan(1, 0, 0);
                ridesC.Add(new Ride('A', a, b));
                a = new TimeOnly(13, 30);
                b = new TimeSpan(1, 0, 0);
                ridesC.Add(new Ride('A', a, b));
                city = c;
                rides = ridesC;
                break;
            }
    }
    }
}