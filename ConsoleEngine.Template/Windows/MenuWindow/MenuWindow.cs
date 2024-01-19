using ConsoleEngine.Core;

namespace ConsoleEngine.Template;

internal class MenuWindow : ConsoleWindow
{
    /// <summary>
    /// Создание окна
    /// </summary>
    /// <param name="title"></param>
    public MenuWindow(string title) : base(title)
    {
        //Создание кнопок
        List<MenuButton> buttons = new List<MenuButton>()
        {
            new MenuButton("SwitchToSubMenu", MenuActions.SwitchToSubMenu),
        };

        //Установка контроллера
        _selectController = new(buttons, true);
    }
}
