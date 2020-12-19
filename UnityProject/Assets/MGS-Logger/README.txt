==========================================================================
  Copyright © 2020-2021 Mogoson. All rights reserved.
  Name: MGS-Logger
  Author: Mogoson   Version: 1.0.0-preview1   Date: 12/19/2020
==========================================================================
  [Summary]
    Logger for Unity project.
--------------------------------------------------------------------------
  [Demand]
    Output log to Unity console.
    Output log to local file.
    Implement custom logger to output the log that print by LogUtility
    from other module.
--------------------------------------------------------------------------
  [Environment]
    Unity 5.0 or above.
    .Net Framework 3.5 or above.
--------------------------------------------------------------------------
  [Achieve]
    UnityDebugger : Output log to Unity console.
    LogUtilitySettings : Add UnityDebugger to LogUtility.

    ILogger : Interface of logger, implement custom logger and add to
    LogUtility to receive the log that print by LogUtility from other module.
    LogUtility : Provide the entry to log for every module.
--------------------------------------------------------------------------
  [Usage]
    Invoke the LogUtility.Log, LogUtility.LogWarning and LogUtility.LogError
    to output your log message.
--------------------------------------------------------------------------
  [Demo]
    Demos in the path "MGS-Logger/Scenes" provide reference to you.
--------------------------------------------------------------------------
  [Resource]
    https://github.com/mogoson/MGS-Logger.
--------------------------------------------------------------------------
  [Contact]
    If you have any questions, feel free to contact me at mogoson@outlook.com.
--------------------------------------------------------------------------