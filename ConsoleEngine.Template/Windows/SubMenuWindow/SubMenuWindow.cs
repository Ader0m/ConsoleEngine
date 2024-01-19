using ConsoleEngine.Core;

namespace ConsoleEngine.Template
{
    internal class SubMenuWindow : ConsoleWindow
    {
        public SubMenuWindow(string title) : base(title)
        {
            SelectController selectController = new SelectController(new());
            _selectController = selectController;
        }
    }
}
