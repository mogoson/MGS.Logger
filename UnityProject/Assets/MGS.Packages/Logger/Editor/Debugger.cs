/*************************************************************************
 *  Copyright © 2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  Debugger.cs
 *  Description  :  Debugger for unity editor.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  9/19/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.Logger.Editors
{
    /// <summary>
    /// Debugger for unity editor.
    /// </summary>
    public class Debugger : Logger.ILogger
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public Debugger() { }

        /// <summary>
        /// Logs a formatted message.
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">Format arguments.</param>
        public void Log(string format, params object[] args)
        {
            Debug.LogFormat(format, args);
        }

        /// <summary>
        /// Logs a formatted error message.
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">Format arguments.</param>
        public void LogError(string format, params object[] args)
        {
            Debug.LogErrorFormat(format, args);
        }

        /// <summary>
        /// Logs a formatted warning message.
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">Format arguments.</param>
        public void LogWarning(string format, params object[] args)
        {
            Debug.LogWarningFormat(format, args);
        }
    }
}