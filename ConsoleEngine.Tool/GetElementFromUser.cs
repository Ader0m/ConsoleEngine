namespace ConsoleEngine.Tool;

public static class GetElementFromUser
{
    /// <summary>
    /// Return long from console.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="min">not inclusive</param>
    /// <param name="max">not inclusive</param>
    /// <returns></returns>
    public static long Long(string message = "Input int", long min = long.MinValue, long max = long.MaxValue)
    {
        long input = 0;

        while (true)
        {
            Console.WriteLine(message);

            if (!long.TryParse(Console.ReadLine(), out input) ||
                input < min ||
                input > max)
            {
                Console.WriteLine(ConsoleMess.ErrorInput);
                continue;
            }

            return input;
        }
    }

    /// <summary>
    /// Return int from console.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="min">not inclusive</param>
    /// <param name="max">not inclusive</param>
    /// <returns></returns>
    public static int Int(string message = "Input long", int min = int.MinValue, int max = int.MaxValue)
    {
        int input = 0;

        while (true)
        {
            Console.WriteLine(message);

            if (!int.TryParse(Console.ReadLine(), out input) ||
                input < min ||
                input > max)
            {
                Console.WriteLine(ConsoleMess.ErrorInput);
                continue;
            }

            return input;
        }
    }

    /// <summary>
    /// Return string from console.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="min">not inclusive</param>
    /// <param name="max">not inclusive</param>
    /// <returns></returns>
    public static string String(string message = "Input string", int min = 0, int max = 10000)
    {
        string input = "";

        while (true)
        {
            Console.WriteLine(message);

            input = Console.ReadLine();

            if (string.IsNullOrEmpty(input) ||
                input.Length < min ||
                input.Length > max)
            {
                Console.WriteLine(ConsoleMess.ErrorInput);
                continue;
            }

            return input;
        }
    }

    /// <summary>
    /// Return DateOnly from console. Format "yyyy-MM-dd"
    /// </summary>
    /// <param name="message"></param>
    /// <param name="min">not inclusive</param>
    /// <param name="max">not inclusive</param>
    /// <returns></returns>
    public static DateOnly DateOnly(string message = "Input string", DateOnly min = default, DateOnly max = default)
    {
        System.DateOnly dateOnly;

        while (true)
        {
            Console.WriteLine(message);

            if (!System.DateOnly.TryParseExact(Console.ReadLine(), "yyyy-MM-dd", out dateOnly) ||
                dateOnly < min ||
                (max != default && dateOnly > max)
                )
            {
                Console.WriteLine(ConsoleMess.ErrorInput);
                continue;
            }

            return dateOnly;
        }
    }
}
