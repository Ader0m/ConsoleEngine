using System.Text;

namespace ConsoleEngine.Core;

public static class WindowBuilder
{
    private static string BuildTitle(string rawTitle)
    {
        void BuildPart(StringBuilder sb, int count)
        {
            for (int i = 0; i < count; i++)
            {
                sb.Append(WindowSettings.TitleSymbol);
            }
        }
        StringBuilder sb = new StringBuilder();

        int addSymbolCount = (WindowSettings.WindowWight - rawTitle.Length) / 2;

        BuildPart(sb, addSymbolCount);
        sb.Append(rawTitle);
        BuildPart(sb, addSymbolCount);

        return sb.ToString();
    }

    public static string BuildWindow(string rawTitle, IReadOnlyList<string> optionsList)
    {
        StringBuilder sb = new StringBuilder();
        string Title = BuildTitle(rawTitle);

        sb.AppendLine(Title + '\n');

        for (int i = 0; i < optionsList.Count; i++)
        {
            sb.Append(optionsList[i]);
            for (int j = 1; j < WindowSettings.WindowWight - optionsList[i].Length; j++)
            {
                sb.Append(WindowSettings.OptionsFillSymbol);
            }
            sb.AppendLine($"{i + 1}");
        }

        return sb.ToString();
    }
}
