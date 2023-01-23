namespace UserApplication;

using System;

public class RunApplication
{
    private UserInterface UI = new UserInterface();
    private Boolean run = true;
    private int menuState = 0;
    
    public void RunApp()
    {
        while (run)
        {
            UI.DrawMenuOptions(menuState);
            string option = UI.ChooseMenuOption();

            switch (option)
            {
                case "1":
                    Console.Clear();
                    menuState = 1;
                    break;
                case "0":
                    if (menuState != 0)
                    {
                        Console.Clear();
                        menuState = 0;
                    }
                    else
                        run = false;
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("| Wybierz poprawną opcję |");
                    break;
            }
            
        }
    }
    
}