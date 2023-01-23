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

        var (taskA, taskB, taskC) = (A.generateTable(), B.generateTable(), C.generateTable());
        var tempA = (async () => await taskA);
        A.setTable(tempA());
        var tempB = (async () => await taskB);
        B.setTable(tempB());
        var tempC = (async () => await taskC);
        C.setTable(tempC());
        C.PrintTable();

        //TODO dane przesłane
        TimeOnly startTime = new TimeOnly(8,0);
        Ticket<TimeOnly> ticket = new Ticket<TimeOnly>(startTime,'A','B');
        //koniec przesłanych danych

        

    }
}