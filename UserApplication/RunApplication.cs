using System.IO.Pipes;
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
    private SelectTrainScreen selectTrainScreen = new SelectTrainScreen();
    private SelectDiscountScreen selectDiscountScreen = new SelectDiscountScreen();
    private FinalScreen finalScreen = new FinalScreen();
    private MessageTicket ticket = new MessageTicket(DateTime.Now.Hour, DateTime.Now.Minute, 'A', 'B');
    private List<AbstractTicket> ticketList= new List<AbstractTicket>();
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
                case -1:
                    run = false;
                    using (NamedPipeServerStream pipeServer =
                           new NamedPipeServerStream("ticketpipe"))
                    {
                        pipeServer.WaitForConnection();
                    }
                    break;
                case 0:
                    ticketList.Clear();
                    mainMenuScreen.DrawMenuOptions(ticket);
                    option = ChooseMenuOption();
                    menuState = mainMenuScreen.ExecuteSelectedOption(option, menuState, ticket);
                    chooseCityMenuScreen.ResetChoiceState();
                    chooseTimeMenuScreen.ResetChoiceState();
                    Console.Clear();
                    break;
                // case 1:
                //     chooseDayMenuScreen.DrawMenuOptions(ticket); 
                //     option = ChooseMenuOption();
                //     menuState = chooseDayMenuScreen.ExecuteSelectedOption(option, menuState, ticket);
                //     Console.Clear();
                //     break; 
                case 2:
                    chooseTimeMenuScreen.DrawMenuOptions(ticket); 
                    option = ChooseMenuOption();
                    menuState = chooseTimeMenuScreen.ExecuteSelectedOption(option, menuState, ticket);
                    Console.Clear(); 
                    break;
                case 3:
                    chooseCityMenuScreen.DrawMenuOptions(ticket); 
                    option = ChooseMenuOption();
                    menuState = chooseCityMenuScreen.ExecuteSelectedOption(option, menuState, ticket);
                    Console.Clear(); 
                    break;
                case 4:
                    if (ticket.departurePlace != ticket.arrivalPlace)
                    {
                        var message = JsonSerializer.Serialize(ticket);
                        var temp = async () => await sender.SendTicketInfo(message);
                        ticketList = temp().Result;
                        menuState = 5;
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("| Miasta wyjazdu i przyjazdu nie mogą być takie same |"); 
                        menuState = 0;
                    }
                    break;
                case 5:
                    selectTrainScreen.DrawMenuOptions(ticketList); 
                    option = ChooseMenuOption();
                    menuState = selectTrainScreen.ExecuteSelectedOption(option, menuState, ticketList);
                    Console.Clear();
                    break;
                case 6:
                    selectDiscountScreen.DrawMenuOptions(ticketList); 
                    option = ChooseMenuOption();
                    menuState = selectDiscountScreen.ExecuteSelectedOption(option, menuState, ticketList);
                    Console.Clear();
                    break;
                case 7:
                    finalScreen.isTransferTrain = selectTrainScreen.isTransferTrain;
                    if (!finalScreen.isTransferTrain)
                        finalScreen.ticketPrice = selectTrainScreen.ticketPrice1;
                    else
                        finalScreen.ticketPrice = selectTrainScreen.ticketPrice2;
                    finalScreen.discount = selectDiscountScreen.selectedDiscount;
                    finalScreen.DrawMenuOptions(ticketList);
                    option = ChooseMenuOption();
                    menuState = finalScreen.ExecuteSelectedOption(option, menuState, ticketList);
                    Console.Clear();
                    break;
            }
        }
    }
}