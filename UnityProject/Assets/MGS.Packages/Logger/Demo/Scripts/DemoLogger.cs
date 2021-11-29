/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  DemoLogger.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  11/28/2020
 *  Description  :  Initial development version.
 *************************************************************************/

namespace MGS.Logger.Demo
{
    public sealed class DemoLogger
    {
        // A good way to use the LogUtility is wrap it specifically.
        // Example: add module prefix identification and more infos.

        public static void Log(string format, params object[] args)
        {
            LogUtility.Log(AddPrefix(format), args);
        }

        public static void LogWarning(string format, params object[] args)
        {
            LogUtility.LogWarning(AddPrefix(format), args);
        }

        public static void LogError(string format, params object[] args)
        {
            LogUtility.LogError(AddPrefix(format), args);
        }

        private static string AddPrefix(string origin)
        {
            return "[Demo] " + origin;
        }
    }
}