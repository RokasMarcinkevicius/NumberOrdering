using System;
using System.IO;
using System.Text.Json;

namespace NumberOrdering.Repository.Models
{
    public class Config
    {
        public Logging Logging { get; set; }
        public string AllowedHosts { get; set; }
        public ConnectionStrings ConnectionStrings { get; set; }
    }

    public class ConnectionStrings
    {
        public string NumberOrderingDB { get; set; }
        public string LastFile { get; set; }
    }

    public class Logging
    {
        public Loglevel LogLevel { get; set; }
    }

    public class Loglevel
    {
        public string Default { get; set; }
    }

    public class ConfigurationOperations
    {
        private static string FileName => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appsettings.json");
        public static Config ReadConfiguration()
        {
            var json = File.ReadAllText(FileName);
            return json.JSonToItem<Config>();
        }

        public static void SaveChanges(Config configuration)
        {
            configuration.JsonToFile(FileName);
        }
    }

    public static class SystemJson
    {
        public static T JSonToItem<T>(this string jsonString) => JsonSerializer.Deserialize<T>(jsonString);
        public static (bool result, Exception exception) JsonToFile<T>(this T sender, string fileName, bool format = true)
        {
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                File.WriteAllText(fileName, JsonSerializer.Serialize(sender, format ? options : null));

                return (true, null);
            }
            catch (Exception exception)
            {
                return (false, exception);
            }
        }
    }
}
