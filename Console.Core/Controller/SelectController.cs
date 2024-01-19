namespace ConsoleEngine.Core;
/// <summary>
/// Реализует выбор пользователем опции из меню. Требует заполнения кнопками MenuButton.
/// </summary>
public class SelectController
{
    /// <summary>
    /// Свойство для возврата списка с названием кнопок, для формирования окна.
    /// </summary>
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

    /// <summary>
    /// Список кнопок.
    /// </summary>
    private readonly List<MenuButton> _buttons;

    /// <summary>
    /// В конструкторе окна необходимо создать и заполнить список кнопок. <br/>
    /// isFirstWindow управляет названием кнопки. <br/>
    /// isBackButton управляет наличием кнопки "Назад/Выход".
    /// </summary>
    /// <param name="buttons"></param>
    /// <param name="isFirstWindow">Если true,название кнопки изменяется на "Выход"</param>
    /// <param name="isBackButton">Если false, не создает кнопку "Назад/Выход"</param>
    public SelectController(List<MenuButton> buttons, bool isFirstWindow = false, bool isBackButton = true)
    {
        _buttons = buttons;
        if (isBackButton)
        {
            _buttons.Add(new BackButton(isFirstWindow));
        }
    }

    /// <summary>
    /// Ожидает ввода uint (номера кнопки меню). Вызывает метод соответствующей кнопки.
    /// </summary>
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
