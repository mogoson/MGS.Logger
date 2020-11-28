/*************************************************************************
 *  Copyright © 2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  LogUtilitySettings.cs
 *  Description  :  Settings of log utility.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  9/19/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.Logger
{
    /// <summary>
    /// Settings of log utility.
    /// </summary>
    static class LogUtilitySettings
    {
        #region Public Method
        /// <summary>
        /// Initialize log utility.
        /// </summary>
        [RuntimeInitializeOnLoadMethod]
        static void Initialize()
        {
            //LogUtility auto create a FileLogger default, log dir is Environment.CurrentDirectory/Log
            //if you do not need it, invoke the LogUtility.ClearLoggers() method to clear, then add your logger to LogUtility.
            LogUtility.AddLogger(new UnityDebugger());
        }
        #endregion
    }
}