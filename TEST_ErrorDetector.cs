static void TEST_ErrorDetector(Args _args)
{
    int x;
    try
    {
        x = 1/0;
        throw Exception::CLRError;
    }
    catch(Exception::CLRError)
    {
        info(strFmt("%1", PowerErrDetector::instance().OveralErr().reveal()));
    }
}