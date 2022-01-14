using System;
using System.Runtime.InteropServices;
using NinkyNonk.Shared.Environment;

namespace NinkyNonk.Shared.Framework
{
    public class ConsoleProgramSimulator : IDisposable
    {
        
        [DllImport("kernel32.dll")]
        private static extern Boolean AllocConsole();

        [DllImport("kernel32.dll")]
        private static extern void FreeConsole();
        
        [DllImport("kernel32.dll")]
        private static extern bool AttachConsole(int processId);
        
        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);


        public void CreateConsole()
        {
            AllocConsole();
            AttachConsole(Project.CurrentProcess.Id);
            Project.CurrentProcess.Exited += CurrentProcessOnExited;
        }

        private static void CurrentProcessOnExited(object sender, EventArgs e)
        {
            SetConsoleWindowVisibility(false);
            Project.CurrentProcess.WaitForExit();
        }

        public void Dispose()
        {
            FreeConsole();
        }

        private static void SetConsoleWindowVisibility(bool visible)
        {
            IntPtr hWnd = FindWindow(null, Console.Title);
            
            if (hWnd != IntPtr.Zero)
                ShowWindow(hWnd, visible ? 1 : 0);
        }
    }
}