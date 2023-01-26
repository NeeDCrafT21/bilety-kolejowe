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
    
    public override int ExecuteSelectedOption(string option, int menuState, MessageTicket ticket)
    {
        if (!choseArrivalPlace)
        {
            switch (option)
            {
                case "0":
                    return 0;
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

            ticket.departurePlace = departurePlace;
            choseArrivalPlace = true;
            return menuState;
        }
        
        switch (option)
        {
            case "0":
                return 0;
            case "1":
                arrivalPlace = 'A';
                break;
            case "2":
                arrivalPlace = 'B';
                break;
            case "3":
                arrivalPlace = 'C';
                break;
        }

        ticket.arrivalPlace = arrivalPlace;
        return 0;
    }

    public void ResetChoiceState()
    {
        choseArrivalPlace = false;
    }
}