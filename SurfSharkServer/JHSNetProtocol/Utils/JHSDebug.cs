using log4net;
using System;
using System.Reflection;

namespace JHSNetProtocol
{
    public interface IJHSLogger
    {
        void LogWarning(string v);

        void Log(object v);

        void LogError(string v);

        void LogError(object v);
    }

    public static class JHSDebug
    {
    //  public static IJHSLogger LogReciver = null;
        private static readonly ILog LogReciver = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public static void LogWarning(string v)
        {
            if (LogReciver != null)
                LogReciver.Warn(v);

            if (NetConfig.logFilter >= JHSLogFilter.Developer)
                Console.WriteLine(v);
        }

        public static void Log(object v)
        {
            if (LogReciver != null)
                LogReciver.Info(v);
            if (NetConfig.logFilter >= JHSLogFilter.Developer)
                Console.WriteLine(v);
        }

        public static void LogError(string v)
        {
            if (LogReciver != null)
                LogReciver.Error(v);
            if (NetConfig.logFilter >= JHSLogFilter.Developer)
                Console.WriteLine(v);
        }

        public static void LogError(object v)
        {
            if (LogReciver != null)
                LogReciver.Error(v);
            if (NetConfig.logFilter >= JHSLogFilter.Developer)
                Console.WriteLine(v);
        }
    }
}

