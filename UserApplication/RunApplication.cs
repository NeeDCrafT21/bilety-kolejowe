namespace UserApplication;

using System;

public class RunApplication
{
    private UserInterface UI = new UserInterface();
    private Boolean run = true;
    private int menuState = 0;
    private AbstractMenuScreen mainMenuScreen = new MainMenuScreen(0);
    private AbstractMenuScreen ChooseDayMenuScreen = new ChooseDayMenuScreen(1);
    private AbstractMenuScreen ChooseTimeMenuScreen = new ChooseTimeMenuScreen(2);

    //private List<AbstractMenuScreen> screens = new List<AbstractMenuScreen>()
    // {
    //     new MainMenuScreen(0), new ChooseDayMenuScreen(1), new ChooseTimeMenuScreen(2)
    // };

    public void RunApp()
    {
        // ChooseDayMenuScreen mainMenuScreen = new ChooseDayMenuScreen(1);
        // mainMenuScreen.DrawMenuOptions();
        //mainMenuScreen.DrawMenuOptions();

        while (run)
         {
             string option = UI.ChooseMenuOption();
             //screens[menuState].DrawMenuOptions();
         }
    }
    
}