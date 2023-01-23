namespace UserApplication;

public class MenuWindow
{
    private int number;
    private List<string> menuOptions = new List<string>();

    public MenuWindow(int number, List<string> menuOptions)
    {
        this.number = number;
        this.menuOptions = menuOptions;
    }
    
    public void DrawMenuOptions()
    {
        int i;
        for (i = 0; i < menuOptions.Count; i++)
        {
            if(menuOptions[i] == "Wróć" || menuOptions[i] == "Wyjdź")
                Console.WriteLine($"{0}. {menuOptions[i]}");
            else
                Console.WriteLine($"{i}. {menuOptions[i]}");
        }
    }
}