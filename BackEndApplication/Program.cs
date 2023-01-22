using System.Collections;
using BackEndApplication;


class Program
{
    static void Main(string[] args)
    {
        //filling time tables
        TimeTable A = new TimeTable();
        TimeTable B = new TimeTable();
        TimeTable C = new TimeTable();

        A.fillTable('A');
        B.fillTable('B');
        C.fillTable('C');
        
        //TODO dane przesłane
        TimeOnly startTime = new TimeOnly(8,0);
        char departurePlace = 'A';
        char arrivalPlace = 'B';
        //koniec przesłanych danych
        
        
    }
}