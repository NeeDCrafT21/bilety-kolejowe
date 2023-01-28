namespace UserApplication;

public abstract class AbstractMenuScreen<T>
{
    //private int number { get; }
    //public List<string> _menuOptions { get; }
    
    public abstract void DrawMenuOptions(T ticket);
    public abstract int ExecuteSelectedOption(string option, int menuState, T ticket);
}