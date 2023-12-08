namespace Cashoverflow.Brokers.Loggings;

public class LoggingBroker
{
    public interface ILoggingBroker
    {
        void LogError(Exception exception);
        void LogCritical(Exception exception);
    }
}