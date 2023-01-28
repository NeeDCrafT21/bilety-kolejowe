﻿namespace BackEndApplication;

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
        int i = tables.FindIndex(a => a.GetCity() == ticket.GetDeparturePlace());
        int j = tables.FindIndex(a => a.GetCity() != ticket.GetArrivalPlace() && a.GetCity() != ticket.GetDeparturePlace());
        
        //find closest ride without train change
        TimeOnly ticketTime = new TimeOnly(ticket.startHour, ticket.startMinute);
        Ride<TimeOnly> ride1 = tables[i].GetRides().SkipWhile(p=> 
            p.getTime() <= ticketTime || p.getDestination() != ticket.GetArrivalPlace()).FirstOrDefault();
        if(ride1 == null)
        {
            if (tables[i].GetRides()[0].getDestination() == ticket.GetArrivalPlace())
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
            p.getTime() <= ride2.getTime().Add(ride2.getDuration()) || p.getDestination() != ticket.GetArrivalPlace()).FirstOrDefault();
        
        if (ride3 == null)
        {
            if (tables[j].GetRides()[0].getDestination() == ticket.GetArrivalPlace())
            {
                ride3 = tables[j].GetRides()[0];
            }
            else
            {
                ride3 = tables[j].GetRides()[4];
            }
        }
        
        List<AbstractTicket> temp = new List<AbstractTicket>();
        AbstractTicket temp1 = new Ticket(ride1.getTime().Hour,ride1.getTime().Minute,ticket.GetDeparturePlace(),ticket.GetArrivalPlace(),ride1.getDuration());
        int hour = ride2.getTime().Hour;
        int minute = ride2.getTime().Minute;
        AbstractTicket temp2 = new TicketAdvanced(hour, minute,ticket.GetDeparturePlace(),ride2.getDestination(),ride2.getDuration(),ride3.getTime().Hour,ride3.getTime().Minute,tables[j].GetCity(),ticket.GetArrivalPlace(), ride3.getDuration());
        
        
        temp.Add(temp1);
        temp.Add(temp2);

        MessageTicket2 message = new MessageTicket2((Ticket)temp[0],(TicketAdvanced)temp[1]);
        output = message;
        
        return message;
    }
}