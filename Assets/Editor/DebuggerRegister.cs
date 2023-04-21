/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  DebuggerRegister.cs
 *  Description  :  Register for debugger.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  1/3/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.Logger.Editors
{
    /// <summary>
    /// Register for debugger.
    /// </summary>
    public static class DebuggerRegister
    {
        /// <summary>
        /// Awake register.
        /// </summary>
#if UNITY_5_3 || UNITY_5_3_OR_NEWER
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
#else
        [RuntimeInitializeOnLoadMethod]
#endif
        private static void Awake()
        {
            LogUtility.Register(new Debugger());
        }
    }
}