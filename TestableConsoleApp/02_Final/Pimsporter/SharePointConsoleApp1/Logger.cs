using System;

namespace Pimsporter
{
    class Logger
    {
        public LoggingTarget Target;
        public LogLevel Level { get; set; }

        public enum LoggingTarget
        {
            CONSOLE
        }

        public enum LogLevel
        {
            DEBUG,
            INFO,
            WARNING,
            ERROR
        }

        public void Error(string message, Exception ex = null)
        {
            if (Level >= LogLevel.ERROR)
                Log(message, ex);
        }

        public void Warning(string message, Exception ex = null)
        {
            if (Level >= LogLevel.WARNING)
                Log(message, ex);
        }

        public void Info(string message, Exception ex = null)
        {
            if (Level >= LogLevel.INFO)
                Log(message, ex);
        }

        public void Debug(string message, Exception ex = null)
        {
            if (Level >= LogLevel.DEBUG)
                Log(message, ex);
        }

        private void Log(string message, Exception ex = null)
        {
            if (Target == LoggingTarget.CONSOLE)
                LogConsole(message, ex);
        }

        private void LogConsole(string message, Exception ex = null)
        {
            Console.WriteLine(message);
            if (ex != null)
                Console.WriteLine(ex);
        }
    }


}
