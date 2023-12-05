using Logger.Models;
using Microsoft.AspNetCore.Mvc;

namespace Logger.Main
{
    [ApiController, Route("[controller]")]
    public class LogController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateTask([FromBody] LogDto data, [FromServices] LogMessageQueue queue)
        {
            var taskId = Guid.NewGuid();
            queue.Enqueue(new LogMessageDto
            {
                TaskId = taskId,
                Data = data,
            });

            return Ok(new LogResultDto { TaskId = taskId });
        }
    }
}
