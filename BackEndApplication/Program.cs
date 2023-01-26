using System.IO.Pipes;
using BackEndApplication;


class Program
{
    static void Main(string[] args)
    {
        if (args.Length > 0)
        {
            using (PipeStream pipeClient =
                   new NamedPipeClientStream("ticketpipe"))
            {
                Console.WriteLine("[CLIENT] Current TransmissionMode: {0}.",
                    pipeClient.TransmissionMode);

                using (StreamReader sr = new StreamReader(pipeClient))
                {
                    // Display the read text to the console
                    string temp;

                    // Wait for 'sync message' from the server.
                    do
                    {
                        Console.WriteLine("[CLIENT] Wait for sync...");
                        temp = sr.ReadLine();
                    }
                    while (!temp.StartsWith("SYNC"));

                    // Read the server data and echo to the console.
                    while ((temp = sr.ReadLine()) != null)
                    {
                        Console.WriteLine("[CLIENT] Echo: " + temp);
                    }
                    /*//filling time tables
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
                    TimeOnly startTime = new TimeOnly(7, 0);

                    MessageTicket ticket = new MessageTicket(startTime, 'C', 'B'); //dodać do Ticket TimeSpan
                    //koniec przesłanych danych
                    ticket.Print();

                    Calculator mill = new Calculator(ticket, A, B, C);

                    MessageTicket2 tickets = mill.FindRoute();

                    tickets.Print();*/
                }
            }
        }
        //Console.WriteLine(RuntimeInformation.IsOSPlatform(OSPlatform.OSX));
        //Windows - .exe, Linux - None, OSX - .app

        /*Process pipeClient = new Process();
        
        pipeClient.StartInfo.UseShellExecute = true;
        pipeClient.StartInfo.CreateNoWindow = false;
        pipeClient.StartInfo.WindowStyle = ProcessWindowStyle.Normal;

        var filepath = AppDomain.CurrentDomain.BaseDirectory.Replace("BackEndApplication\\bin\\Debug\\net6.0\\","UserApplication\\bin\\Debug\\net6.0\\UserApplication.exe");
        Console.WriteLine(filepath);
        pipeClient.StartInfo.FileName = filepath;
        pipeClient.Start();
        */
        Console.ReadLine();

    }
}