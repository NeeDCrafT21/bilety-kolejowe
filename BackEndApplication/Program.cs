using System.IO.Pipes;
using System.Text.Json;
using BackEndApplication;


class Program
{
    static void Main(string[] args)
    {
        var server = new NamedPipeServerStream("PipesOfPiece");
        server.WaitForConnection();
        StreamReader reader = new StreamReader(server);
        StreamWriter writer = new StreamWriter(server);
        
        var message = reader.ReadLine();

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

            
            /* Struktura do testowania dzialania programu bez komunikacji
            TimeOnly startTime = new TimeOnly(8, 20);
            MessageTicket ticket = new MessageTicket(startTime, 'C', 'A');*/
            
            MessageTicket ticket = JsonSerializer.Deserialize<MessageTicket>(message);
            
            ticket.Print();

            Calculator mill = new Calculator(ticket, A, B, C);

            MessageTicket2 tickets = mill.FindRoute();

            tickets.Print();

            var message2 = JsonSerializer.Serialize(tickets);
            writer.WriteLine(message2);
            writer.Flush();

    }
}