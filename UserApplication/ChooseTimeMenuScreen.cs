namespace UserApplication;

public class ChooseTimeMenuScreen : AbstractMenuScreen
{
    private Boolean choseMinutes = false;
    private int hour;
    private int minute;
    private List<string> menuOptions = new List<string>()
    {
        $"Wprowadź godzinę [HH] twojej podróży:", "Wprowadź minuty [MM] twojej podróży:", "Wróć"
    };

    public override void DrawMenuOptions()
    {
        if(!choseMinutes)
            Console.WriteLine($"{menuOptions[0]}");
        else
            Console.WriteLine($"{menuOptions[1]}");
        int i;
        for (i = 2; i < menuOptions.Count; i++)
        {
            if(menuOptions[i] == "Wróć" || menuOptions[i] == "Wyjdź")
                Console.WriteLine($"{0}. {menuOptions[i]}");
            else
                Console.WriteLine($"{i-1}. {menuOptions[i]}");
        }
    }
    
    public override int ExecuteSelectedOption(string option, int menuState, MessageTicket ticket)
    {
        if (!choseMinutes)
        {
            Console.WriteLine($"Godzina [HH]:{ticket.startMinute}");
            try
            {
                hour = Int32.Parse(option) % 25;
                ticket.startHour = hour;
                choseMinutes = true;
                return menuState;
            }
            catch (FormatException)
            {
                Console.WriteLine("Nieprawidłowy format");
            }
        }
        
        Console.WriteLine($"Godzina {ticket.startHour}:[MM]");
        try
        {
            minute = Int32.Parse(option) % 60;
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