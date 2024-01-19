namespace ConsoleEngine.Core;

/// <summary>
/// Синглтон. Управляет межоконными действиями.
/// </summary>
public class WindowsController
{
    #region Singltone

    public static WindowsController Instance
    {
        get
        {
            if (_instance == null)
                _instance = new WindowsController();
            return _instance;
        }
    }
    private static WindowsController _instance;

    #endregion

    /// <summary>
    /// Нужен для обращения к  “другим” окнам.
    /// </summary>
    internal Dictionary<string, ConsoleWindow> Windows { get; private set; }
    /// <summary>
    /// Просит пользователя нажать Enter после выполнения опции меню.
    /// </summary>
    internal bool IsNeedPause;
    /// <summary>
    /// Так как "назад" тоже опция, этот флаг отменяет приостановку.
    /// </summary>
    private bool _isBackButton;
    /// <summary>
    /// Текущее окно/окно которое нужно открыть.
    /// </summary>
    private ConsoleWindow _currentWindow;
    /// <summary>
    /// Хранит историю окон. Используется для возвращения назад.
    /// </summary>
    private Stack<ConsoleWindow> _backWindows;

    private WindowsController()
    {
        Windows = new();
        _backWindows = new();
    }

    /// <summary>
    /// Запуск приложения. Цикл контролирует паузу, и открытие нужного окна.
    /// </summary>
    /// <param name="startMenu"></param>
    public void StartUp(ConsoleWindow startMenu)
    {
        _currentWindow = startMenu;

        while (true)
        {
            if (_currentWindow != null)
            {
                if (IsNeedPause && !_isBackButton)
                {
                    Console.WriteLine("Нажмите Enter, чтобы вернуться к предыдущему окну");
                    Console.ReadLine();
                    IsNeedPause = false;
                    _isBackButton = false;
                }
                _isBackButton = false;
                _currentWindow.Show();
            }
            else
            {
                break;
            }
        }
    }


    /// <summary>
    /// Возвращает к предыдущему окну. Открыт для создания своих кнопок назад.
    /// </summary>
    public void OnClick_BackButton()
    {
        IsNeedPause = false;
        _isBackButton = true;
        Console.Clear();

        try
        {
            _currentWindow = _backWindows.Pop();
        }
        catch (Exception ex)
        {
            Environment.Exit(0);
        }
    }

    /// <summary>
    /// Регестрирует открытие окна. Нужно для истории.
    /// </summary>
    /// <param name="window"></param>
    internal void StartWindowShow(ConsoleWindow window)
    {
        Console.Clear();

        if (_currentWindow == window)
        {
            return;
        }

        _backWindows.Push(_currentWindow);
        _currentWindow = window;
    }

    /// <summary>
    /// Регестрирует окно в системе приложения. Нужно для межоконного доступа.
    /// </summary>
    /// <param name="window"></param>
    /// <param name="rawTitle"></param>
    internal void RegWindow(ConsoleWindow window, string rawTitle)
    {
        Windows.Add(rawTitle, window);
    }
}