using ConsoleEngine.Core.Model.Exceptions;

namespace ConsoleEngine.Core;

public static class WindowsGetter
{
    public static ConsoleWindow GetWindow(string WindowName)
    {
        try
        {
            var window = WindowsController.Instance.Windows.GetValueOrDefault(WindowName);

            if (window == null)
            {
                throw new Exception();
            }

            return window;
        }
        catch
        {
            throw new NoWindowException(WindowName);
        }
    }
}
