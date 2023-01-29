namespace UserApplication;

public class SelectTrainScreen : AbstractMenuScreen<List<AbstractTicket>>
{
    public double ticketPrice1 { get; private set; }
    public double ticketPrice2 { get; private set; }
    public bool isTransferTrain { get; private set; }
    public List<string> menuOptions = new List<string>()
    {
        "Wybierz swój pociąg:", "Wróć"
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
        var tempTicketPrice1 = () => ticket.duration.TotalMinutes * 2;
        ticketPrice1 = tempTicketPrice1();
        var tempTicketPrice2 = () =>
            (ticketAdvanced.partialDuration.TotalMinutes + ticketAdvanced.duration.TotalMinutes) * 0.75;
        ticketPrice2 = tempTicketPrice2();
        Console.WriteLine($"Dostępne pociągi:\n1. | Cena: {ticketPrice1}zł |\nPociąg 1, odjazd: {ArrivalTime(ticket.startHour, ticket.startMinute)}, przyjazd: {ArrivalTime(ticket.startHour, ticket.startMinute).Add(ticket.duration)}\n" +
                          $"2. | Cena: {ticketPrice2}zł |\nPociąg 2 (PRZESIADKA), odjazd: {ArrivalTime(ticketAdvanced.startHour, ticketAdvanced.startMinute)}, przyjazd: {ArrivalTime(ticketAdvanced.startHour2, ticketAdvanced.startMinute2).Add(ticketAdvanced.duration)}\n" +
                          $"| Przesiadka w miejscowości {ticketAdvanced.departurePlace2}, przyjazd: {ArrivalTime(ticketAdvanced.startHour, ticketAdvanced.startMinute).Add(ticketAdvanced.partialDuration)}, odjazd: {ArrivalTime(ticketAdvanced.startHour2, ticketAdvanced.startMinute2)} |");
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
                isTransferTrain = false;
                return 6;
            case "2":
                isTransferTrain = true;
                return 6;
            default:
                Console.WriteLine("| Wybierz poprawną opcję |"); 
                return menuState;
        }
    }
}