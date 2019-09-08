using CommonDB;
using JHSNetProtocol;
using System;
using System.IO;

namespace SurfSharkServer
{
    class Program
    {
        public static IniFile configs = null;
        static void Main(string[] args)
        {
            Console.Title = "Surf Shark Server";
            configs = new IniFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Configs/Config.ini"));
            AppDomain.CurrentDomain.DomainUnload += CleanupBeforeExit;
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(CurrentDomain_ProcessExit);
            NetConfig.logFilter = JHSLogFilter.Developer;
            SharkServer.Start();
        WAIT_REGION:

            string line = Console.ReadLine();

            if (line == "exit")
                goto EXIT_REGION;


            goto WAIT_REGION;

        EXIT_REGION:
            Console.WriteLine("Saving Database.");
            if (DbService.ForceQuit())
            {
                Console.WriteLine("Server is now down.");
                Console.ReadKey();
            }
        }

        private static void CurrentDomain_ProcessExit(object sender, EventArgs e)
        {
            Console.WriteLine("Saving Database.");
            if (DbService.ForceQuit())
            {
                Console.WriteLine("Server is now down.");
                Console.ReadKey();
            }
            Console.ReadLine();
        }

        private static void CleanupBeforeExit(object sender, EventArgs e)
        {
            Console.WriteLine("Saving Database.");
            if (DbService.ForceQuit())
            {
                Console.WriteLine("Server is now down.");
                Console.ReadKey();
            }
            Console.ReadLine();
        }
    }
}
