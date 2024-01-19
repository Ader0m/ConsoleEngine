using ConsoleEngine.Core;

namespace ConsoleEngine.Template;

internal static class MenuActions
{
    public static void SwitchToSubMenu()
    {
        WindowsGetter.GetWindow(nameof(WindowName.SubMenu)).Show();
    }
}
