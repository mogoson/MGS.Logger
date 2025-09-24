/*************************************************************************
 *  Copyright © 2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  LogInitializer.cs
 *  Description  :  Initializer for log.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  9/19/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using UnityEngine;

namespace MGS.Logger
{
    /// <summary>
    /// Initializer for log.
    /// </summary>
    public sealed class LogInitializer
    {
        /// <summary>
        /// Key of last time clear log.
        /// </summary>
        private const string KEY_LAST_TIME_CLEAR_LOG = "KEY_LAST_TIME_CLEAR_LOG";

        /// <summary>
        /// Awake initializer.
        /// </summary>
#if UNITY_5_3 || UNITY_5_3_OR_NEWER
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
#else
        [RuntimeInitializeOnLoadMethod]
#endif
        private static void Awake()
        {
            //Register file logger to LogUtility.
            var logDir = string.Format("{0}/Log/", Application.persistentDataPath);
            var logger = new FileLogger(logDir);
            LogUtility.Register(logger);
#if UNITY_EDITOR
            Debug.LogFormat("Register file logger to the directory {0}", logDir);
#endif
            //Clear log files if out of 60 days.
            var lastRecord = PlayerPrefs.GetString(KEY_LAST_TIME_CLEAR_LOG);
            if (DateTime.TryParse(lastRecord, out DateTime lastClearTime))
            {
                if ((lastClearTime - DateTime.Now).Days > 60)
                {
                    //Clear log files (Keep the last 10 files).
                    logger.ClearLogFile(10);
                    PlayerPrefs.SetString(KEY_LAST_TIME_CLEAR_LOG, DateTime.Now.ToString());
                }
            }
            else
            {
                PlayerPrefs.SetString(KEY_LAST_TIME_CLEAR_LOG, DateTime.Now.ToString());
            }
        }
    }
}