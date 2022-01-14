using System;

namespace NinkyNonk.Shared.Environment
{
    public static class EnvironmentExtensions
    {
        public static bool IsWindows(this OperatingSystem os)
        {
            return os.Platform == PlatformID.Win32S || os.Platform == PlatformID.Win32Windows ||
                   os.Platform == PlatformID.Win32NT || os.Platform == PlatformID.WinCE;
        }
    }
}