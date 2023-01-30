namespace UserApplication;

public abstract class AbstractMenuScreen<T>
{
    public abstract void DrawMenuOptions(T ticket);
    public abstract int ExecuteSelectedOption(string option, int menuState, T ticket);
}