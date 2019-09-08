using CommonDB;
using JHSNetProtocol;
using SurfSharkServer.MySQL.Tables;
using System;
using System.IO;

namespace SurfSharkServer
{

    class Program
    {
        static void Main(string[] args)
        {
            IniFile configs = new IniFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Configs/Config.ini"));
            string value = configs.GetValue<string>("GAMEVERSION");
          //  configs.Save();
            UserAccounts acc = new UserAccounts();
            acc.userName = "TTTT";
            acc.passWord = "XXXX";
            acc.createTime = DateTime.UtcNow;
            UserAccounts n = DbService.CreateEntity(acc);

           // DbService.RemoveFromDatabase<UserAccounts>(2);
            Console.ReadKey();

            TestUserManager u = new TestUserManager();
            UserAccounts d = u.GetUserAccountByUserName("test");
            d.passWord = "TESTSURFX";

            DbService.SubmitUpdate2Queue(d.UserId, d);
            Console.ReadKey();
            d.passWord = "TESTSURFX";
            // u.Save(d);
            d = u.GetUserAccountById(1);
            Console.Title = "Surf Shark Server";
            AppDomain.CurrentDomain.DomainUnload += CleanupBeforeExit;
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(CurrentDomain_ProcessExit);
            NetConfig.logFilter = JHSLogFilter.Developer;
            SharkServer.Start();
            
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
