using System;
using System.Threading.Tasks;
using NinkyNonk.Shared.Logging;

namespace NinkyNonk.Shared.Framework
{
    public class ConsoleApplicationExecutor<T> where T : INinkyConsoleApplication
    {

        private readonly T _application;
        private readonly string[] _args;
        
        public ConsoleApplicationExecutor(T application, string[] args)
        {
            _application = application;
            _args = args;
        }


        public void Run()
        {
            try
            {
                ConsoleLogger.LogProgramInfo();
                _application.Execute(_args);
            }
            catch (Exception e)
            {
                ConsoleLogger.LogFatal(e.Message);
            }

            Console.ReadKey();
        }

        public async Task RunAsync()
        {
            try
            {
                ConsoleLogger.LogProgramInfo();
                Task t = (Task) _application.Execute(_args);
                await t;
            }
            catch (Exception e)
            {
                ConsoleLogger.LogFatal(e.Message);
            }

            Console.ReadKey();
        }
        
    }
}