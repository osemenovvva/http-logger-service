using Logger.Loggers;

namespace Logger.Main
{
    public class LogService
    {
        private readonly IConfiguration _configuration;
        private Dictionary<string, bool> loggerSettings;
        private Dictionary<string, Loggers.ILogger> loggerImplementationType;

        public LogService(IConfiguration configuration, TxtFileLogger txtFileLogger, JsonFileLogger jsonFileLogger,
            XmlFileLogger xmlFileLogger, PostgresqlDatabaseLogger postgresqlDatabaseLogger)
        {
            _configuration = configuration;

            loggerSettings = new Dictionary<string, bool>();
            FillLoggerSettings();

            loggerImplementationType = new Dictionary<string, Loggers.ILogger>
            {
                { "TXT", txtFileLogger },
                { "JSON", jsonFileLogger },
                { "XML", xmlFileLogger },
                { "PostgreSQL", postgresqlDatabaseLogger }
            };
        }


        public void SaveLog(Guid id, DateTime date, string text)
        {
            //использование настроек
            foreach (var setting in loggerSettings.Keys)
            {
                if (loggerSettings[setting])
                {
                    GetLoggerImplementation(setting).ExecuteSaveLog(id, date, text);
                }
            }

        }

        // <summary>
        // Выбор стратегии
        // </summary>
        public Loggers.ILogger GetLoggerImplementation(string setting)
        {

            if (!loggerImplementationType.ContainsKey(setting))
            {
                throw new ArgumentException($"There is no implementation for {setting}");
            }

            return loggerImplementationType[setting];
        }

        // <summary>
        // Добавление настроек логгирования в словарь
        // </summary>
        private void FillLoggerSettings()
        {
            foreach (var settingTypelevel in _configuration.GetSection("LogDestination").GetChildren())
            {
                foreach (var setting in settingTypelevel.GetChildren())
                {
                    loggerSettings.Add(setting.Key, bool.Parse(setting.Value));
                }
            }
        }
    }
}
