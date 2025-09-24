/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ILogger.cs
 *  Description  :  Interface of logger.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  9/5/2015
 *  Description  :  Initial development version.
 *************************************************************************/

namespace MGS.Logger
{
    /// <summary>
    /// Interface of logger.
    /// </summary>
    public interface ILogger
    {
        #region Method
        /// <summary>
        /// Logs a formatted message.
        /// </summary>
        /// <param name="content">Content of log.</param>
        void Log(string content);

        /// <summary>
        /// Logs a formatted error message.
        /// </summary>
        /// <param name="content">Content of log.</param>
        void LogError(string content);

        /// <summary>
        /// Logs a formatted warning message.
        /// </summary>
        /// <param name="content">Content of log.</param>
        void LogWarning(string content);
        #endregion
    }
}