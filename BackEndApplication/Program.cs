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
            CancellationToken cancellationToken = new CancellationToken();
            using (var server = new NamedPipeClientStream("ticketpipe"))
            {
                MessageTicket ticket = new MessageTicket(0,0,'A','B');
                server.Connect();
                StreamReader reader = new StreamReader(server);
                StreamWriter writer = new StreamWriter(server);
                var message = reader.ReadLine();
                try
                {
                    ticket = JsonSerializer.Deserialize<MessageTicket>(message);
                }
                catch (System.ArgumentNullException e)
                {
                    Console.Clear();
                    server.Dispose();
                    return;
                }

                ticket.Print();

                Calculator mill = new Calculator(ticket, A, B, C);

                MessageTicket2 tickets = mill.FindRoute();

                tickets.Print();

                string message2 = JsonSerializer.Serialize(tickets);

                writer.WriteLine(message2);
                writer.Flush();
                server.Close();
            }
        }
    }
}