namespace UserApplication;

public class ChooseDayMenuScreen : AbstractMenuScreen
{
    private int screenNumber;
    private List<string> menuOptions = new List<string>()
    {
        "Wybierz dzień tygodnia twojej podróży:", "Poniedziałek", "Wtorek", "Środa", "Czwartek", "Piątek", "Sobota", "Niedziela", "Wróć"
    };

    public ChooseDayMenuScreen(int screenNumber)
    {
        this.screenNumber = screenNumber;
    }
    
    public override void DrawMenuOptions()
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
    
    public override int ExecuteSelectedOption(string option, int menuState)
    {
        return 0;
    }
}