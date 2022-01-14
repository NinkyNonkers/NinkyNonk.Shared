using System.Diagnostics;

namespace NinkyNonk.Shared.Environment
{
    public static class Project
    {
        public static string ProcessName { get; }
        
        public static Process CurrentProcess { get; }

        static Project()
        {
            ProcessName = Process.GetCurrentProcess().ProcessName.Replace(".exe", "");
            CurrentProcess = Process.GetCurrentProcess();
        }
    }
}