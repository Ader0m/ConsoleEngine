using ConsoleEngine.Core;

namespace ConsoleEngine.Template;

internal class SubMenuWindow : ConsoleWindow
{
    public SubMenuWindow(string title) : base(title)
    {
        //Установка контроллера обязательна
        _selectController = new(new());
    }
}
