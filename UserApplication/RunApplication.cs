using System.Text.Json;

namespace UserApplication;

using System;

public class RunApplication
{
    //private UserInterface UI = new UserInterface();
    private Boolean run = true;
    private int menuState;
    private string option;
    private MainMenuScreen mainMenuScreen = new MainMenuScreen();
    private ChooseDayMenuScreen chooseDayMenuScreen = new ChooseDayMenuScreen();
    private ChooseTimeMenuScreen chooseTimeMenuScreen = new ChooseTimeMenuScreen();
    private ChooseCityMenuScreen chooseCityMenuScreen = new ChooseCityMenuScreen();
    private MessageTicket ticket = new MessageTicket(DateTime.Now.Hour, DateTime.Now.Minute, 'A', 'B');
    private MessageTicket2 trainInfo;
    private PipeServer sender = new PipeServer();

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
                    Console.WriteLine($"Godzina wyjazdu: {((int)(ticket.startHour / 10) != 0 ? ticket.startHour : "0" + ticket.startHour.ToString())}:{((int)(ticket.startMinute / 10) != 0 ? ticket.startMinute : "0" + ticket.startMinute.ToString())}\nWyjazd z {ticket.departurePlace} do {ticket.arrivalPlace}");
                    mainMenuScreen.DrawMenuOptions();
                    option = ChooseMenuOption();
                    menuState = mainMenuScreen.ExecuteSelectedOption(option, menuState, ticket);
                    if (menuState == -1)
                        run = false;
                    chooseCityMenuScreen.ResetChoiceState();
                    chooseTimeMenuScreen.ResetChoiceState();
                    Console.Clear();
                    break;
                case 1:
                    chooseDayMenuScreen.DrawMenuOptions(); 
                    option = ChooseMenuOption();
                    menuState = chooseDayMenuScreen.ExecuteSelectedOption(option, menuState, ticket);
                    Console.Clear();
                    break; 
                case 2:
                    chooseTimeMenuScreen.DrawMenuOptions(); 
                    option = ChooseMenuOption();
                    menuState = chooseTimeMenuScreen.ExecuteSelectedOption(option, menuState, ticket);
                    Console.Clear(); 
                    break;
                case 3:
                    chooseCityMenuScreen.DrawMenuOptions(); 
                    option = ChooseMenuOption();
                    menuState = chooseCityMenuScreen.ExecuteSelectedOption(option, menuState, ticket);
                    Console.Clear(); 
                    break;
                case 4:
                    if (ticket.departurePlace != ticket.arrivalPlace)
                    {
                        var message = JsonSerializer.Serialize(ticket);
                        sender.SendTicketInfo(message);
                        trainInfo = sender.trainInfo;
                        Console.Clear();
                    }
                    else
                        Console.WriteLine("| Miasta wyjazdu i przyjazdu nie mogą być takie same |"); 
                    menuState = 0;
                    break;
            }
        }
    }
}