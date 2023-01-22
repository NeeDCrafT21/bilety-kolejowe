namespace UserApplication;

using System;

public class RunApplication
{
    private UserInterface UI = new UserInterface();
    private Boolean run = true;
    
    public void RunApp()
    {
        while (run)
        {
            UI.DrawMenuOptions();
            switch (UI.ChooseMenuOption())
            {
                case "1":
                    Console.WriteLine("1");
                    break;
                case "2":
                    run = false;
                    break;
                default:
                    break;
            }
        }
    }
}