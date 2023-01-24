using System.Globalization;

namespace UserApplication;

public class MainMenuScreen : AbstractMenuScreen
{
    private int screenNumber;

    public List<string> menuOptions { get; } = new List<string>()
    {
        "Witaj w systemie zamwiania biletów.\nWybierz opcję aby rozpocząć:", "Wybierz dzień podróży", "Wybierz godzinę podróży", "Wyjdź"
    };

    public List<string> MenuOptions => menuOptions;

    public MainMenuScreen(int screenNumber)
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
    
    

    /*
    public int ExecuteSelectedOption(string option)
    {
        
    }
    */
}