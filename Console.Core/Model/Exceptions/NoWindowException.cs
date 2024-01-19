using System.Text;

namespace ConsoleEngine.Core.Model.Exceptions;

internal class NoWindowException : Exception
{
    public NoWindowException(string message) : base(message)
    {

    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Попытка открыть окно: {Message}");
        sb.AppendLine("Существуют следующие окна:");
        foreach (string item in WindowsController.Instance.Windows.Keys)
        {
            sb.AppendLine(item);
        }
        sb.AppendLine();
        sb.AppendLine(StackTrace);

        return sb.ToString();
    }
}