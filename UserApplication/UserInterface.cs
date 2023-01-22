using System;

namespace UserApplication
{
    public class UserInterface
    {
        private string[] mainMenuOptions = new string[]{"Rozpocznij podróż", "Wyjdź"};
        
        public void DrawMenuOptions(string[] options = null)
        {
            Console.Clear();
            
            options = options == null ? mainMenuOptions : options;
            int i;
            for (i = 0; i < options.Length; i++)
            {
                Console.WriteLine($"{i+1}. {options[i]}");
            }
        }

        public string ChooseMenuOption()
        {
            Console.Write("Opcja: ");
            string option = Console.ReadLine();
            return option;
        }
    }
}
