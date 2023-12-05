using log4net;

namespace Logger.Main
{
    public class LogWorker : BackgroundService
    {
        private readonly ILog _log = LogManager.GetLogger(typeof(LogWorker));
        private readonly LogMessageQueue _queue;
        private readonly LogService _logService;

        public LogWorker(LogMessageQueue queue, LogService logService)
        {
            this._queue = queue;
            this._logService = logService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    var message = await _queue.DequeueAsync(stoppingToken);
                    try
                    {
                        _logService.SaveLog(message.Data.Id, message.Data.Date, message.Data.ErrorText);
                    }
                    catch (Exception ex)
                    {
                        _log.Error(ex.ToString());
                    }
                }
            }
            catch (OperationCanceledException)
            {
                return;
            }
        }
    }
}
