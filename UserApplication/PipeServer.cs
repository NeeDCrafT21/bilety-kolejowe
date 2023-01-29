using System.Text.Json;

namespace UserApplication;

using System;
using System.IO;
using System.IO.Pipes;
using System.Diagnostics;

public class PipeServer
{
    private MessageTicket2 trainInfo; //{ get; set; }
    private List<AbstractTicket> ticketList = new List<AbstractTicket>();

    public async Task<List<AbstractTicket>> SendTicketInfo(string sendMessage)
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

            await writer.WriteLineAsync(sendMessage);
            await writer.FlushAsync();
            
            //Thread.Sleep(2000);

            var returnMessage = await reader.ReadLineAsync();
            Console.WriteLine($"Czytam returnMessage...\n{returnMessage}");
            
            trainInfo = JsonSerializer.Deserialize<MessageTicket2>(returnMessage);
            ticketList.Add(trainInfo.ticket);
            ticketList.Add(trainInfo.ticketAdvanced);
        }

        await pipeClient.WaitForExitAsync();
        pipeClient.Close();
        Console.WriteLine("[SERVER] Client quit. Server terminating.");

        return ticketList;
    }
}