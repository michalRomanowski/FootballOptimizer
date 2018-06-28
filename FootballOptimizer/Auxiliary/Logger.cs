using System;
using System.IO;

namespace Auxiliary
{
    public static class Logger
    {
        public static string LOG_PATH = Path.Combine(Directory.GetCurrentDirectory(), "log.txt");

        private static object locker = new object();

        private static StreamWriter logFile;

        public static void Clear()
        {
            if(!File.Exists(LOG_PATH))
                File.Create(LOG_PATH);

            if (logFile != null)
                logFile.Close();

            logFile = new StreamWriter(LOG_PATH, false);
        }

        public static void CopyToDir(string dirPath)
        {
            if (logFile == null)
                logFile = new StreamWriter(LOG_PATH, true);

            File.Copy(LOG_PATH, Path.Combine(dirPath, "log.txt"));
        }

        public static void AddLine(string line)
        {
            if(logFile == null)
                logFile = new StreamWriter(LOG_PATH, true);

            lock (locker)
            {
                logFile.WriteLine(line);
            }
        }

        public static void Flush()
        {
            try
            {
                logFile.Flush();
            }
            catch (ObjectDisposedException) { }
        }

        public static void Close()
        {
            if(logFile != null)
                logFile.Close();
        }
    }
}
