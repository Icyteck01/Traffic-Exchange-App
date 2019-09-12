using CommonDB;
using JHSNetProtocol;
using log4net;
using log4net.Config;
using System;
using System.IO;
using System.Reflection;

namespace SurfSharkServer
{
    class Program
    {
        public static IniFile configs = null;
        static void Main(string[] args)
        {
            Console.Title = "Surf Shark Server";
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Configs/Net4Log.xml")));
            configs = new IniFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Configs/Config.ini"));
            AppDomain.CurrentDomain.DomainUnload += CleanupBeforeExit;
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(CurrentDomain_ProcessExit);
            JHSDebug.LogReciver = new LOG();
            NetConfig.logFilter = JHSLogFilter.Error;
            var v = DbService.GetDBSession;
            var x = UserManager.Instance;
            SharkServer.Start();
        WAIT_REGION:

            string line = Console.ReadLine();

            if (line == "exit")
                goto EXIT_REGION;


            goto WAIT_REGION;

        EXIT_REGION:
            LOG.Info("Saving Database.");
            if (DbService.ForceQuit())
            {
                LOG.Info("Server is now down.");
            }
        }

        private static void CurrentDomain_ProcessExit(object sender, EventArgs e)
        {
            LOG.Info("Saving Database.");
            if (DbService.ForceQuit())
            {
                LOG.Info("Server is now down.");
            }
        }

        private static void CleanupBeforeExit(object sender, EventArgs e)
        {
            LOG.Info("Saving Database.");
            if (DbService.ForceQuit())
            {
                LOG.Info("Server is now down.");
            }
        }
    }
}
