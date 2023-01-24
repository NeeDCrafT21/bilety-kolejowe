namespace UserApplication;

public class ChooseTimeMenuScreen : AbstractMenuScreen
{
    private int screenNumber;
    private List<string> menuOptions = new List<string>()
    {
        "Wybierz czas twojej podróży:", "Poniedziałek", "Wtorek", "Środa", "Czwartek", "Piątek", "Sobota", "Niedziela", "Wróć"
    };
    
    public ChooseTimeMenuScreen(int screenNumber)
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
}