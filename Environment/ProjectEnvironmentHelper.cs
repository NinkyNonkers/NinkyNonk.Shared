using System;
using System.Net.NetworkInformation;

namespace NinkyNonk.Shared.Environment
{
    public static class ProjectEnvironmentHelper
    {
        
        public static bool IsWindows(this OperatingSystem os)
        {
            return os.Platform == PlatformID.Win32S || os.Platform == PlatformID.Win32Windows ||
                   os.Platform == PlatformID.Win32NT || os.Platform == PlatformID.WinCE;
        }

        public static string GetProgramFilesDirectory()
        {
            if (System.Environment.OSVersion.IsWindows())
                return "%ProgramFiles%\\NinkyNonk\\" + Project.ProcessName + "\\";
            
            return "/bin/ninkynonk/" + Project.ProcessName + "/";
        }
        
        public static bool HasInternet()
        {
            try { 
                Ping myPing = new Ping();
                const string host = "google.com";
                byte[] buffer = new byte[32];
                const int timeout = 1000;
                PingOptions pingOptions = new PingOptions();
                PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);
                return reply != null && (reply.Status == IPStatus.Success);
            }
            catch (Exception) {
                return false;
            }
        }
    }
}