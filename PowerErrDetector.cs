/// <summary>
/// A highly-reusable tool for detecting and revealing errors of both X++ and CLR objects
/// It takes advantage of singleton design pattern for preventing waste of memory
/// It also has the ability to be logged by the PowerLogger::instance().LogOnDB().writeDetector(*) class
///
/// Created and maintained By Jalal Derakhshani
/// drakhshani.aram@hotmail.com
/// 2020
/// </summary>
///
class PowerErrDetector
{
    str finalMsg;
}

private void new()
{
}

public OveralErr OveralErr()
{
    return OveralErr::instance();
}

public static PowerErrDetector instance()
{
    PowerErrDetector   singleton;
    SysGlobalCache  globalCache = infolog.objectOnServer() ? appl.globalCache() : infolog.globalCache();
    ;

    if (globalCache.isSet(classStr(PowerErrDetector), 0))

        singleton = globalCache.get(classStr(PowerErrDetector), 0);

    else
    {
        singleton = new PowerErrDetector();
        infoLog.globalCache().set(classStr(PowerErrDetector), 0, singleton);
        appl.globalCache().set(classStr(PowerErrDetector), 0, singleton);

    }
    return singleton;
}