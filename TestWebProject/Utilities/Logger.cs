using System;
using System.IO;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;

namespace Utilities.Logger
{
    public static class Logger
    {
        private static bool configured;

        public static void Configure()
        {
            if (configured)
            {
                return;
            }

            string debugPath = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console(theme: AnsiConsoleTheme.Code)
                .WriteTo.RollingFile(Path.Combine(debugPath, "log-{Date}.txt"))
                .CreateLogger();

            configured = true;
        }
    }
}
