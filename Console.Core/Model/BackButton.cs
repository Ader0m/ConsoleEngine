namespace ConsoleEngine.Core;

internal class BackButton : MenuButton
{
    public BackButton(bool isExitButton = false) : this(isExitButton ? "Выход" : "Назад",
        WindowsController.Instance.OnClick_BackButton)
    {
    }

    private BackButton(string name, Action action) : base(name, action)
    {
    }
}
