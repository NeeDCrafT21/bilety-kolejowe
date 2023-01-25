namespace UserApplication;

using System;

public class RunApplication
{
    private UserInterface UI = new UserInterface();
    private Boolean run = true;
    private int menuState;
    private string option;
    private MainMenuScreen mainMenuScreen = new MainMenuScreen();
    private ChooseDayMenuScreen chooseDayMenuScreen = new ChooseDayMenuScreen();
    private ChooseTimeMenuScreen chooseTimeMenuScreen = new ChooseTimeMenuScreen();
    private ChooseCityMenuScreen chooseCityMenuScreen = new ChooseCityMenuScreen();
    private MessageTicket ticket = new MessageTicket(new TimeOnly(1, 1,1), 'A', 'B');

    public string ChooseMenuOption()
    {
        Console.Write("Opcja: ");
        string option = Console.ReadLine();
        return option;
    }

    public void RunApp()
    {
        menuState = 0;
        ticket.departurePlace = 'F';
        
        while (run)
        {
            switch (menuState)
            { 
                case 0:
                    mainMenuScreen.DrawMenuOptions();
                    option = ChooseMenuOption();
                    menuState = mainMenuScreen.ExecuteSelectedOption(option, menuState);
                    if (menuState == -1)
                        run = false;
                    Console.Clear();
                    break;
                case 1:
                    chooseDayMenuScreen.DrawMenuOptions(); 
                    option = ChooseMenuOption();
                    menuState = chooseDayMenuScreen.ExecuteSelectedOption(option, menuState);
                    Console.Clear();
                    break; 
                case 2:
                    chooseTimeMenuScreen.DrawMenuOptions(); 
                    option = ChooseMenuOption();
                    menuState = chooseTimeMenuScreen.ExecuteSelectedOption(option, menuState);
                    Console.Clear(); 
                    break;
                case 3:
                    chooseCityMenuScreen.ResetChoice();
                    chooseCityMenuScreen.DrawMenuOptions(); 
                    option = ChooseMenuOption();
                    menuState = chooseCityMenuScreen.ExecuteSelectedOption(option, menuState);
                    Console.Clear(); 
                    break;
            }
        }
    }
}