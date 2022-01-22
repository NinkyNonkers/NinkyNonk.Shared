using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using NinkyNonk.Shared.Data;
using NinkyNonk.Shared.Environment;
using NinkyNonk.Shared.Logging;

namespace NinkyNonk.Shared.Update
{
    public static class NinkyNonkUpdateHelper
    {
        private const string Endpoint = "/project/update?versionId=";
        
        public static void DoUpdateCheck(string currentVersion, string[] args)
        {
            switch (args[0])
            {
                case "update":
                {
                    ConsoleLogger.LogUpdaterNotice();
                    ConsoleLogger.LogInfo("Installing update.... ");
                    File.Copy(Project.ProjectAssembly.Location, Project.ProcessName.Replace(".new", ""));
                    string newFile = Project.ProcessName.Replace(".new", "");
                    ConsoleLogger.LogInfo("Restarting... ");
                    Process.Start(newFile, "del");
                    Project.CurrentProcess.Close();
                    return;
                }
                case "del":
                {
                    ConsoleLogger.LogUpdaterNotice();
                    ConsoleLogger.LogInfo("Cleaning up... ");
                    File.Delete(Project.ProcessName + ".new.exe");
                    ConsoleLogger.LogSuccess("Updated! Press any key to start");
                    Console.ReadKey();
                    Console.Clear();
                    return;
                }
            }
            
            if (!ProjectEnvironmentHelper.HasInternet())
                return;

            ConsoleLogger.LogInfo("Downloading update...");
            string url = NinkyNonkService.Url.Format(false) + Endpoint + currentVersion;
            WebRequest rq = WebRequest.CreateHttp(url);
            rq.Method = "GET";
            WebResponse resp = rq.GetResponse();
            string responseContent = System.Text.Encoding.UTF8.GetString(resp.GetResponseStream().ToByteArray());
            if (responseContent == "no")
                return;
            ConsoleLogger.LogInfo("Update found... downloading");
            rq = WebRequest.CreateHttp(responseContent);
            rq.Method = "GET";
            File.WriteAllBytes("Project.ProcessName" + ".new.exe",rq.GetRequestStream().ToByteArray());
            ConsoleLogger.LogInfo("Restarting....");
            Process.Start("Project.ProcessName" + ".new.exe", "del");
            Project.CurrentProcess.Close();
        }
    }
}