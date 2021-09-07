using System;
using System.Reflection;

namespace NinkyNonk.Shared.Logging
{
    public static class ConsoleLogger
    {
        public static void Log(object data, ConsoleColor col = ConsoleColor.White)
        {
            Console.ForegroundColor = col;
            Console.WriteLine(data);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void LogInfo(string info)
        {
            Log("[~] " + info);
        }

        public static void LogError(string error)
        {
            Log("[!]" + error, ConsoleColor.Red);
        }

        public static void LogProgramInfo()
        {
            Log(Assembly.GetExecutingAssembly().FullName);
            Log("(c) Ninky Nonk 2021 - ninkynonk.co.uk");
        }
        
    }
}