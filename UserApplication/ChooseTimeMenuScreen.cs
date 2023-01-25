namespace UserApplication;

public class ChooseTimeMenuScreen : AbstractMenuScreen
{
    private List<string> menuOptions = new List<string>()
    {
        "Wprowadź czas twojej podróży:", "Wróć"
    };

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