namespace UserApplication;

public class SelectDiscountScreen : AbstractMenuScreen<List<AbstractTicket>>
{
    public List<string> menuOptions = new List<string>()
    {
        "Witaj w systemie zamwiania biletów.\nWybierz opcję aby rozpocząć:", "Wybierz dzień podróży", "Wybierz godzinę podróży", "Wybierz miejsce podróży", "Wyświetl dostępne pociągi", "Wyjdź"
    };

    public override void DrawMenuOptions(List<AbstractTicket> ticketList)
    {
        //Console.WriteLine($"Godzina wyjazdu: {((ticket.startHour / 10) != 0 ? ticket.startHour : "0" + ticket.startHour.ToString())}:{((ticket.startMinute / 10) != 0 ? ticket.startMinute : "0" + ticket.startMinute.ToString())}\nWyjazd z {ticket.departurePlace} do {ticket.arrivalPlace}");
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
            case "1":
                return 1;
            case "2":
                return 2;
            case "3":
                return 3;
            case "4":
                return 4;
            case "0":
                return -1;
            default:
                Console.WriteLine("| Wybierz poprawną opcję |"); 
                return menuState;
        }
    }
}