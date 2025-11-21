using System.Text.Json;

namespace ProyectoRaulBenitezOscarSaez.Helpers
{
    public static class SessionExtensions
    {
        public static void SetObject(this ISession session, string key, object value)
        {
            string json = JsonSerializer.Serialize(value);
            session.SetString(key, json);
        }

        public static T? GetObject<T>(this ISession session, string key)
        {
            string? json = session.GetString(key);
            if (json == null) return default;
            return JsonSerializer.Deserialize<T>(json);
        }
    }
}
