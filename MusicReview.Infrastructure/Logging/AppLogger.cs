using MusicReview.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicReview.Infrastructure.Logging
{
    public class AppLogger:IAppLogger
    {
        private readonly string _logDirectory = "logs";

        public AppLogger()
        {
            if (!Directory.Exists(_logDirectory))
            {
                Directory.CreateDirectory(_logDirectory);
            }
        }

        public void LogInfo(string message)
        {
            Log($"INFO: {message}");
        }

        public void LogError(string message)
        {
            Log($"ERROR: {message}");
        }

        private void Log(string message)
        {
            var logPath = Path.Combine(_logDirectory, $"log_{DateTime.Now:yyyyMMdd}.txt");
            File.AppendAllText(logPath, $"[{DateTime.Now:HH:mm:ss}] {message}{Environment.NewLine}");
        }
    }
}
