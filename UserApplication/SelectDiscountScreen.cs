namespace UserApplication;

public class SelectDiscountScreen : AbstractMenuScreen<List<AbstractTicket>>
{
    public double selectedDiscount { get; private set; }
    public List<string> menuOptions = new List<string>()
    {
        "Wybierz swoją zniżkę:", "Wróć"
    };

    enum Discounts
    {
        Brak = 1,
        Student = 30,
        Emeryt = 45,
        Niepelnosprawny = 50
    }

    public override void DrawMenuOptions(List<AbstractTicket> ticketList)
    {
        
        Console.WriteLine($"{menuOptions[0]}");
        int j = 1;
        foreach (var item in Enum.GetValues(typeof(Discounts)))
        {
            Console.WriteLine($"{j}. {item} - {((int)item != 1 ? (int)item : 0)}%");
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
        switch (option)
        {
            case "1":
                selectedDiscount = (double)Discounts.Brak;
                return 7;
            case "2":
                selectedDiscount = (double)Discounts.Student / 100;
                return 7;
            case "3":
                selectedDiscount = (double)Discounts.Emeryt / 100;
                return 7;
            case "4":
                selectedDiscount = (double)Discounts.Niepelnosprawny / 100;
                return 7;
            case "0":
                return 5;
            default:
                Console.WriteLine("| Wybierz poprawną opcję |"); 
                return menuState;
        }
    }
}