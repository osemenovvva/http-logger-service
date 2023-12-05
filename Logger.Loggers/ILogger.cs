namespace Logger.Loggers
{
    public interface ILogger
    {
        public void ExecuteSaveLog(Guid id, DateTime date, string text);

    }
}
