using System;

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
        public static IJHSLogger LogReciver = null;
        public static void LogWarning(string v)
        {
            if (LogReciver != null)
                LogReciver.LogWarning(v);

            if (NetConfig.logFilter >= JHSLogFilter.Developer)
                Console.WriteLine(v);
        }

        public static void Log(object v)
        {
            if (LogReciver != null)
                LogReciver.Log(v);
            if (NetConfig.logFilter >= JHSLogFilter.Developer)
                Console.WriteLine(v);
        }

        public static void LogError(string v)
        {
            if (LogReciver != null)
                LogReciver.LogError(v);
            if (NetConfig.logFilter >= JHSLogFilter.Developer)
                Console.WriteLine(v);
        }

        public static void LogError(object v)
        {
            if (LogReciver != null)
                LogReciver.LogError(v);
            if (NetConfig.logFilter >= JHSLogFilter.Developer)
                Console.WriteLine(v);
        }
    }
}

