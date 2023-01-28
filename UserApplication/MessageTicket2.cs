namespace UserApplication;

[Message(messageType = "entering")]
public class MessageTicket2
{
    public Ticket ticket { get; set; }

    public TicketAdvanced ticketAdvanced { get; set; }

    public MessageTicket2(Ticket ticket, TicketAdvanced ticketAdvanced)
    {
        this.ticket = ticket;
        this.ticketAdvanced = ticketAdvanced;
    }
}