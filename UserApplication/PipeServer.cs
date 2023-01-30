using System.Text.Json;

namespace UserApplication;

using System;
using System.IO;
using System.IO.Pipes;
using System.Diagnostics;

public class PipeServer
{
    private MessageTicket2 trainInfo;
    private List<AbstractTicket> ticketList = new List<AbstractTicket>();

    public async Task<List<AbstractTicket>> SendTicketInfo(string sendMessage)
    {
        await using (NamedPipeServerStream pipeServer =
               new NamedPipeServerStream("ticketpipe"))
        {
            pipeServer.WaitForConnection();
            
            StreamReader reader = new StreamReader(pipeServer);
            StreamWriter writer = new StreamWriter(pipeServer);

            await writer.WriteLineAsync(sendMessage);
            await writer.FlushAsync();

            var returnMessage = await reader.ReadLineAsync();
            Console.WriteLine($"Czytam returnMessage...\n{returnMessage}");
            
            trainInfo = JsonSerializer.Deserialize<MessageTicket2>(returnMessage);
            ticketList.Add(trainInfo.ticket);
            ticketList.Add(trainInfo.ticketAdvanced);
        }
        
        Console.WriteLine("Zakończono połączenie");

        return ticketList;
    }
}