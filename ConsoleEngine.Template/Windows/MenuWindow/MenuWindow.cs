using ConsoleEngine.Core;

namespace ConsoleEngine.Template;

internal class MenuWindow : ConsoleWindow
{
    public MenuWindow(string title) : base(title)
    {
        List<MenuButton> buttons = new List<MenuButton>()
        {
            new MenuButton("SwitchToSubMenu", MenuActions.SwitchToSubMenu),
        };

        SelectController selectController = new(buttons, true);
        _selectController = selectController;
    }
}
