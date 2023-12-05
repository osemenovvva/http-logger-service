namespace Logger.Models
{
    public class LogMessageDto
    {
        public Guid TaskId { get; set; }

        public LogDto Data { get; set; }
    }
}
