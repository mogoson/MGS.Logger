/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  LoggerDemo.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  11/28/2020
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.Logger.Demo
{
    public class LoggerDemo : MonoBehaviour
    {
        #region Private Method
        private void Awake()
        {
            //This log can not output to the default logger before Unity5.3, see LogUtilityInitializer.Awake to learn more.
            DemoLogger.Log("LoggerTest Awake");
        }

        private void Start()
        {
            //Just simple example,
            //LogUtility is usually used for libraries that don't rely on Unity.
            DemoLogger.LogWarning("LoggerTest Start");
        }

        private void OnDestroy()
        {
            DemoLogger.LogError("LoggerTest OnDestroy");
        }
        #endregion
    }
}