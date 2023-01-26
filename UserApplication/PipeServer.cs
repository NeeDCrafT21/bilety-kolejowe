namespace UserApplication;

using System;
using System.IO;
using System.IO.Pipes;
using System.Diagnostics;

public class PipeServer
{
    public void SendTicketInfo(string message)
    {
        Process pipeClient = new Process();

        var filepath = AppDomain.CurrentDomain.BaseDirectory.Replace("UserApplication\\bin\\Debug\\net6.0\\","BackEndApplication\\bin\\Debug\\net6.0\\BackEndApplication.exe");
        pipeClient.StartInfo.FileName = filepath;

        using (NamedPipeServerStream pipeServer =
               new NamedPipeServerStream("ticketpipe"))
        {
            Console.WriteLine("[SERVER] Current TransmissionMode: {0}.",
                pipeServer.TransmissionMode);

            // Pass the client process a handle to the server.
            pipeClient.StartInfo.UseShellExecute = true;
            pipeClient.StartInfo.CreateNoWindow = false;
            pipeClient.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            pipeClient.Start();

            pipeServer.WaitForConnection();
            
            StreamReader reader = new StreamReader(pipeServer);
            StreamWriter writer = new StreamWriter(pipeServer);

            writer.WriteLine(message);
            writer.Flush();

            // try
            // {
            //     // Read user input and send that to the client process.
            //     using (StreamWriter sw = new StreamWriter(pipeServer))
            //     {
            //         sw.AutoFlush = true;
            //         // Send a 'sync message' and wait for client to receive it.
            //         sw.WriteLine("SYNC");
            //         pipeServer.WaitForPipeDrain();
            //         // Send the console input to the client process.
            //         Console.Write("[SERVER] Enter text: ");
            //         sw.WriteLine(Console.ReadLine());
            //     }
            // }
            // // Catch the IOException that is raised if the pipe is broken
            // // or disconnected.
            // catch (IOException e)
            // {
            //     Console.WriteLine("[SERVER] Error: {0}", e.Message);
            // }
        }

        pipeClient.WaitForExit();
        pipeClient.Close();
        Console.WriteLine("[SERVER] Client quit. Server terminating.");
    }
}