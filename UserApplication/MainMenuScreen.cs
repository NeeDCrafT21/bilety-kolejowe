namespace UserApplication;

using System;

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
    
    public override int ExecuteSelectedOption(string option, int menuState)
    {
        switch (option)
        {
            case "1":
                return 1;
            case "2":
                return 2;
            case "0":
                return -1;
            default:
                Console.WriteLine("| Wybierz poprawną opcję |"); 
                return menuState;
        }
    }
}