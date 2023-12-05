namespace Logger.Models
{
    public class LogDto
    {
        /// <summary>
        /// ID.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Дата события.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Текст ошибки.
        /// </summary>
        public string ErrorText { get; set; }

    }
}
