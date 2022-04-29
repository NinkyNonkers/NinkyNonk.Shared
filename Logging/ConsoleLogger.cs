using System;
using NinkyNonk.Shared.Environment;

namespace NinkyNonk.Shared.Logging
{
    public static class ConsoleLogger
    {
        public static void Log(object data, ConsoleColor col = ConsoleColor.White)
        {
            if (col != ConsoleColor.White)
                Console.ForegroundColor = col;
            Console.WriteLine(data);
            if (col != ConsoleColor.White)
                Console.ForegroundColor = ConsoleColor.White;
        }

        internal static void LogUpdaterNotice()
        {
            Log("NinkyNonk Project Updater");
            LogCopyright();
        }

        public static void LogInfo(string info)
        {
            Log("[~] " + info);
        }

        public static void LogError(string error)
        {
            Log("[!] " + error, ConsoleColor.Red);
        }

        public static void LogFatal(string fatal)
        {
            Log("[X] " + fatal, ConsoleColor.Red);
        }

        public static void LogSuccess(string success)
        {
            Log("[+] " + success, ConsoleColor.Green);
        }

        public static void LogUpdate(string update)
        {
            Log("[i] " + update);
        }

        public static bool AskInputBool(string question, ConsoleColor col = ConsoleColor.White)
        {
            string result = AskInput(question + " (y/N)", col).ToLower();
            return result.Contains("y") || result.Contains("true") || result.Contains("1") || result.Contains("!false");
        }

        public static string AskInput(string question, ConsoleColor col = ConsoleColor.White)
        {
            Log("[-] " + question, col);
            return Console.ReadLine();
        }

        public static void LogCopyright()
        {
            Log($"(c) Ninky Nonk {DateTime.Today.Year} - {NinkyNonkService.Domain}");
        }

        public static void LogProgramInfo()
        {
            Log(Project.ProcessName);
            LogCopyright();
        }
        
        
    }
}