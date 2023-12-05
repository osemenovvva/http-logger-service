namespace Logger.Loggers
{
    public class TxtFileLogger : ILogger
    {
        public void ExecuteSaveLog(Guid id, DateTime date, string text)
        {
            string txtLog = id + " " + date + " " + text;
            string txtPath = @"..\logger.main\logs\log.txt";

            try
            {
                using (FileStream fs = new FileStream(txtPath, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.BaseStream.Seek(0, SeekOrigin.End);
                        sw.WriteLine(txtLog);
                    }
                }
            }
            catch
            {
                throw new ArgumentException("Cannot write log to log.txt");
            }
        }
    }
}
