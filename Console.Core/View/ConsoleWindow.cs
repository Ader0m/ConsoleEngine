namespace ConsoleEngine.Core;

public abstract class ConsoleWindow
{
    public string Title { get; private set; }
    public readonly string RawTitle;

    protected SelectController _selectController;

    private string _windowView;

    public ConsoleWindow(string title)
    {
        Title = string.Empty;
        RawTitle = title;
        _selectController = null;
        _windowView = string.Empty;

        WindowsController.Instance.RegWindow(this, title);
    }

    public void Show()
    {
        WindowsController.Instance.StartWindowShow(this);

        if (_selectController == null)
        {
            Console.Error.WriteLine($"Контроллер не установлен в {RawTitle}");
            return;
        }

        if (_windowView == string.Empty)
        {
            _windowView = WindowBuilder.BuildWindow(RawTitle, _selectController.OptionsList);
        }
        Console.WriteLine(_windowView);
        _selectController.ListenInput();
    }
}
