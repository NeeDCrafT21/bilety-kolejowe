using System.IO.Pipes;
using System.Text.Json;
using BackEndApplication;


class Program
{
    static void Main(string[] args)
    {
        TimeTable A = new TimeTable('A');
        TimeTable B = new TimeTable('B');
        TimeTable C = new TimeTable('C');

        var (taskA, taskB, taskC) = (A.GenerateTable(), B.GenerateTable(), C.GenerateTable());
        var tempA = (async () => await taskA);
        var tempB = (async () => await taskB);
        var tempC = (async () => await taskC);
        A.SetTable(tempA());
        B.SetTable(tempB());
        C.SetTable(tempC());
        
        while (true)
        {
            var server = new NamedPipeClientStream("ticketpipe");
            server.Connect();
            StreamReader reader = new StreamReader(server);
            StreamWriter writer = new StreamWriter(server);
            var message = reader.ReadLine();

            MessageTicket ticket = JsonSerializer.Deserialize<MessageTicket>(message);

            ticket.Print();

            Calculator mill = new Calculator(ticket, A, B, C);

            MessageTicket2 tickets = mill.FindRoute();

            tickets.Print();

            string message2 = JsonSerializer.Serialize(tickets);

            Console.WriteLine("\nWiadomość: " + message2);

            writer.WriteLine(message2);
            writer.Flush();
            server.Close();
        }
    }
}