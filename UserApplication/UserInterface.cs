using System;

namespace UserApplication
{
    public class UserInterface
    {
        private List<string[]> menuOptions = new List<string[]>(){new string[]{ "Witaj w systemie zamwiania biletów.\nWybierz opcję aby rozpocząć:", "Wybierz dzień podróży", "Wybierz godzinę podróży", "Wyjdź" }, new string[]
            { "Wybierz dzień tyodnia twojej podróży:", "Poniedziałek", "Wtorek", "Środa", "Czwartek", "Piątek", "Sobota", "Niedziela", "Wróć" }};
        
        public void DrawMenuOptions(int menuState)
        {
            string[] menuOption = menuOptions[menuState];

            Console.WriteLine($"{menuOption[0]}");
            int i;
            for (i = 1; i < menuOption.Length; i++)
            {
                if(menuOption[i] == "Wróć" || menuOption[i] == "Wyjdź")
                    Console.WriteLine($"{0}. {menuOption[i]}");
                else
                    Console.WriteLine($"{i}. {menuOption[i]}");
            }
        }

        public string ChooseMenuOption()
        {
            Console.Write("Opcja: ");
            string option = Console.ReadLine();
            return option;
        }

        public void HandleMenuOption(string option, int menuState)
        {
            
        }
    }
}
