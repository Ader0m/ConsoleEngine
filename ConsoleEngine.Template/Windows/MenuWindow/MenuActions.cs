using ConsoleEngine.Core;

namespace ConsoleEngine.Template;

internal static class MenuActions
{
    /// <summary>
    /// Переход между окнами с помощью WindowsGetter.GetWindow.
    /// </summary>
    public static void SwitchToSubMenu()
    {
        WindowsGetter.GetWindow(nameof(WindowName.SubMenu)).Show();
    }
}
