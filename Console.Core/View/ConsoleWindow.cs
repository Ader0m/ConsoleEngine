namespace ConsoleEngine.Core;

/// <summary>
/// Абстрактный класс. Оболочка для консольного окна с меню.
/// </summary>
public abstract class ConsoleWindow
{
    /// <summary>
    /// Заголовок окна, достроенный билдером.
    /// </summary>
    public string Title { get; private set; }
    /// <summary>
    /// Заголовок  окна.
    /// </summary>
    public readonly string RawTitle;

    /// <summary>
    /// <inheritdoc cref="SelectController"/>
    /// </summary>
    protected SelectController _selectController;

    /// <summary>
    /// Содержит построенное окно в виде строки.
    /// </summary>
    private string _windowView;

    /// <summary>
    /// SelectController необходим для работы окна. Устанавливается напрямую в конструкторе наследника.
    /// </summary>
    /// <param name="title">Название окна.</param>
    /// <param name="selectController">Установить в конструкторе наследника.</param>
    public ConsoleWindow(string title, SelectController selectController = null)
    {
        Title = string.Empty;
        RawTitle = title;
        _selectController = null;
        _windowView = string.Empty;

        WindowsController.Instance.RegWindow(this, title);
    }

    /// <summary>
    /// Добавляется себя в стек окон WindowsController.<br/>
    /// Отрисовывает текущее окно в консоли.<br/>
    /// Слушает ввод пользователя через SelectController.
    /// </summary>
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
