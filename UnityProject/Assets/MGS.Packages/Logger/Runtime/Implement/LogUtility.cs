﻿/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  LogUtility.cs
 *  Description  :  Utility for log output.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  9/5/2015
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using System.Collections.Generic;

namespace MGS.Logger
{
    /// <summary>
    /// Utility for log output.
    /// </summary>
    public sealed class LogUtility
    {
        #region Field and Property
        /// <summary>
        /// Loggers of utility.
        /// </summary>
        private static ICollection<ILogger> loggers = new List<ILogger>();
        #endregion

        #region
        /// <summary>
        /// Static constructor.
        /// </summary>
        static LogUtility()
        {
            AppDomain.CurrentDomain.UnhandledException += (s, e) =>
            {
                var ex = e.ExceptionObject as Exception;
                LogError("UnhandledException: Runtime terminating {0}\r\n{1}{2}{3}",
                    e.IsTerminating, s, ex.Message, ex.StackTrace);
            };
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Register logger to utility.
        /// </summary>
        /// <param name="logger">Logger for output message.</param>
        public static void Register(ILogger logger)
        {
            if (logger == null)
            {
                return;
            }

            if (loggers.Contains(logger))
            {
                return;
            }

            loggers.Add(logger);
        }

        /// <summary>
        /// Unregister logger from utility.
        /// </summary>
        /// <param name="logger">Logger for output message.</param>
        public static void Unregister(ILogger logger)
        {
            if (loggers.Contains(logger))
            {
                loggers.Remove(logger);
            }
        }

        /// <summary>
        /// Clear the loggers of utility.
        /// </summary>
        public static void Clear()
        {
            loggers.Clear();
        }

        /// <summary>
        /// Logs a formatted message.
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">Format arguments.</param>
        public static void Log(string format, params object[] args)
        {
            foreach (var logger in loggers)
            {
                logger.Log(format, args);
            }
        }

        /// <summary>
        /// Logs a formatted error message.
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">Format arguments.</param>
        public static void LogError(string format, params object[] args)
        {
            foreach (var logger in loggers)
            {
                logger.LogError(format, args);
            }
        }

        /// <summary>
        /// Logs a formatted warning message.
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">Format arguments.</param>
        public static void LogWarning(string format, params object[] args)
        {
            foreach (var logger in loggers)
            {
                logger.LogWarning(format, args);
            }
        }

        /// <summary>
        /// Logs a formatted exception message.
        /// </summary>
        /// <param name="ex">Instance of exception.</param>
        public static void LogException(Exception ex)
        {
            LogError("{0}\r\n{1}", ex.Message, ex.StackTrace);
        }
        #endregion
    }
}