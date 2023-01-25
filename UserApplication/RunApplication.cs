namespace UserApplication;

using System;

public class RunApplication
{
    private UserInterface UI = new UserInterface();
    private Boolean run = true;
    private int menuState;
    private string option;
    private AbstractMenuScreen mainMenuScreen = new MainMenuScreen(0);
    private AbstractMenuScreen chooseDayMenuScreen = new ChooseDayMenuScreen(1);
    private AbstractMenuScreen chooseTimeMenuScreen = new ChooseTimeMenuScreen(2);

    public string ChooseMenuOption()
    {
        Console.Write("Opcja: ");
        string option = Console.ReadLine();
        return option;
    }

    public void RunApp()
    {
        menuState = 0;
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
            }
        }
    }
}