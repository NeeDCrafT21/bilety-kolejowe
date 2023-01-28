namespace UserApplication;

public class ChooseDayMenuScreen : AbstractMenuScreen<MessageTicket>
{
    private List<string> menuOptions = new List<string>()
    {
        "Wybierz dzień tygodnia twojej podróży:", "Poniedziałek", "Wtorek", "Środa", "Czwartek", "Piątek", "Sobota", "Niedziela", "Wróć"
    };

    public override void DrawMenuOptions(MessageTicket ticket)
    {
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
    
    public override int ExecuteSelectedOption(string option, int menuState, MessageTicket ticket)
    {
        return 0;
    }
}