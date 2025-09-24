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
    public class Debugger : ILogger
    {
        /// <summary>
        /// Logs a formatted message.
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">Format arguments.</param>
        public void Log(string content)
        {
            Debug.Log(content);
        }

        /// <summary>
        /// Logs a formatted error message.
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">Format arguments.</param>
        public void LogError(string content)
        {
            Debug.LogError(content);
        }

        /// <summary>
        /// Logs a formatted warning message.
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">Format arguments.</param>
        public void LogWarning(string content)
        {
            Debug.LogWarning(content);
        }
    }
}