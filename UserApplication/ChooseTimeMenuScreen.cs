namespace UserApplication;

public class ChooseTimeMenuScreen : AbstractMenuScreen<MessageTicket>
{
    private Boolean choseMinutes = false;
    private int hour;
    private int minute;
    private List<string> menuOptions = new List<string>()
    {
        $"Wprowadź godzinę twojej podróży:", "Wprowadź minuty twojej podróży:", "Wróć"
    };

    public override void DrawMenuOptions(MessageTicket ticket)
    {
        if (!choseMinutes)
        {
            Console.WriteLine($"Wprowadzanie godziny: [HH]:{((ticket.startMinute / 10) != 0 ? ticket.startMinute : "0" + ticket.startMinute.ToString())}");
            Console.WriteLine($"{menuOptions[0]}");
        }
        else
        {
            Console.WriteLine($"Wprowadzanie godziny: {((ticket.startHour / 10) != 0 ? ticket.startHour : "0" + ticket.startHour.ToString())}:[MM]");
            Console.WriteLine($"{menuOptions[1]}");
        }
        int i;
        for (i = 2; i < menuOptions.Count; i++)
        {
            if(menuOptions[i] == "Wróć" || menuOptions[i] == "Wyjdź")
                Console.WriteLine($"q. {menuOptions[i]}");
            else
                Console.WriteLine($"{i-1}. {menuOptions[i]}");
        }
    }
    
    public override int ExecuteSelectedOption(string option, int menuState, MessageTicket ticket)
    {
        if (option == "q")
            return 0;
        if (!choseMinutes)
        {
            try
            {
                hour = Math.Abs(Int32.Parse(option) % 25);
                ticket.startHour = hour;
                choseMinutes = true;
                return menuState;
            }
            catch (FormatException)
            {
                Console.WriteLine("Nieprawidłowy format");
            }
        }
        
        try
        {
            minute = Math.Abs(Int32.Parse(option) % 60);
            ticket.startMinute = minute;
            return 0;
        }
        catch (FormatException)
        {
            Console.WriteLine("Nieprawidłowy format");
        }

        return 0;
    }
    
    public void ResetChoiceState()
    {
        choseMinutes = false;
    }
}