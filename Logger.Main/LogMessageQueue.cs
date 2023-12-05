using Logger.Models;
using Microsoft.VisualStudio.Threading;

namespace Logger.Main
{
    public class LogMessageQueue : AsyncQueue<LogMessageDto>
    {
    }
}
