# PowerErrorDetector
 A Dynamics AX extention which enables developer to catch various errors and exceptions inculuding: Overal, Transactions, CLRObject errors.

Features:
* Memory efficient: by using of Singleton design pattern
* Extensible: by using of X++ Interfaces
* Easy usability: by using of method chaining technique

## Sample job for using the facility - 1
```csharp
static void TEST_PowerLogger(Args _args)
{
    str err;
    ;

    try
    {
	throw error("My sample error.");
    }
    catch
    {
	ERR = PowerErrDetector::instance().OveralErr().reveal();
	if(err)
	    PowerLogger::instance().LogOnDB().write(err, funcName(), 0, "My sample title");
    }
}
```
## Sample job for using the facility - 2
```csharp
static void TEST_ErrorDetector(Args _args)
{
    //new PowerDetector().DotNetErr().reveal();
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
```
