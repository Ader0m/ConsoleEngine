namespace ConsoleEngine.Core;

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

    internal Dictionary<string, ConsoleWindow> Windows { get; private set; }
    internal bool IsNeedPause;
    private bool IsBackButton;
    private ConsoleWindow _currentWindow;
    private Stack<ConsoleWindow> _backWindows;

    private WindowsController()
    {
        Windows = new();
        _backWindows = new();
    }

    public void StartUp(ConsoleWindow startMenu)
    {
        _currentWindow = startMenu;

        while (true)
        {
            if (_currentWindow != null)
            {
                if (IsNeedPause && !IsBackButton)
                {
                    Console.WriteLine("Нажмите Enter, чтобы вернуться к предыдущему окну");
                    Console.ReadLine();
                    IsNeedPause = false;
                    IsBackButton = false;
                }
                IsBackButton = false;
                _currentWindow.Show();
            }
            else
            {
                break;
            }
        }
    }

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

    internal void RegWindow(ConsoleWindow window, string _rawTitle)
    {
        Windows.Add(_rawTitle, window);
    }

    public void OnClick_BackButton()
    {
        IsNeedPause = false;
        IsBackButton = true;
        Console.Clear();
        // _currentWindow.Clear(); Может надо такое или не надо
        try
        {
            _currentWindow = _backWindows.Pop();
        }
        catch (Exception ex)
        {
            Environment.Exit(0);
        }
    }
}
