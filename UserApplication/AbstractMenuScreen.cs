namespace UserApplication;

public abstract class AbstractMenuScreen
{
    private int number { get; }
    public List<string> _menuOptions { get; }

    public abstract void DrawMenuOptions();
    // {
    //     Console.WriteLine($"{menuOptions[0]}");
    //     int i;
    //     for (i = 1; i < menuOptions.Count; i++)
    //     {
    //         if(menuOptions[i] == "Wróć" || menuOptions[i] == "Wyjdź")
    //             Console.WriteLine($"{0}. {menuOptions[i]}");
    //         else
    //             Console.WriteLine($"{i}. {menuOptions[i]}");
    //     }
    //     
    // }
    
    public int getNumber()
    {
        return number;
    }
}