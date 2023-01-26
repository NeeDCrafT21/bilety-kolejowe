﻿namespace BackEndApplication;

public class Calculator
{
    private MessageTicket ticket;
    private List<TimeTable> tables = new List<TimeTable>();
    private List<AbstractTicket> output;

    public Calculator(MessageTicket ticket, params TimeTable[] tables)
    {
        this.ticket = ticket;
        foreach (TimeTable table in tables)
        {
            this.tables.Add(table);
        }
    }

    public void Print()
    {
        output[0].Print();
        output[1].Print();
    }
    public List<AbstractTicket> FindRoute()
    {
        int i = tables.FindIndex(a => a.GetCity() == ticket.GetDeparturePlace());
        int j = tables.FindIndex(a => a.GetCity() != ticket.GetArrivalPlace() && a.GetCity() != ticket.GetDeparturePlace());
        
        //find closest ride without train change
        Ride<TimeOnly> ride1 = tables[i].GetRides().SkipWhile(p=> 
            p.getHour() <= ticket.GetTime() || p.getDestination() == ticket.GetArrivalPlace()).FirstOrDefault();
        if(ride1 == null)
        {
            if (tables[i].GetRides()[0].getDestination() == ticket.GetArrivalPlace())
            {
                ride1 = tables[i].GetRides()[0];
            }
            else
            {
                ride1 = tables[i].GetRides()[2];
            }
        }

        Ride<TimeOnly> ride2 = tables[i].GetRides().SkipWhile(p =>
            p.getHour() <= ticket.GetTime() || p.getDestination() == tables[j].GetCity()).FirstOrDefault();
        if (ride2 == null)
        {
            if (tables[i].GetRides()[0].getDestination() == tables[j].GetCity())
            {
                ride2 = tables[i].GetRides()[0];
            }
            else
            {
                ride2 = tables[i].GetRides()[2];
            }
        }

        int x = 0;
        Ride<TimeOnly> ride3 = tables[j].GetRides().SkipWhile(p=> 
            p.getHour() <= ticket.GetTime().Add(ride2.getDuration(), out x) || p.getDestination() == ticket.GetArrivalPlace()).FirstOrDefault();
        
        if (ride3 == null)
        {
            if (tables[j].GetRides()[0].getDestination() == ticket.GetArrivalPlace())
            {
                ride3 = tables[j].GetRides()[0];
            }
            else
            {
                ride3 = tables[j].GetRides()[2];
            }
        }
        
        List<AbstractTicket> temp = new List<AbstractTicket>();
        AbstractTicket temp1 = new Ticket(ride1.getHour(),ticket.GetDeparturePlace(),ticket.GetArrivalPlace(),ride1.getDuration());
        AbstractTicket temp2 = new TicketAdvanced(ride2.getHour(),ticket.GetDeparturePlace(),ride2.getDestination(),ride2.getDuration(),ride3.getHour(),tables[j].GetCity(),ticket.GetArrivalPlace(), ride3.getDuration());
        
        
        temp.Add(temp1);
        temp.Add(temp2);
        output = temp;
        
        return temp;
    }
}