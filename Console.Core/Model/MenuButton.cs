namespace ConsoleEngine.Core;

public class MenuButton
{
    public readonly string Name;
    private Action _action;

    public MenuButton(string name, Action action)
    {
        Name = name;
        _action = action;
    }

    public void Invoke()
    {
        _action.Invoke();
    }
}
