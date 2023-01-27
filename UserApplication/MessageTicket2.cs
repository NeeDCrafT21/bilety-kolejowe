namespace UserApplication;

[Message(messageType = "leaving")]
public class MessageTicket2
{
    private List<AbstractTicket> message;

    public MessageTicket2(List<AbstractTicket> message)
    {
        this.message = message;
    }

    public List<AbstractTicket> getMessage()
    {
        return message;
    }

    public void Print()
    {
        message[0].Print();
        message[1].Print();
    }
}