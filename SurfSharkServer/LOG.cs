using JHSNetProtocol;
using log4net;
using SurfSharkServer;
using System;
using System.Reflection;

public class LOG : IJHSLogger
{
    public static ILog log = LogManager.GetLogger(typeof(Program));

    public static void Error(string v)
    {
        log.Error(v);
    }

    public static void Warning(string v)
    {
        log.Warn(v);
    }

    public static void Exception(string v)
    {
        log.Fatal(v);
    }

    public static void Info(string v)
    {
        log.Info(v);
    }

    public static void Debug(string v)
    {
        log.Debug(v);
    }

    public static void Mysql(string v)
    {
        log.Debug(v);
    }

    public static void Network(string v)
    {
        log.Debug(v);
    }

    public void LogWarning(string v)
    {
        Warning(v);
    }

    public void Log(object v)
    {
        Info(v.ToString());
    }

    public void LogError(string v)
    {
        Error(v);
    }

    public void LogError(object v)
    {
        Error(v.ToString());
    }
}
