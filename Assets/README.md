[TOC]

# MGS.Logger

## Summary
- Logger for C# project develop.
- Logger for Unity project.

## Platform

- Windows
- Android

## Environment

- Unity 5.0 or above.

- .Net Framework 3.5 or above.

## Version

- 2.0.0

## Demand
- Output log to local file.
- Implement custom logger to output the log that print by LogUtility from other module.

## Usage

- Reference

  If you need use LogUtility in dll：

  - Create a C# project, move the following files into the project:
    - ./Runtime/...
  - Compile project as dll to reference.


- Use LogUtility to output log content.

```C#
//The log output at Unity console in editor mode;
//and write to local file at the path:
//string.Format("{0}/Log/", Application.persistentDataPath)

LogUtility.Log("Log info is {0}", info);
LogUtility.LogError("Log error is {0}", error);
LogUtility.LogWarning("Log warning is {0}", warning);
```

- Wrap LogUtility specifically.

```C#
public sealed class Logger
{
    // A good way to use the LogUtility is wrap it specifically.
    // Example: add module prefix identification and more infos.

    public static void Log(string format, params object[] args)
    {
        LogUtility.Log(AddPrefix(format), args);
    }
    
    private static string AddPrefix(string origin)
    {
        return "[Demo] " + origin;
    }
}

Logger.Log("Log info is {0}", info);
```

- Use log Filter.

```C#
//Implemente IFilter base your logic.
public class Filter : IFilter
{
    public bool Select(string tag, string format, params object[] args)
    {
        //TODO: Decide whether to select this log.
        return tag.Contains(FileLogger.TAG_ERROR);
    }
}

//Register logger to LogUtility.
var logDir = string.Format("{0}/Log/", Environment.CurrentDirectory);
LogUtility.Register(new FileLogger(logDir, new Filter()));
```

- Override log path.

```c#
//Override the LogInitializer.Awake();
//new a FileLogger with custom log file path;
//Register the FileLogger to LogUtility.

var logDir = string.Format("{0}/Log/", Environment.CurrentDirectory);
LogUtility.Register(new FileLogger(logDir));
```

- Override the Logger of LogUtility.

```C#
//Override the LogInitializer.Awake();
//Implemente a CustomLogger;
//Register the CustomLogger to LogUtility.

public class CustomLogger : ILogger
{
  public void Log(string format, params object[] args)
  {
    //TODO: Implemente the logic.
  }

  public void LogError(string format, params object[] args)
  {
    //TODO: Implemente the logic.
  }

  public void LogWarning(string format, params object[] args)
  {
    //TODO: Implemente the logic.
  }
}

LogUtility.Register(new CustomLogger());
```

------

Copyright © 2023 Mogoson.	mogoson@outlook.com