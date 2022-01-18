using System.Diagnostics;
using System.Reflection;

namespace NinkyNonk.Shared.Environment
{
    public static class Project
    {
        public static string ProcessName { get; }
        public static Process CurrentProcess { get; }
        public static Assembly ProjectAssembly { get; }

        static Project()
        {
            CurrentProcess = Process.GetCurrentProcess();
            ProcessName = CurrentProcess.ProcessName.Replace(".exe", "");
            ProjectAssembly = Assembly.GetExecutingAssembly();
        }
    }
}