# HTTP Logger Service
The HTTP Logger Service is designed to handle incoming data via HTTP requests. The architecture involves a controller receiving HTTP requests, queuing them for processing, and a worker pulling items from the queue to invoke a logging service.

## Extending Log Formats
To add a new log format, follow these steps:
1. Create a new class implementing the **`ILogger`** interface.
2. Implement the necessary logic for the log format within the new class.
3. Add an instance of the new class to the logger configuration.
4. Add new configuration settings to the **`appsettings.json`** file.
