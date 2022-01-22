using NinkyNonk.Shared.Environment;

namespace NinkyNonk.Shared.Configuration
{
    public static class ProjectConfigurationHelper
    {
        public static string GetConfigurationPath()
        {
            if (System.Environment.OSVersion.IsWindows())
                return "%appdata%\\NinkyNonk\\" + Project.ProcessName + "\\";
            
            return "/var/ninkynonk/" + Project.ProcessName + "/";
        }
    }
}