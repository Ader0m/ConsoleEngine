using System.Net.Http.Json;

namespace ConsoleEngine.WebTool;

public static class WebMethod
{
    /// <summary>
    /// Выполняет post запрос с возвращаемым значением.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="K"></typeparam>
    /// <param name="shortUrl"></param>
    /// <param name="request"></param>
    /// <param name="response"></param>
    /// <returns></returns>
    public static bool Post<T, K>(string shortUrl, T request, out K? response)
    {
        var webAnswer = WebEnv.Client.PostAsJsonAsync(shortUrl, request).Result;

        if (!webAnswer.IsSuccessStatusCode)
        {
            if (webAnswer.ReasonPhrase != null)
            {
                Console.WriteLine(webAnswer.StatusCode + " " + webAnswer.ReasonPhrase);
            }
            response = default(K);
            return false;
        }

        response = webAnswer.Content.ReadFromJsonAsync<K>().Result;

        return true;
    }

    /// <summary>
    /// Выполняет post запрос без возвращаемого значения.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="shortUrl"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    public static bool Post<T>(string shortUrl, T request)
    {
        var webAnswer = WebEnv.Client.PostAsJsonAsync(shortUrl, request).Result;

        if (!webAnswer.IsSuccessStatusCode)
        {
            if (webAnswer.ReasonPhrase != null)
            {
                Console.WriteLine(webAnswer.StatusCode + " " + webAnswer.ReasonPhrase);
            }
            return false;
        }

        return true;
    }
}