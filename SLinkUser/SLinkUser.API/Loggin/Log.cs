namespace SLinkUser.API.Loggin;

public static partial class Log
{
    [LoggerMessage(EventId = 0, Message = "Internal Server Error: {exceptionMessage}", SkipEnabledCheck = true)]
    public static partial void LogInternalServerError(this ILogger logger, LogLevel level, string exceptionMessage);
}
