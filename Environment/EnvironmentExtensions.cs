using System;
using System.IO;
using System.Net.NetworkInformation;

namespace NinkyNonk.Shared.Environment
{
    public static class EnvironmentExtensions
    {
        public static bool IsWindows(this OperatingSystem os)
        {
            return os.Platform == PlatformID.Win32S || os.Platform == PlatformID.Win32Windows ||
                   os.Platform == PlatformID.Win32NT || os.Platform == PlatformID.WinCE;
        }

        public static byte[] ToByteArray(this Stream sourceStream)
        {
            using (var memoryStream = new MemoryStream())
            {
                sourceStream.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }

        public static bool HasInternet(this OperatingSystem os)
        {
            try { 
                Ping myPing = new Ping();
                const string host = "google.com";
                byte[] buffer = new byte[32];
                int timeout = 1000;
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