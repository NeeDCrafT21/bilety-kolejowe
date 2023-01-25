namespace UserApplication;

public class ChooseCityMenuScreen : AbstractMenuScreen
{
    private Boolean choseArrivalPlace = false;
    private char departurePlace;
    private char arrivalPlace;
    private List<string> menuOptions = new List<string>()
    {
        "Wybierz miasto startowe:", "Wybierz miasto docelowe:", "Miasto A", "Miasto B", "Miasto C", "Wróć"
    };

    public override void DrawMenuOptions()
    {
        if(!choseArrivalPlace)
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
    
    public override int ExecuteSelectedOption(string option, int menuState)
    {
        if (!choseArrivalPlace)
        {
            switch (option)
            {
                case "1":
                    departurePlace = 'A';
                    break;
                case "2":
                    departurePlace = 'B';
                    break;
                case "3":
                    departurePlace = 'C';
                    break;
            }
            choseArrivalPlace = true;
            return menuState;
        }
        
        switch (option)
        {
            case "1":
                departurePlace = 'A';
                break;
            case "2":
                departurePlace = 'B';
                break;
            case "3":
                departurePlace = 'C';
                break;
        }
        return 0;
    }

    public void ResetChoice()
    {
        choseArrivalPlace = false;
    }
}