using System.Text.Json;

namespace Project
{
    public static class JsonHelper
    {
        public static string ToJson<T>(this T t)
        {
            return JsonSerializer.Serialize(t);
        }
    }
}
