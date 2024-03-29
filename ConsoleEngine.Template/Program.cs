﻿using ConsoleEngine.Core;

namespace ConsoleEngine.Template;

internal class Program
{
    static void Main(string[] args)
    {
        CreateWindows();
        // Запуск приложения
        WindowsController.Instance.StartUp(WindowsGetter.GetWindow(nameof(WindowName.Menu)));
    }

    /// <summary>
    /// Создаем окна.
    /// </summary>
    public static void CreateWindows()
    {
        new MenuWindow(nameof(WindowName.Menu));
        new SubMenuWindow(nameof(WindowName.SubMenu));
    }
}