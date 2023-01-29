namespace UserApplication;

public class SelectTrainScreen : AbstractMenuScreen<List<AbstractTicket>>
{
    private double ticketPrice;
    public List<string> menuOptions = new List<string>()
    {
        "Wybierz swój pociąg:", "Wyjdź"
    };

    private TimeOnly ArrivalTime(int startHour, int startMinute)
    {
        return new TimeOnly(startHour, startMinute);
    }
    public override void DrawMenuOptions(List<AbstractTicket> ticketList)
    {
        Ticket ticket = (Ticket)ticketList[0];
        TicketAdvanced ticketAdvanced = (TicketAdvanced)ticketList[1];
        Console.WriteLine($"Dostępne pociągi:\n1. Pociąg 1, odjazd: {ArrivalTime(ticket.startHour, ticket.startMinute)}, przyjazd: {ArrivalTime(ticket.startHour, ticket.startMinute).Add(ticket.duration)}\n" +
                          $"2. Pociąg 2 (PRZESIADKA), odjazd: {ArrivalTime(ticketAdvanced.startHour, ticketAdvanced.startMinute)}, przyjazd: {ArrivalTime(ticketAdvanced.startHour2, ticketAdvanced.startMinute2).Add(ticketAdvanced.duration)}\n" +
                          $"| Przesiadka w miejscowości {ticketAdvanced.departurePlace2}, przyjazd: {ArrivalTime(ticketAdvanced.startHour, ticketAdvanced.startMinute).Add(ticketAdvanced.partialDuration)}, odjazd: {ArrivalTime(ticketAdvanced.startHour2, ticketAdvanced.startMinute2)} |");
        Console.WriteLine($"{menuOptions[0]}");
        int i;
        for (i = 1; i < menuOptions.Count; i++)
        {
            if(menuOptions[i] == "Wróć" || menuOptions[i] == "Wyjdź")
                Console.WriteLine($"{0}. {menuOptions[i]}");
            else
                Console.WriteLine($"{i}. {menuOptions[i]}");
        }
    }
    
    public override int ExecuteSelectedOption(string option, int menuState, List<AbstractTicket> ticketList)
    {
        switch (option)
        {
            case "0":
                return 0;
            case "1":
                return 0;
            case "2":
                return 0;
            default:
                Console.WriteLine("| Wybierz poprawną opcję |"); 
                return menuState;
        }
    }

    public void CountTicketPrice()
    {
        
    }
}