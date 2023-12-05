using Logger.Models;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace Logger.Loggers
{
    public class JsonFileLogger : ILogger
    {
        public void ExecuteSaveLog(Guid id, DateTime date, string text)
        {
            var jsonLog = new LogDto
            {
                Id = id,
                Date = date,
                ErrorText = text
            };

            string jsonPath = @"..\logger.main\logs\log.json";

            var options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };

            string jsonString = JsonSerializer.Serialize(jsonLog, options);

            if (!File.Exists(jsonPath))
            {
                File.WriteAllText(jsonPath, jsonString);
            }
            else
            {
                File.AppendAllText(jsonPath, ",\n" + jsonString);
            }

        }
    }
}
