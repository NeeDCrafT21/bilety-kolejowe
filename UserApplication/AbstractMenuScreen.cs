namespace UserApplication;

public abstract class AbstractMenuScreen
{
    //private int number { get; }
    //public List<string> _menuOptions { get; }

    public abstract void DrawMenuOptions();
    public abstract int ExecuteSelectedOption(string option, int menuState);

    /*
    public int getNumber()
    {
        return number;
    }
    */
}