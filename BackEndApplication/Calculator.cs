namespace BackEndApplication;

public class Calculator
{
    private MessageTicket ticket;
    private List<TimeTable> tables = new List<TimeTable>();
    private MessageTicket2 output;

    public Calculator(MessageTicket ticket, params TimeTable[] tables)
    {
        this.ticket = ticket;
        foreach (TimeTable table in tables)
        {
            this.tables.Add(table);
        }
    }
    
    public MessageTicket2 FindRoute()
    {
        int i = tables.FindIndex(a => a.GetCity() == ticket.departurePlace);
        int j = tables.FindIndex(a => a.GetCity() != ticket.arrivalPlace && a.GetCity() != ticket.departurePlace);
        
        //find closest ride without train change
        TimeOnly ticketTime = new TimeOnly(ticket.startHour, ticket.startMinute);
        Ride<TimeOnly> ride1 = tables[i].GetRides().SkipWhile(p=> 
            p.getTime() <= ticketTime || p.getDestination() != ticket.arrivalPlace).FirstOrDefault();
        if(ride1 == null)
        {
            if (tables[i].GetRides()[0].getDestination() == ticket.arrivalPlace)
            {
                ride1 = tables[i].GetRides()[0];
            }
            else
            {
                ride1 = tables[i].GetRides()[4];
            }
        }

        //find closest ride with train change
        Ride<TimeOnly> ride2 = tables[i].GetRides().SkipWhile(p =>
            p.getTime() <= ticketTime || p.getDestination() != tables[j].GetCity()).FirstOrDefault();
        if (ride2 == null)
        {
            if (tables[i].GetRides()[0].getDestination() == tables[j].GetCity())
            {
                ride2 = tables[i].GetRides()[0];
            }
            else
            {
                ride2 = tables[i].GetRides()[4];
            }
        }
        
        Ride<TimeOnly> ride3 = tables[j].GetRides().SkipWhile(p=> 
            p.getTime() <= ride2.getTime().Add(ride2.getDuration()) || p.getDestination() != ticket.arrivalPlace).FirstOrDefault();
        
        if (ride3 == null)
        {
            if (tables[j].GetRides()[0].getDestination() == ticket.arrivalPlace)
            {
                ride3 = tables[j].GetRides()[0];
            }
            else
            {
                ride3 = tables[j].GetRides()[4];
            }
        }
        

        AbstractTicket temp1 = new Ticket(ride1.getTime(),ticket.departurePlace,ticket.arrivalPlace,ride1.getDuration());
        AbstractTicket temp2 = new TicketAdvanced(ride2.getTime(),ticket.departurePlace,ride2.getDestination(),ride2.getDuration(),ride3.getTime(),tables[j].GetCity(),ticket.arrivalPlace, ride3.getDuration());


        output = new MessageTicket2((Ticket)temp1,(TicketAdvanced)temp2);

        return output;
    }
}