using System.Collections;

namespace UserApplication;

public class SelectDiscountScreen : AbstractMenuScreen<List<AbstractTicket>>
{
    public double selectedDiscount { get; private set; }
    private List<string> menuOptions = new List<string>()
    {
        "Wybierz swoją zniżkę:", "Wróć"
    };

    private enum Discounts
    {
        Brak = 1,
        Student = 30,
        Emeryt = 45,
        Niepelnosprawny = 50,
        A = 10,
        B = 8,
        C = 5
    }

    public override void DrawMenuOptions(List<AbstractTicket> ticketList)
    {
        Console.WriteLine($"{menuOptions[0]}");
        string departurePlace = ticketList[0].departurePlace.ToString();

        IEnumerable<Discounts> discountsQuery =
            Enum.GetValues(typeof(Discounts)).Cast<Discounts>().Where(x => x == Discounts.Brak 
                                                                           || x == Discounts.Student 
                                                                           || x == Discounts.Emeryt 
                                                                           || x == Discounts.Niepelnosprawny 
                                                                           || x.ToString() == departurePlace);

        int j = 1;
        foreach (var item in discountsQuery)
        {
            Console.WriteLine($"{j}. {(item.ToString() == "A" || item.ToString() == "B" || item.ToString() == "C" ? "Mieszkaniec " + item : item)} - {((int)item != 1 ? (int)item : 0)}%");
            j++;
        }

        int i;
        for (i = 1; i < menuOptions.Count; i++)
        {
            if(menuOptions[i] == "Wróć" || menuOptions[i] == "Wyjdź")
                Console.WriteLine($"{0}. {menuOptions[i]}");
            else
                Console.WriteLine($"{i}. {menuOptions[i]}");
        }
    }
    
    public override int ExecuteSelectedOption(string option, int menuState, List<AbstractTicket> ticketList)
    {
        string departurePlace = ticketList[0].departurePlace.ToString();
        switch (option)
        {
            case "1":
                selectedDiscount = (double)Discounts.Brak;
                break;
            case "2":
                selectedDiscount = (double)(Discounts)Enum.Parse(typeof(Discounts), departurePlace) / 100;
                break;
            case "3":
                selectedDiscount = (double)Discounts.Student / 100;
                break;
            case "4":
                selectedDiscount = (double)Discounts.Emeryt / 100;
                break;
            case "5":
                selectedDiscount = (double)Discounts.Niepelnosprawny / 100;
                break;
            case "0":
                return 5;
            default:
                Console.WriteLine("| Wybierz poprawną opcję |"); 
                return menuState;
        }
        return 7;
    }
}