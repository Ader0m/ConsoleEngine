namespace ConsoleEngine.Core;

public class SelectController
{
    public IReadOnlyList<string> OptionsList
    {
        get
        {
            List<string> strings = new(_buttons.Count);

            foreach (MenuButton item in _buttons)
            {
                strings.Add(item.Name);
            }

            return strings.AsReadOnly();
        }
    }

    private readonly List<MenuButton> _buttons;

    public SelectController(List<MenuButton> buttons, bool isFirstWindow = false, bool isBackButton = true)
    {
        _buttons = buttons;
        if (isBackButton)
        {
            _buttons.Add(new BackButton(isFirstWindow));
        }
    }

    public void ListenInput()
    {
        uint schoose;
        while (true)
        {
            Console.Write("Выберите пункт меню: ");

            if (!uint.TryParse(Console.ReadLine(), out schoose) ||
                schoose == 0 ||
                schoose > OptionsList.Count)
            {
                Console.WriteLine("Не корректный ввод, повторите попытку!");
                continue;
            }
            _buttons[(int)schoose - 1].Invoke();

            WindowsController.Instance.IsNeedPause = true;
            break;
        }
    }
}
