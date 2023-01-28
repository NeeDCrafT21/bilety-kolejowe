namespace UserApplication;

public class SelectTrainScreen : AbstractMenuScreen<MessageTicket2>
{
    public List<string> menuOptions = new List<string>()
    {
        "Wybierz swój pociąg:", "Wyjdź"
    };

    private TimeOnly ArrivalTime(int startHour, int startMinute)
    {
        return new TimeOnly(startHour, startMinute);
    }
    public override void DrawMenuOptions(MessageTicket2 trainInfo)
    {
        Console.WriteLine($"Dostępne pociągi:\n1. Pociąg 1, odjazd: {ArrivalTime(trainInfo.ticket.startHour, trainInfo.ticket.startMinute)}, przyjazd: {ArrivalTime(trainInfo.ticket.startHour, trainInfo.ticket.startMinute).Add(trainInfo.ticket.duration)}\n" +
                          $"2. Pociąg 2 (PRZESIADKA), odjazd: {ArrivalTime(trainInfo.ticketAdvanced.startHour, trainInfo.ticketAdvanced.startMinute)}, przyjazd: {ArrivalTime(trainInfo.ticketAdvanced.startHour2, trainInfo.ticketAdvanced.startMinute2).Add(trainInfo.ticketAdvanced.duration)}\n" +
                          $"| Przesiadka w miejscowości {trainInfo.ticketAdvanced.departurePlace2}, przyjazd: {ArrivalTime(trainInfo.ticketAdvanced.startHour, trainInfo.ticketAdvanced.startMinute).Add(trainInfo.ticketAdvanced.partialDuration)}, odjazd: {ArrivalTime(trainInfo.ticketAdvanced.startHour2, trainInfo.ticketAdvanced.startMinute2)} |");
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
    
    public override int ExecuteSelectedOption(string option, int menuState, MessageTicket2 trainInfo)
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
}