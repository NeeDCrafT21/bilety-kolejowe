namespace BackEndApplication;

public class TimeTable : PreTimeTable
{
    private List<Ride<TimeOnly>> rides;
    public TimeTable(char city) : base(city){}

    public override void PrintTable()
    {
        IEnumerable<Action> pendingOpperations = from ride in rides select new Action(() => ride.PrintRide());
        foreach(Action action in pendingOpperations) action.Invoke();
    }
    
    public override void setTable(Task<List<Ride<TimeOnly>>> rides)
    {
        this.rides = rides.Result;
        Console.WriteLine("Wygenerowany rozkład jazdy dla stacji w mieście "+city+":\n");
        PrintTable();
        Console.WriteLine("\n");
    }
    
    public override async Task<List<Ride<TimeOnly>>> generateTable()
    {
        switch (city)
        {
            case 'A':
            {
                List<Ride<TimeOnly>> ridesA = new List<Ride<TimeOnly>>();
                
                TimeOnly a = new TimeOnly(9,30);
                TimeSpan b = new TimeSpan(1, 30, 0);
                ridesA.Add(new Ride<TimeOnly>('B', a, b));
                a = new TimeOnly(15, 45);
                b = new TimeSpan(1, 30, 0);
                ridesA.Add(new Ride<TimeOnly>('B', a, b));
                a = new TimeOnly(10, 45);
                b = new TimeSpan(1, 0, 0);
                ridesA.Add(new Ride<TimeOnly>('C', a, b));
                a = new TimeOnly(19, 20);
                b = new TimeSpan(1, 0, 0);
                ridesA.Add(new Ride<TimeOnly>('C', a, b));
                return ridesA;
            }
            case 'B':
            {
                List<Ride<TimeOnly>> ridesB = new List<Ride<TimeOnly>>();

                TimeOnly a = new TimeOnly(8, 0);
                TimeSpan b = new TimeSpan(1, 30, 0);
                ridesB.Add(new Ride<TimeOnly>('A', a,b));
                a = new TimeOnly(16, 50);
                b = new TimeSpan(1, 30, 0);
                ridesB.Add(new Ride<TimeOnly>('A', a, b));
                a = new TimeOnly(5, 0);
                b = new TimeSpan(2, 0, 0);
                ridesB.Add(new Ride<TimeOnly>('C', a, b));
                a = new TimeOnly(17, 0);
                b = new TimeSpan(2, 0, 0);
                ridesB.Add(new Ride<TimeOnly>('C', a, b));
                return ridesB;
            }
            case 'C':
            {
                List<Ride<TimeOnly>> ridesC = new List<Ride<TimeOnly>>();

                TimeOnly a = new TimeOnly(8, 30);
                TimeSpan b = new TimeSpan(2, 0, 0);
                ridesC.Add(new Ride<TimeOnly>('B', a,b));
                a = new TimeOnly(17, 35);
                b = new TimeSpan(2, 0, 0);
                ridesC.Add(new Ride<TimeOnly>('B', a, b));
                a = new TimeOnly(8, 15);
                b = new TimeSpan(1, 0, 0);
                ridesC.Add(new Ride<TimeOnly>('A', a, b));
                a = new TimeOnly(13, 30);
                b = new TimeSpan(1, 0, 0);
                ridesC.Add(new Ride<TimeOnly>('A', a, b));
                return ridesC;
            }
    }

        return null;
    }
}