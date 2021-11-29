/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  FileLogger.cs
 *  Description  :  Loggger for log to local file.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  9/19/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using System.IO;

namespace MGS.Logger
{
    /// <summary>
    /// Loggger for log to local file.
    /// </summary>
    public class FileLogger : ILogger
    {
        #region Field and Property
        /// <summary>
        /// Extension of log file.
        /// </summary>
        public const string FILE_EXTENSION = ".log";

        /// <summary>
        /// The tag of log message.
        /// </summary>
        public const string TAG_LOG = "LOG";

        /// <summary>
        /// The tag of error message.
        /// </summary>
        public const string TAG_ERROR = "ERROR";

        /// <summary>
        /// The tag of warning message.
        /// </summary>
        public const string TAG_WARNING = "WARNING";

        /// <summary>
        /// Root directory of log files.
        /// </summary>
        public string RootDir { protected set; get; }

        /// <summary>
        /// Filter for log content.
        /// </summary>
        public IFilter Filter { set; get; }
        #endregion

        #region Protected Method
        /// <summary>
        /// Logs a formatted message to local file.
        /// </summary>
        /// <param name="tag">Tag of log message.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">Format arguments.</param>
        protected virtual void LogToFile(string tag, string format, params object[] args)
        {
            if (Filter != null && !Filter.Select(tag, format, args))
            {
                return;
            }

            var logFilePath = ResolveLogFile(RootDir);
            var logContent = ResolveLogContent(tag, format, args);
            AppendToFile(logFilePath, logContent);
        }

        /// <summary>
        /// Resolve the path of log file.
        /// </summary>
        /// <param name="rootDir">Root directory of log files.</param>
        /// <returns>The path of log file.</returns>
        protected virtual string ResolveLogFile(string rootDir)
        {
            var fileName = DateTime.Now.ToString("yyyy-MM-dd");
            return string.Format("{0}/{1}{2}", rootDir, fileName, FILE_EXTENSION);
        }

        /// <summary>
        /// Resolve the log content.
        /// </summary>
        /// <param name="tag">Tag of log message.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">Format arguments.</param>
        /// <returns>The log content.</returns>
        protected virtual string ResolveLogContent(string tag, string format, params object[] args)
        {
            var logTimeStamp = DateTime.Now.ToLongTimeString();
            var formatMsg = string.Format(format, args);
            return string.Format("{0}-{1}-{2}\r\n\r\n", logTimeStamp, tag, formatMsg);
        }

        /// <summary>
        /// Append content to file at path.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="content"></param>
        protected void AppendToFile(string filePath, string content)
        {
            try
            {
                var dir = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                File.AppendAllText(filePath, content);
            }
#if DEBUG
            catch (Exception ex)
            {
                throw ex;
            }
#else
            catch { }
#endif
        }

        /// <summary>
        /// Delete file at path.
        /// </summary>
        /// <param name="filePath"></param>
        protected void DeleteFile(string filePath)
        {
            try { File.Delete(filePath); }
#if DEBUG
            catch (Exception ex)
            {
                throw ex;
            }
#else
            catch { }
#endif
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="rootDir">Root directory of log files.</param>
        /// <param name="filter">Filter for log content.</param>
        public FileLogger(string rootDir, IFilter filter = null)
        {
            RootDir = rootDir;
            Filter = filter;
        }

        /// <summary>
        /// Logs a formatted message to local file.
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">Format arguments.</param>
        public void Log(string format, params object[] args)
        {
            LogToFile(TAG_LOG, format, args);
        }

        /// <summary>
        /// Logs a formatted error message to local file.
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">Format arguments.</param>
        public void LogError(string format, params object[] args)
        {
            LogToFile(TAG_ERROR, format, args);
        }

        /// <summary>
        /// Logs a formatted warning message to local file.
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">Format arguments.</param>
        public void LogWarning(string format, params object[] args)
        {
            LogToFile(TAG_WARNING, format, args);
        }

        /// <summary>
        /// Clear log file reserve recent specific count.
        /// </summary>
        /// <param name="reserve"></param>
        public void ClearLogFile(int reserve)
        {
            var searchPattern = string.Format("*{0}", FILE_EXTENSION);
            var files = Directory.GetFiles(RootDir, searchPattern);
            if (files.Length <= reserve)
            {
                return;
            }

            var obsoletes = files.Length - reserve;
            for (int i = 0; i < obsoletes; i++)
            {
                DeleteFile(files[i]);
            }
        }

        /// <summary>
        /// Clear log file before specific date time.
        /// </summary>
        /// <param name="before"></param>
        public void ClearLogFile(DateTime before)
        {
            var searchPattern = string.Format("*{0}", FILE_EXTENSION);
            var files = Directory.GetFiles(RootDir, searchPattern);
            foreach (var file in files)
            {
                var fileName = Path.GetFileNameWithoutExtension(file);
                DateTime fileDate;
                if (DateTime.TryParse(fileName, out fileDate) && fileDate >= before)
                {
                    continue;
                }

                DeleteFile(file);
            }
        }
        #endregion
    }
}