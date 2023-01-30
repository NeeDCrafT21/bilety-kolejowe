namespace UserApplication;

public class FinalScreen : AbstractMenuScreen<List<AbstractTicket>>
{
    private double finalTicketPrice;
    public double discount { get; set; }
    public double ticketPrice { get; set; }
    public bool isTransferTrain { get; set; }
    private List<string> menuOptions = new List<string>()
    {
        "Podsumowanie:", "Zamów kolejny bilet", "Wyjdź"
    };

    private TimeOnly ArrivalTime(int startHour, int startMinute)
    {
        return new TimeOnly(startHour, startMinute);
    }
    public override void DrawMenuOptions(List<AbstractTicket> ticketList)
    {
        Console.WriteLine($"{menuOptions[0]}");
        Ticket ticket = (Ticket)ticketList[0];
        TicketAdvanced ticketAdvanced = (TicketAdvanced)ticketList[1];
        if(!isTransferTrain)
            Console.WriteLine($"Przejazd z {ticket.departurePlace} do {ticket.arrivalPlace}\n" +
                              $"Odjazd o {ArrivalTime(ticket.startHour, ticket.startMinute)}, przyjazd o {ArrivalTime(ticket.startHour, ticket.startMinute).Add(ticket.duration)}\n" +
                              $"Cena biletu: {CountFinalTicketPrice()}zł");
        else
            Console.WriteLine($"Przejazd z {ticketAdvanced.departurePlace} do {ticketAdvanced.arrivalPlace2} przez {ticketAdvanced.departurePlace2}\n" +
                              $"Odjazd o {ArrivalTime(ticketAdvanced.startHour, ticketAdvanced.startMinute)}, przyjazd o {ArrivalTime(ticketAdvanced.startHour2, ticketAdvanced.startMinute2).Add(ticketAdvanced.duration)}\n" +
                              $"Stacja pośrednia: przyjazd o {ArrivalTime(ticketAdvanced.startHour, ticketAdvanced.startMinute).Add(ticketAdvanced.partialDuration)}, odjazd o {ArrivalTime(ticketAdvanced.startHour2, ticketAdvanced.startMinute2)}\n" +
                              $"Cena biletu: {Math.Round(CountFinalTicketPrice(), 2):N2}zł");
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
            case "1":
                return 0;
            case "0":
                return -1;
            default:
                Console.WriteLine("| Wybierz poprawną opcję |"); 
                return menuState;
        }
    }

    private double CountFinalTicketPrice()
    {
        finalTicketPrice = ticketPrice * (1 - discount);
        return finalTicketPrice;
    }
}