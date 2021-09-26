using System;
using System.Diagnostics;
using System.Reflection;

namespace NinkyNonk.Shared.Logging
{
    public static class ConsoleLogger
    {

        private static readonly string ProcessName;

        static ConsoleLogger()
        {
            ProcessName = Process.GetCurrentProcess().ProcessName.Replace(".exe", "");
        }
        
        public static void Log(object data, ConsoleColor col = ConsoleColor.White)
        {
            if (col != ConsoleColor.White)
                Console.ForegroundColor = col;
            Console.WriteLine(data);
            if (col != ConsoleColor.White)
                Console.ForegroundColor = ConsoleColor.White;
        }

        public static void LogInfo(string info)
        {
            Log("[~] " + info);
        }

        public static void LogError(string error)
        {
            Log("[!] " + error, ConsoleColor.Red);
        }

        public static string AskInput(string question)
        {
            Log("[-] " + question);
            return Console.ReadLine();
        }

        public static void LogProgramInfo()
        {
            Log(ProcessName);
            Log("(c) Ninky Nonk 2021 - ninkynonk.co.uk");
        }
        
    }
}