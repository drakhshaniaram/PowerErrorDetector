class OveralErr implements IDetectable
{
    Notes finalMsg;
    SysInfoLogEnumerator                  infoLogEnum;
    SysInfologMessageStruct               infoMessageStruct;
    System.Exception                      exception;
    System.Exception                      netExcepn;
}

private void new()
{
}

public str reveal()
{
    finalMsg = "";

    //---> Catch the typical exceptions
    infoLogEnum = SysInfoLogEnumerator::newData(infolog.infologData());
    while(infoLogEnum.moveNext())
    {
        infoMessageStruct = SysInfologMessageStruct::construct(infoLogEnum.currentMessage());
        finalMsg += infoMessageStruct.message() + " | ";
    }
    //<---

    //---> Catch the .Net CLR Objects error
    //finalMsg += con2Str(xSession::xppCallStack()) + " | ";

    if(CLRInterop::getLastException() != null){
        exception = CLRInterop::getLastException();

        while (exception)
        {
            finalMsg += CLRInterop::getAnyTypeForObject(exception.ToString()) + " | ";
            exception = exception.get_InnerException();
        }
    }
    //<---

    return finalMsg;
}

public static OveralErr instance()
{
    OveralErr   singleton;
    SysGlobalCache  globalCache = infolog.objectOnServer() ? appl.globalCache() : infolog.globalCache();
    ;

    if (globalCache.isSet(classStr(OveralErr), 0))

        singleton = globalCache.get(classStr(OveralErr), 0);

    else
    {
        singleton = new OveralErr();
        infoLog.globalCache().set(classStr(OveralErr), 0, singleton);
        appl.globalCache().set(classStr(OveralErr), 0, singleton);

    }
    return singleton;
}

