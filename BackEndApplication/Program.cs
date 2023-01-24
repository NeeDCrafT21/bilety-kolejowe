using System.Collections;
using BackEndApplication;


class Program
{
    static void Main(string[] args)
    {
        //filling time tables
        TimeTable A = new TimeTable('A');
        TimeTable B = new TimeTable('B');
        TimeTable C = new TimeTable('C');

        var (taskA, taskB, taskC) = (A.GenerateTable(), B.GenerateTable(), C.GenerateTable());
        var tempA = (async () => await taskA);
        A.SetTable(tempA());
        var tempB = (async () => await taskB);
        B.SetTable(tempB());
        var tempC = (async () => await taskC);
        C.SetTable(tempC());

        //TODO dane przesłane
        TimeOnly startTime = new TimeOnly(20,0);
        MessageTicket ticket = new MessageTicket(startTime,'A','B');//dodać do Ticket TimeSpan
        //koniec przesłanych danych

        Calculator mill = new Calculator(ticket, A, B, C);

        List<AbstractTicket> a = mill.FindRoute();
        mill.Print();

    }
}