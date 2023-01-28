using System.IO.Pipes;
using System.Text.Json;
using BackEndApplication;


class Program
{
    static void Main(string[] args)
    {
        var server = new NamedPipeClientStream("ticketpipe");
        server.Connect();
        StreamReader reader = new StreamReader(server);
        StreamWriter writer = new StreamWriter(server);
        
        var message = reader.ReadLine();
        
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
            

        MessageTicket ticket = JsonSerializer.Deserialize<MessageTicket>(message);
            
        ticket.Print();

        Calculator mill = new Calculator(ticket, A, B, C);

        MessageTicket2 tickets = mill.FindRoute();

        tickets.Print();

        string message2 = JsonSerializer.Serialize(tickets);

        Console.WriteLine("Wiadomość: "+message2);

        writer.WriteLine(message2);
        writer.Flush();

    }
}