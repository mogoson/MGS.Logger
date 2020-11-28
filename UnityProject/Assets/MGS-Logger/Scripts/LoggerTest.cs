/*************************************************************************
 *  Copyright © 2020 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  LoggerTest.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  11/28/2020
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.Logger
{
    public class LoggerTest : MonoBehaviour
    {
        #region Private Method
        private void Awake()
        {
            //LogUtilitySettings.Initialize add UnityDebugger to LogUtility execute after MonoBehaviour.Awake,
            //so this log can not output to Unity console, but output to log file is work.
            LogUtility.Log("LoggerTest Awake");
        }

        private void Start()
        {
            LogUtility.LogWarning("LoggerTest Start");
        }

        private void OnDestroy()
        {
            LogUtility.LogError("LoggerTest OnDestroy");
        }
        #endregion
    }
}